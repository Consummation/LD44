using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Endgame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Endgame()
    {
        yield return new WaitForSeconds(15f);
        Application.Quit();
    }
}
