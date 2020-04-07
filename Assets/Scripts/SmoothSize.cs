using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothSize : MonoBehaviour {


    private Vector3 defaultSize, targetSize;

    [SerializeField]
    private float multiplier;

    public void Start()
    {
        defaultSize = gameObject.GetComponent<RectTransform>().localScale;
        targetSize = defaultSize * multiplier;
    }

    public void Enter()
    {

        LeanTween.scale(gameObject.GetComponent<RectTransform>(), targetSize, 0.14f);
    }

    public void Exit()
    {

        LeanTween.scale(gameObject.GetComponent<RectTransform>(), defaultSize, 0.14f);

    }

}
