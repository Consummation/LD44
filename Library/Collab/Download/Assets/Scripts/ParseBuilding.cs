using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ParseBuilding : MonoBehaviour
{

    [SerializeField] private GameObject icon;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI characteristics;
    [SerializeField] private TextMeshProUGUI peoplePrice;
    [SerializeField] private TextMeshProUGUI productionPrice;
    [SerializeField] private BuyBuilding buyButton;

    private Core core;

    public BuildingTemplate building;


    private void Awake()
    {
        core = FindObjectOfType<Core>();
    }

    public void Click()
    {
        FindObjectOfType<ShopParser>().selectedBuilding = gameObject;
        
        icon = transform.parent.parent.GetChild(1).GetChild(0).gameObject;
        name = transform.parent.parent.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        description = transform.parent.parent.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
        characteristics = transform.parent.parent.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>();
        buyButton = transform.parent.parent.GetChild(2).GetChild(3).GetComponent<BuyBuilding>();
        peoplePrice = transform.parent.parent.GetChild(2).GetChild(4).GetChild(2).GetComponent<TextMeshProUGUI>();
        productionPrice = transform.parent.parent.GetChild(2).GetChild(5).GetChild(2).GetComponent<TextMeshProUGUI>();


        buyButton.id = building.Id;
        buyButton.building = building;
        
        UpdateAvailability();

        if (building.Icon != null)
        {
            icon.GetComponent<Image>().enabled = true;
            icon.GetComponent<Image>().sprite = building.Icon;
            icon.GetComponent<Image>().preserveAspect = true;
        }


        name.text = building.Name;
        characteristics.text = "";
        
        description.text = building.Description;
        peoplePrice.text = building.PeopleCost.ToString();
        
        productionPrice.text = building.BuildPoints.ToString();
        if (building.LivesCost != 0)
            characteristics.text += "\nОбслуживание: <color=#b70707>" + building.LivesCost + "<color=#000000> людей/смену";
        if(building.ProductionIncrement != 0)
            characteristics.text += "\nОчков производства: <color=#48931d>" + building.ProductionIncrement + "<color=#000000>/смену";
        if (building.MoodPercentCost > 0)
            characteristics.text += "\nМодификатор счастья: <color=#48931d>" + building.MoodPercentCost + "<color=#000000>";
        if (building.MoodPercentCost < 0)
            characteristics.text += "\nМодификатор счастья: <color=#b70707>" + building.MoodPercentCost + "<color=#000000>";
        if(building.PeopleIncrement != 0)
            characteristics.text += "\nПрирост людей: <color=#48931d>" + building.PeopleIncrement + "<color=#000000> +-10%";
        if (building.AchievementPoints != 0)
        {
            if (building.Id >= 20 && building.Id <= 29)
                characteristics.text += "\n\nОчки науки: <color=#48931d>" + building.AchievementPoints + "<color=#000000>/смену";
            if (building.Id >= 30 && building.Id <= 39)
                characteristics.text += "\n\nОчки культуры: <color=#48931d>" + building.AchievementPoints + "<color=#000000>/смену";
            if (building.Id >= 40 && building.Id <= 49)
                characteristics.text += "\n\nОчки армии: <color=#48931d>" + building.AchievementPoints + "<color=#000000>/смену";
        }
    }

    public void UpdateAvailability()
    {
        if (core.People < building.PeopleCost || core.Production < building.BuildPoints)
        {
            buyButton.GetComponent<Image>().color = new Color(1,1,1,0.4f);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0,0,0,0.4f);
            buyButton.GetComponent<EventTrigger>().enabled = false;
        }
        else
        {
            buyButton.GetComponent<Image>().color = new Color(1,1,1,1);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0,0,0,1);
            buyButton.GetComponent<EventTrigger>().enabled = true;
        }

        if (core.People < building.PeopleCost)
        {
            peoplePrice.transform.parent.GetChild(2).GetComponent<TextMeshProUGUI>().color = new Color(1,0,0,0.4f);
        }
        else
        {
            peoplePrice.transform.parent.GetChild(2).GetComponent<TextMeshProUGUI>().color = new Color(0,0,0,1);
        }

        if (core.Production < building.BuildPoints)
        {
            productionPrice.transform.parent.GetChild(2).GetComponent<TextMeshProUGUI>().color = new Color(1,0,0,0.4f);
        }
        else
        {
            productionPrice.transform.parent.GetChild(2).GetComponent<TextMeshProUGUI>().color = new Color(0,0,0,1);
        }
    }
}
