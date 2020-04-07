using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Core : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI peopleCounter;
    [SerializeField] private TextMeshProUGUI peopleCounterIncome;
    [SerializeField] private TextMeshProUGUI productionCounter;
    [SerializeField] private TextMeshProUGUI productionCounterIncome;
    [SerializeField] private TextMeshProUGUI happinessCounter;
    [SerializeField] private TextMeshProUGUI happinessCounterIncome;
    [SerializeField] private TextMeshProUGUI timerCounter;
    [SerializeField] private Sprite happy, unhappy;
    [SerializeField] private Image happyIcon;

    [SerializeField] private RectTransform armyLine, scienceLine, cultureLine;
    
    public BuildingTemplate[] buildings;

    public int[] buildingsNumber;
    //0-9     - жилые дома        (0 - хата, 1 - коммуналка)
    //10-19   - производство      (10 - завод, 11 - тес)
    //20-29   - наука             (20 - лаборатория, 21 - библиотека)
    //30-39   - культура          (30 - кино, 31 - больница)
    //40-49   - армия             (40 - бараки, 41 - военный лагерь)
    
    private int people;
    private int production;
    private int happiness;
    private int sciencePoints;
    private int militaryPoints;
    private int culturePoints;
    private int timer;

    private int happinessLimit;
    private float productionKoef;

    #region properties

    public int People{
        get{return people;}
        set
        {
            people = value;
            peopleCounter.text = People.ToString();
            if(FindObjectOfType<ShopParser>() != null)
                FindObjectOfType<ShopParser>().selectedBuilding.GetComponent<ParseBuilding>().UpdateAvailability();
        }
    }

    public int Production{
        get{return production;}
        set
        {
            production = value;
            productionCounter.text = Production.ToString();
            if(FindObjectOfType<ShopParser>() != null)
                FindObjectOfType<ShopParser>().selectedBuilding.GetComponent<ParseBuilding>().UpdateAvailability();
        }
    }

    public int Happiness
    {
        get { return happiness; }
        set
        {
            happiness = value;
            if (happiness > 100)
                happiness = 100;
            if (happiness < HappinessLimit)
            {
                productionKoef = 0.5f;
                happyIcon.sprite = unhappy;
            }
            else
            {
                productionKoef = 1f;
                happyIcon.sprite = happy;
            }

            happinessCounter.text = Happiness.ToString();
        }
    }

    public int Timer
    {
        get { return timer; }
        set
        {
            timer = value;
            timerCounter.text = Timer.ToString();
        }
    }

    public int SciencePoints
    {
        get { return sciencePoints; }
        set
        {
            sciencePoints = value;
            scienceLine.sizeDelta = new Vector2(3.68f * sciencePoints, 90);
        }
    }

    public int MilitaryPoints
    {
        get { return militaryPoints; }
        set
        {
            militaryPoints = value;
            armyLine.sizeDelta = new Vector2(3.68f * militaryPoints, 90);
        }
    }

    public int CulturePoints
    {
        get { return culturePoints; }
        set
        {
            culturePoints = value;
            cultureLine.sizeDelta = new Vector2(3.68f * culturePoints, 90);
        }
    }

    public int HappinessLimit
    {
        get { return happinessLimit; }
        set { happinessLimit = value; }
    }

    #endregion
    
    void Start()
    {
        SciencePoints = 0;
        CulturePoints = 0;
        MilitaryPoints = 0;
        
        People = 10000;
        Production = 100;
        Happiness = 100;
        HappinessLimit = 50;
        Timer = 0;
    }

    public void CalculatePeopleIncome()
    {
        int peopleIncome = 0;
        for (int i = 0; i < 10; i++)
        {
            if(buildings[i] == null)
                break;
            peopleIncome += buildings[i].PeopleIncrement * buildingsNumber[i];
        }
        for (int i = 10; i < 20; i++)                                                                      
        {
            if(buildings[i] == null)
                break;
            peopleIncome -= buildings[i].LivesCost * buildingsNumber[i];
        }
        for (int i = 40; i < 50; i++)                                                                     
        {
            if (buildings[i] == null)
                break;    
            peopleIncome -= buildings[i].LivesCost * buildingsNumber[i];
        }
        
        if (peopleIncome > 0)
            peopleCounterIncome.text = "<color=#48931d>+" + peopleIncome;
        else 
            peopleCounterIncome.text = "<color=#b70707>" + peopleIncome;
    }

    public void CalculateProductionIncome()
    {
        int productionIncome = 0;
        for (int i = 10; i < 20; i++)
        {
            if(buildings[i] == null)
                break;
            productionIncome += buildings[i].ProductionIncrement * buildingsNumber[i];
        }

        productionIncome = Mathf.RoundToInt(productionKoef * productionIncome);
        
        if (productionIncome > 0)
            productionCounterIncome.text = "<color=#48931d>+" + productionIncome;
        else 
            productionCounterIncome.text = "<color=#b70707>" + productionIncome;
    }

    public void CalculateHappinessIncome()
    {
        int happinessIncome = -7;
        for (int i = 10; i < 50; i++)
        {
            if(buildings[i] == null)
                break;
            happinessIncome += buildings[i].MoodPercentCost * buildingsNumber[i];
        }
        
        if (happinessIncome > 0)
            happinessCounterIncome.text = "<color=#48931d>+" + happinessIncome;
        else 
            happinessCounterIncome.text = "<color=#b70707>" + happinessIncome;
    }
    
    private IEnumerator TimerCounter()
    {
        yield return new WaitForSeconds(1f);
        Timer++;
        StartCoroutine(TimerCounter());
    }

    private IEnumerator HousesDelay()
    {
        yield return new WaitForSeconds(10f);
        for (int i = 0; i < 10; i++)
        {
            if(buildings[i] == null)
                break;
            var percentage = Mathf.RoundToInt(0.1f * buildings[i].PeopleIncrement);
            People += Random.Range(buildings[i].PeopleIncrement - percentage, buildings[i].PeopleIncrement + percentage)  * buildingsNumber[i];
        }
        StartCoroutine(HousesDelay());
    }

    private IEnumerator ProductionDelay()
    {
        yield return new WaitForSeconds(20f);

        Happiness -= 7;
        
        for (int i = 10; i < 20; i++)                                                                        //жилье
        {
            if(buildings[i] == null)
                break;
            People -= buildings[i].LivesCost * buildingsNumber[i];
            Happiness += buildings[i].MoodPercentCost * buildingsNumber[i];
            Production +=  Mathf.RoundToInt((buildings[i].ProductionIncrement * buildingsNumber[i])*productionKoef);
        }

        for (int i = 20; i < 30; i++)                                                                       //наука
        {
            if(buildings[i] == null)
                break;
            SciencePoints += buildings[i].AchievementPoints * buildingsNumber[i];
            Happiness += buildings[i].MoodPercentCost * buildingsNumber[i];
        }
        for (int i = 40; i < 50; i++)                                                                       //армия
        {
            if (buildings[i] == null)
                break;    
            MilitaryPoints += buildings[i].AchievementPoints * buildingsNumber[i];
            People -= buildings[i].LivesCost * buildingsNumber[i];
            Happiness += buildings[i].MoodPercentCost * buildingsNumber[i];
        }
        if (MilitaryPoints >= 100 && SciencePoints >= 100 && CulturePoints >= 100)
            SceneManager.LoadScene("victory");
        StartCoroutine(ProductionDelay());
    }
}
