using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialObjects;
    [SerializeField] [Multiline] private string[] tutorialTexts;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject tooltip;
    [SerializeField] private GameObject manager;
    private int iterations;

    
    void Start()
    {
        iterations = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (iterations < 5)
            StartCoroutine(TutorialCycle(iterations++));
            else
            {
                background.SetActive(false);
                var core = FindObjectOfType<Core>();
                core.StartCoroutine("HousesDelay");
                core.StartCoroutine("ProductionDelay");
                core.StartCoroutine("TimerCounter");
                Destroy(tooltip.gameObject);
                for (int i = 0; i < tutorialObjects.Length; i++)
                {
                    Destroy(tutorialObjects[i].GetComponent<Canvas>());
                }
                this.enabled = false;
            }
        }
    }

    private IEnumerator TutorialCycle(int i)
    {
        
        if(i <= 1)
            tooltip.GetComponent<RectTransform>().anchoredPosition = new Vector2(-190f, 156f);
        if(i == 2)
            tooltip.GetComponent<RectTransform>().anchoredPosition = new Vector2(-20f, 156f);
        if(i == 3)
            tooltip.GetComponent<RectTransform>().anchoredPosition = new Vector2(-111f, 130f);
        if(i == 4)
            tooltip.GetComponent<RectTransform>().anchoredPosition = new Vector2(-340f, -150f);
        
        tutorialObjects[i].GetComponent<Canvas>().sortingLayerID = 1;
        tutorialObjects[i].GetComponent<Canvas>().sortingOrder = 3;

        tooltip.GetComponentInChildren<TextMeshProUGUI>().text = tutorialTexts[i];
        
        for (int j = 0; j < 5; j++)
            if (j != i)
            {
                tutorialObjects[j].GetComponent<Canvas>().sortingLayerID = 0;
                tutorialObjects[j].GetComponent<Canvas>().sortingOrder = 1;
            }
        yield return null;   
    }
}
