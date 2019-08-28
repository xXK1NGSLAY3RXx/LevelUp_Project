using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInventory : MonoBehaviour
{
    public static EnemyInventory instance;
    private int enemy_collected_coins;
    
    public int EnemyCollectedCoins
    {
        get
        {
            return enemy_collected_coins;
        }

        set
        {
            enemy_collected_coins = value;
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
    public void collecting()
    {
        
            EnemyCollectedCoins += 1;
        
    }

}
