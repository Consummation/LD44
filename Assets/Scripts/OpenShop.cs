using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    [SerializeField] private GameObject feed;

    public BuildingTemplate[] buildings;

    public void Click()
    {
        feed.SetActive(true);
        feed.GetComponent<ShopParser>().ParsePage(buildings);
        FindObjectOfType<ShopClose>().CloseShop(gameObject);
    }
}
