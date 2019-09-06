using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update

    private void Awake()
    {
        S();
    }
    void Start()
    {
        //S();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnE()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
    
    void S()
    {
        InvokeRepeating("SpawnE", 5.0f, 10.0f); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
