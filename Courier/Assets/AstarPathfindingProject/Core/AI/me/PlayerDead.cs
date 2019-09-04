using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    
    CharacterStats P;
    // Start is called before the first frame update
    void Start()
    {
        P = GetComponent<CharacterStats>();
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("KillerEnemy"))
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
