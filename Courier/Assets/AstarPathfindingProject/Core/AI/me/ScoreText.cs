using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text text;



    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.WinByScore == true)
        {
            text.text = "Score =" + " " + GameManager.instance.Score + " / " + GameManager.instance.Score_ToWin;
        }
        else
        text.text = "Score =" + " " + GameManager.instance.Score;
    }
    
}
