using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    
    PlayerStats P;
    // Start is called before the first frame update
    void Start()
    {
        P = GetComponent<PlayerStats>();
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("KillerEnemy") && GetComponent<PlayerStats>().Current_state == PlayerStats.States.normal)
        {
            P.takedamage(1);

            //Destroy(gameObject);
        }
    }
    

        // Update is called once per frame
        void Update()
       {
        
       }
}
