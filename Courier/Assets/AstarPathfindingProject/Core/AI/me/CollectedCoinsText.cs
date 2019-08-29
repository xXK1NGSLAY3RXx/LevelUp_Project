using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedCoinsText : MonoBehaviour
{
    public Text text;
   
    void Update()
    {
        text.text =  "X" + " " + PlayerInventory.instance.CollectedCoins.ToString();
    }
}
