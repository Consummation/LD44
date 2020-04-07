using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuyBuilding : MonoBehaviour
{
    
    public int id;
    public BuildingTemplate building;

    private Core core;

    private void Awake()
    {
        core = FindObjectOfType<Core>();
        core.CalculatePeopleIncome();
        core.CalculateProductionIncome();
        core.CalculateHappinessIncome();

        gameObject.AddComponent<AudioSource>();
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
            core.buildingsNumber[id]++;
            
            core.CalculatePeopleIncome();
            core.CalculateProductionIncome();
            core.CalculateHappinessIncome();

            GetComponent<AudioSource>().clip = building.Sound;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log("недостаточно средств!");
        }
        
        if (core.People < building.PeopleCost || core.Production < building.BuildPoints)
        {
            GetComponent<Image>().color = new Color(1,1,1,0.4f);
            GetComponentInChildren<TextMeshProUGUI>().color = new Color(0,0,0,0.4f);
            GetComponent<EventTrigger>().enabled = false;
        }
        else
        {
            GetComponent<Image>().color = new Color(1,1,1,1);
            GetComponentInChildren<TextMeshProUGUI>().color = new Color(0,0,0,1);
            GetComponent<EventTrigger>().enabled = true;
        }
    }

    private void UniqueEffect(int id)
    {
        switch (id)        //НЕ СМЕЙТЕСЬ БЛЕАТЬ
        {
            case 20:
                core.buildings[31].PeopleIncrement += 100;
                break;
            case 21:
                core.SciencePoints += 10;
                break;
            case 30:
                core.Happiness += 10;
                break;
            case 31:
                core.CulturePoints += 10;
                break;
            case 40:
                core.HappinessLimit -= 40;
                break;
            case 41:
                core.MilitaryPoints += 10;
                break;
        }
    }
}
