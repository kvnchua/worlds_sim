using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillSaveData : IData
{
    public SkillData datas;
    
    public void New()
    {
        datas = new SkillData();
    }

    public void Save()
    {
        DataManager<SkillSaveData>.Data = this;
    }

    public void ChangeValue(CharacterSkill save)
    {
        datas.ChangeValue(save);
        Save();
    }
}
