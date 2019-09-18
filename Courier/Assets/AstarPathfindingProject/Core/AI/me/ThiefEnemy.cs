using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ThiefEnemy : MonoBehaviour
{
    public static ThiefEnemy instance;
    public int max_bag_amount;
    public int stealing_amount;
    private bool empty_bag;
    private int bag_value;
    
    public int BagAmount
    {
        get
        {
            return bag_value;
        }

        set
        {
            bag_value = value;
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
        if (bag_value <= 0)
        {
            empty_bag = true;
        }
        else
        { empty_bag = false; }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))

        {
            Steal();
        }
    }
    public void Steal()
    {
        if(empty_bag && PlayerInventory.instance.CollectedCoins > stealing_amount && FindObjectOfType<PlayerStats>().Current_state == PlayerStats.States.normal )
        {
            BagAmount += stealing_amount;
            PlayerInventory.instance.coinloss(stealing_amount);
            
            
        }
            

        
    }

}
