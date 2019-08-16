using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ssss");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collected");
            PlayerInventory.instance.collecting(collectables.coin);
            coindestroy();
            
            
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
    }


    private void coindestroy()
    {
        Destroy(gameObject);
    }
}
