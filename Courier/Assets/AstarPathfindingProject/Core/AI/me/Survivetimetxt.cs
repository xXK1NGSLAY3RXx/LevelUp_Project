using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Survivetimetxt : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.winbysurviving == false)
        {
            text.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.winbysurviving == true)
        {
            text.text = "survive = " + Mathf.Round( GameManager.instance.SurviveTime_towin) + " Seconds";
        }
       
    }
}
