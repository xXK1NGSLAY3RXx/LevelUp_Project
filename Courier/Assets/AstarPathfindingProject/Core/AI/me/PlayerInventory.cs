using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    
   
    
    private GameObject collected_powerup;
    public GameObject CollectedPowerup
    {
        get
        {
            return collected_powerup;
        }

        set
        {
            collected_powerup = value;
        }

    }
    
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
    public void collecting(collectables item ,int amount)
    {
        if (item == collectables.coin)
        {
            CollectedCoins += amount;
           
        }
    }

    public void coinloss(int Value)
    {
        CollectedCoins -= Value;
      
    }

    public void UsingPowerup()
    {
        if (collected_powerup != null)
        {
          
         
                Instantiate(collected_powerup, new Vector3(PlayerMove.Player_Move.PlayerPosX, PlayerMove.Player_Move.PlayerPosY, 0), transform.rotation);
                AstarPath.active.Scan();
                collected_powerup = null;
            

        }
    }
}
