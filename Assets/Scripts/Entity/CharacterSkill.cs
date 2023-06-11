using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkill : MonoBehaviour
{
    SkillSaveData skillData;
    
    public int harvestLevel { get; private set; }
    public float harvestProgress { get; private set; }
    private float maxHarvestProg;
    public int sickleLevel { get; private set; }
    public float sickleProgress { get; private set; }
    private float maxSickleProg;
    public int hoeLevel { get; private set; }
    public float hoeProgress { get; private set; }
    private float maxHoeProg;
    public int waterLevel { get; private set; }
    public float waterProgress { get; private set; }
    private float maxWaterProg;

    private void Start()
    {
        skillData = DataManager<SkillSaveData>.Data;
        LoadAllValue();
        Debug.Log("Harvest Progess: " + harvestProgress + " At Level: " + harvestLevel);
        Debug.Log("Sickle Progess: " + sickleProgress + " At Level: " + sickleLevel);
        Debug.Log("Hoe Level Progess: " + hoeProgress + " At Level: " + hoeLevel);
        Debug.Log("Water Progess: " + waterProgress + " At Level: " + waterLevel);
    }

    public void HarvestProg()
    {
        //harvestProg = 
        harvestProgress++;
        if (harvestProgress >= maxHarvestProg)
        {
            harvestLevel++;
            harvestProgress = 0.0f;
            maxHarvestProg = harvestLevel * 100.0f;
        }

        skillData.ChangeValue(this);
    }

    public void SickleProg()
    {
        //harvestProg = 
        sickleProgress++;
        if (sickleProgress >= maxSickleProg)
        {
            sickleLevel++;
            sickleProgress = 0.0f;
            maxSickleProg = sickleLevel * 100.0f;
        }

        skillData.ChangeValue(this);
    }

    public void HoeLevelProg()
    {
        hoeProgress++;
        if (hoeProgress >= maxHoeProg)
        {
            hoeLevel++;
            hoeProgress = 0.0f;
            maxHoeProg = hoeLevel * 100.0f;
        }

        skillData.ChangeValue(this);
    }

    public void WaterProg()
    {
        waterProgress++;
        if(waterProgress >= maxWaterProg)
        {
            waterLevel++;
            waterProgress = 0.0f;
            maxWaterProg = waterLevel * 100.0f;
        }

        skillData.ChangeValue(this);
    }

    public void LoadAllValue()
    {
        harvestLevel = skillData.datas.GetHarvestLevel();
        harvestProgress = skillData.datas.GetHarvestProg();
        sickleLevel = skillData.datas.GetSickleLevel();
        sickleProgress = skillData.datas.GetSickleProg();
        hoeLevel = skillData.datas.GetHoeLevel();
        hoeProgress = skillData.datas.GetHoeProg();
        waterLevel = skillData.datas.GetWaterLevel();
        waterProgress = skillData.datas.GetWaterProg();
        maxHarvestProg = harvestLevel * 100.0f;
        maxSickleProg = sickleLevel * 100.0f;
        maxHoeProg = hoeLevel * 100.0f;
        maxWaterProg = waterLevel * 100.0f;
    }
}

[System.Serializable]
public class SkillData
{
    int harvestLevel;
    float harvestProgress;
    int sickleLevel;
    float sickleProgress;
    int hoeLevel;
    float hoeProgress;
    int waterLevel;
    float waterProgress;

    public int GetHarvestLevel() { return harvestLevel; }
    public float GetHarvestProg() { return harvestProgress; }
    public int GetSickleLevel() { return sickleLevel; }
    public float GetSickleProg() { return sickleProgress; }
    public int GetHoeLevel() { return hoeLevel; }
    public float GetHoeProg() { return hoeProgress; }
    public int GetWaterLevel() { return waterLevel; }
    public float GetWaterProg() { return waterProgress; }

    public void ChangeValue(CharacterSkill save)
    {
        harvestLevel = save.harvestLevel;
        harvestProgress = save.harvestProgress;
        sickleLevel = save.sickleLevel;
        sickleProgress = save.sickleProgress;
        hoeLevel = save.hoeLevel;
        hoeProgress = save.hoeProgress;
        waterLevel = save.waterLevel;
        waterProgress = save.waterProgress;
    }

    public SkillData()
    {
        harvestLevel = 0;
        harvestProgress = 0.0f;
        sickleLevel = 0;
        sickleProgress = 0.0f;
        hoeLevel = 0;
        hoeProgress = 0.0f;
        waterLevel = 0;
        waterProgress = 0.0f;
    }
}
