using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyHealth : MonoBehaviour
{
    public bool Iskiller;
    public bool IsThief;
    public bool IsSpawner;

    public bool can_respawn = false;
    public int starting_health;
    private float current_health;
    private float NextSpawnTimer;
    public float FreezeTime;
    public int KillingScore;
    
    public GameObject SpawnPoint;
    public GameObject bloodstain;
    private Vector3 spawner_position;
    

    private void Start()
    {
        current_health = starting_health;
        spawner_position = SpawnPoint.transform.position;

    }
    private void Update()
    {
        Debug.Log(NextSpawnTimer);
        if (NextSpawnTimer > 0)
        {
            NextSpawnTimer -= Time.deltaTime;

            disablecomponents();
          
           
           
           
        }
        if (NextSpawnTimer <= 0)
        {
            enablecomponent();

        }
            
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerStats>().Current_state == PlayerStats.States.onfire)
        {
            takedamage(1);
        }

    }

    public void takedamage(int amount)
    {
       
        current_health -= amount;
        if (current_health <= 0)
        {
            die();
        }

    }
    public void freeze(float time)
    {
        NextSpawnTimer = time;
    }

    public void die()
    {
        GameManager.instance.addscore(KillingScore);
        Instantiate(bloodstain, transform.position, transform.rotation);
        if (can_respawn == true)
        {
           GameObject clone = Instantiate(gameObject, spawner_position, new Quaternion(0, 0, 0, 0));
           clone.GetComponent<EnemyHealth>().freeze(FreezeTime);

        }

        Destroy(gameObject);
    }

    private void disablecomponents()
    {
        if (Iskiller == true)
        {
            GetComponent<KillerEnemy>().enabled = false;

        }
        else if(IsThief == true)
        {
            GetComponent<AIDestinationSetter>().enabled = false;

        }
        
       
        SpawnPoint.GetComponent<SpriteRenderer>().enabled = true;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void enablecomponent()
    {
        SpawnPoint.GetComponent<SpriteRenderer>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
      
        if (Iskiller == true)
        {
            GetComponent<KillerEnemy>().enabled = true;

        }
        else if (IsThief == true)
        {
            GetComponent<AIDestinationSetter>().enabled = true;

        }
       
    }
}

