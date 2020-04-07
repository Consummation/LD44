using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopParser : MonoBehaviour
{

    [SerializeField] private GameObject buildingPrefab;
    [SerializeField] private GameObject buttonsParent;

    public GameObject selectedBuilding;
    
    
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    
    public void ParsePage(BuildingTemplate[] buildings)
    {
        for (int i = 0; i < buttonsParent.transform.childCount; i++)
        {
            Destroy(buttonsParent.transform.GetChild(i).gameObject);
        }
        
        for (int i = 0; i < buildings.Length; i++)
        {
            var building = Instantiate(buildingPrefab, buttonsParent.transform);
            building.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = buildings[i].Name;
            building.GetComponent<ParseBuilding>().building = buildings[i];
            
            if(i==0)
                building.GetComponent<ParseBuilding>().Click();
        }
    }
}
