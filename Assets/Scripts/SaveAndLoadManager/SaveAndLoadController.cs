using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveAndLoadController
{
    public enum FileType
    {
        Save,
        Load
    }

    public static void Save<T>(string fileName,FileType fileType,T Data)
    {
        BinaryFormatter bf = new BinaryFormatter();

        string dataPath = Path.Combine(Application.persistentDataPath, fileName + "." + fileType.ToString());

        FileStream file = File.Create(dataPath);

        bf.Serialize(file, Data);

        file.Close();
    }

    public static T Load<T>(string fileName, FileType fileType) where T : new()
    {
        bool newFile = false;
        return Load<T>(fileName, fileType, out newFile);
    }

    public static T Load<T>(string fileName, FileType fileType,out bool newFile) where T : new()
    {
        T Data;
        newFile = false;

        if (File.Exists(Application.persistentDataPath + "/" + fileName + "." + fileType.ToString()))
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream file = File.Open(Application.persistentDataPath + "/" + fileName + "." + fileType.ToString(), FileMode.Open))
            {
                Data = (T)bf.Deserialize(file);

                file.Close();

                return Data;
            }
        }
        else
        {
            newFile = true;
            Data = new T();
            Save(fileName, fileType, Data);
            return Data;
        }
    }
}
