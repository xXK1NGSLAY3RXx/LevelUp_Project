using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    private int collected_coins;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(collected_coins);
        
    }
    public void collecting(collectables item)
    {
        if (item == collectables.coin)
        {
            collected_coins += 1;
        }
    }

}
