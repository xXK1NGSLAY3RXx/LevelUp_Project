using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            PlayerInventory.instance.collecting(collectables.coin,1);
            coindestroy();
            
            
        }
    }


    private void coindestroy()
    {
        Destroy(gameObject);
    }
}
