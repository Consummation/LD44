using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "New Building")]
public class BuildingTemplate : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] [Multiline] private string description;
    [SerializeField] private int peopleCost;                    //цена для строительства
    [SerializeField] private int livesCost;                     //цена эксплуатации
    [SerializeField] private int moodPercentCost;               //изменение настроения
    [SerializeField] private int buildPoints;                   //цена в очках производства
    [SerializeField] private int peopleIncrement;               //прирост людей
    [SerializeField] private int productionIncrement;           //прирост производства
    [SerializeField] private Sprite icon;
    [SerializeField] private int id;
    [SerializeField] private int achievementPoints;
    [SerializeField] private string specialBonuses;
    [SerializeField] private AudioClip sound;
    
    public string Name
    {
        get
        {
            return name;
        }
    }
    public string Description
    {
        get
        {
            return description;
        }
    }
    public int PeopleCost
    {
        get
        {
            return peopleCost;
        }
    }
    public int LivesCost
    {
        get
        {
            return livesCost;
        }
    }
    public int MoodPercentCost
    {
        get
        {
            return moodPercentCost;
        }
    }
    public int BuildPoints
    {
        get
        {
            return buildPoints;
        }
    }
    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }

    public int Id
    {
        get { return id; }
    }

    public int PeopleIncrement
    {
        get { return peopleIncrement; }
        set { peopleIncrement = value; }
    }

    public int ProductionIncrement => productionIncrement;
    public int AchievementPoints
    {
        get { return achievementPoints; }
    }

    public string SpecialBonuses => specialBonuses;

    public AudioClip Sound => sound;
}
