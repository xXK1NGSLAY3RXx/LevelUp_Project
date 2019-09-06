using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpText : MonoBehaviour
{
    public Text text;
  

    // Update is called once per frame
    void Update()
    {
        text.text =   PlayerStats.instance.CurrentHealth.ToString() + " / " + PlayerStats.instance.MaxHealth.ToString();
        
    }
}
