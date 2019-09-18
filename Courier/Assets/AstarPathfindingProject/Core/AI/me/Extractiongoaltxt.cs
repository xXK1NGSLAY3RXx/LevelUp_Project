using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Extractiongoaltxt : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.WinByExtractions == false)
        {
            text.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.WinByExtractions == true)
        {
            text.text = "Extractions = " + GameManager.instance.ExtractedNum + " / " + GameManager.instance.Extractions_ToWin;
        }
       
        
    }
}
