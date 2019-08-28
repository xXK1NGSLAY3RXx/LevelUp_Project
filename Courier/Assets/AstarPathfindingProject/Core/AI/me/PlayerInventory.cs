using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    private int collected_coins;
    //use this in other scripts PlayerInventory.instance.collectedCoins
    public int CollectedCoins
    {
        get
        {
            return collected_coins;
        }

        set
        {
            collected_coins = value;
        }
    }
    
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
            CollectedCoins += 1;
        }
    }

    public void coinloss(collectables item)
    {
        if (item == collectables.coin)
        {
            CollectedCoins -= 1;
            EnemyInventory.instance.collecting();
        }
    }
}
