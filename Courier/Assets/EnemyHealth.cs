using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyHealth : MonoBehaviour
{
    public int starting_health;
    private float current_health;
    public GameObject SpawnPoint;
    private Vector3 spawner_position;

    private void Start()
    {
        current_health = starting_health;
        spawner_position = SpawnPoint.transform.position;

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

    public void die()
    {
        GetComponent<KillerEnemy>().enabled = false;
        transform.position = spawner_position;
    }
}
