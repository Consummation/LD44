using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopClose : MonoBehaviour
{
    public GameObject lastButton;
    public GameObject feed;

    public void CloseShop(GameObject button)
    {
        if (button == lastButton)
        {
            lastButton = null;
            FindObjectOfType<ShopParser>().selectedBuilding = null;
            feed.SetActive(false);
        }
        else
            lastButton = button;
    }
}
