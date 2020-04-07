using UnityEngine;
using TMPro;

public class ToolTip : MonoBehaviour {

    public GameObject panel;
    
    private Vector3 pos;
    private TextMeshProUGUI tooltip;
    private GameObject tooltipPanel;

    private Canvas canvas;
    private Core core;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        core = FindObjectOfType<Core>();
    }

    public void ShowStats()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 300f;

        tooltipPanel = Instantiate(panel, new Vector2(pos.x,pos.y), Quaternion.identity, canvas.transform);
        tooltip = tooltipPanel.GetComponentInChildren<TextMeshProUGUI>();

        switch (gameObject.transform.name)
        {
            case "ArmyCollider":
                tooltip.text = "Армия: " + core.MilitaryPoints + "/100";
                break;
            case "ScienceCollider":
                tooltip.text = "Наука: " + core.SciencePoints + "/100";
                break;
            case "CultureCollider":
                tooltip.text = "Культура: " + core.CulturePoints + "/100";
                break;
        }

        //var canv = tooltipPanel.AddComponent<Canvas>();
        //canv.overrideSorting = true;
        //canv.sortingLayerName = "UI";
        //canv.sortingOrder = 12;
    }


    public void CloseStats()
    {
        Destroy(tooltipPanel);
    }

    private void Update()
    {
        if(tooltipPanel!=null)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 300f;
            tooltipPanel.transform.position = new Vector2(pos.x, pos.y);
        }
    }

}
