using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBuilding : MonoBehaviour
{
    
    public int id;
    public BuildingTemplate building;

    private Core core;

    private void Awake()
    {
        core = FindObjectOfType<Core>();
    }

    public void Add()
    {
        if (core.People >= building.PeopleCost && core.Production >= building.BuildPoints)
        {
            if (core.buildingsNumber[id] == 0)
            {
                UniqueEffect(id);
            }
            
            core.People -= building.PeopleCost;
            core.Production -= building.BuildPoints;
            if (building.Id >= 30 && building.Id <= 39)
                core.CulturePoints += building.AchievementPoints;
            if (building.Id >= 40 && building.Id <= 49)
                core.MilitaryPoints += building.AchievementPoints;
            core.buildingsNumber[id]++;
        }
        else
        {
            Debug.Log("недостаточно средств!");
        }
    }

    private void UniqueEffect(int id)
    {
        switch (id)        //НЕ СМЕЙТЕСЬ БЛЕАТЬ
        {
            case 21:
                core.SciencePoints += 10;
                break;
            case 30:
                core.Happiness += 10;
                break;
            case 31:
                core.CulturePoints += 10;
                break;
            case 41:
                core.MilitaryPoints += 10;
                break;
        }
    }
}
