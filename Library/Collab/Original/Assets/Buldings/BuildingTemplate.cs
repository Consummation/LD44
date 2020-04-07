using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Buildings", order = 51)]
public class BuildingTemplate : ScriptableObject
{
    [SerializeField]
    private new string name;
    [SerializeField]
    [Multiline]
    private string description;
    [SerializeField]
    private int peopleCost;
    [SerializeField]
    private int livesCost;
    [SerializeField]
    private int moodPercentCost;
    [SerializeField]
    private int priority;
    [SerializeField]
    private int buildPoints;
    [SerializeField]
    private int peopleLives;
    [SerializeField]
    private Sprite icon;

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
    public int Priority
    {
        get
        {
            return priority;
        }
    }
    public int BuildPoints
    {
        get
        {
            return buildPoints;
        }
    }
    public int PeopleLives
    {
        get
        {
            return peopleLives;
        }
    }
    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }

}
