using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoseGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator LoseGame()
    {
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }
}
