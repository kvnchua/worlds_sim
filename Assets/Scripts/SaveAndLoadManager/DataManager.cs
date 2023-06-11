using System.Collections.Generic;

public static class DataManager<T> where T : IData, new()
{
    private static List<IData> datas = new List<IData>();

    public static T Data
    {
        get { return Load(); }
        set { Save(value); }
    }

    private static void Save(T newData)
    {
        T oldData = (T)datas.Find(d => d.GetType() == typeof(T));

        if (oldData != null)
            SaveAndLoadController.Save(typeof(T).FullName, SaveAndLoadController.FileType.Save, oldData);
        else
            SaveAndLoadController.Save(typeof(T).FullName, SaveAndLoadController.FileType.Save, newData);
    }

    private static T Load()
    {
        T oldData = (T)datas.Find(d => d.GetType() == typeof(T));
        if (oldData != null)
            return oldData;
        else
        {
            bool newFile = false;

            T newData = SaveAndLoadController.Load<T>(typeof(T).FullName, SaveAndLoadController.FileType.Save, out newFile);

            if (newFile)
                newData.New();

            datas.Add(newData);

            return (T)datas[datas.IndexOf(newData)];
        }
    }
}
