using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
	//public GameObject o1;
	public float distanceTarget;
	//public bool distanceTrue;
	bool onetime = false;
    GameObject player;
	float t = 0.0f;
	public float timer;
	/*
	private void Awake()
    {
		//SpawnE();
		//S();
	}
    void Start()
    {
        //S();
    }
	*/
	void Update()
    {
		SpawnCheck();
		switch (_state)
		{
			case State.spawnarea:
				UpdateSpawn();
				break;
			case State.notspawnarea:
				UpdateNotspawn();
				break;		
		}
	}

	public enum State
	{
		spawnarea,
		notspawnarea,	
	}

	private State _state;

    /*
	void SwitchToSpawnareaState()
	{
		if (Vector2.Distance(transform.position, o1.transform.position) > distanceTarget)
		{
			_state = State.spawnarea;
		}
		
	}
    */
	/*void SwitchToNotspawnareaState()
	{
		if (Vector2.Distance(transform.position, o1.transform.position) < distanceTarget)
		{
			_state = State.notspawnarea;
		}
		
	}
    */
	void UpdateSpawn()
	{
        t += Time.deltaTime;
        if (t - timer > 0.2f)
        {
            onetime = true;
            t = 0;
        }
        if (onetime == true)
		{
			Instantiate(enemy, transform.position, Quaternion.identity);
			onetime = false;
			
		}
        
    }
	void UpdateNotspawn()
	{
        onetime = false;

    }

	
	 void SpawnCheck()
	{
        player = GameObject.FindGameObjectWithTag("Player");
		///float dist = Vector2.Distance(transform.position, o1.transform.position);
		if (Vector2.Distance(transform.position, player.transform.position) > distanceTarget)//dist - distanceTarget < 0.2f
		{
            _state = State.spawnarea;
        }
		else
		{
            _state = State.notspawnarea;
        }
		//Debug.Log("distance true is : " + distanceTrue);		
	}
	/*
    void SpawnE()
    { 
		//Debug.Log("distance true is : " + distanceTrue);
		if (distanceTrue == false)
		{
			if (!onetime)
			{
				Instantiate(enemy, transform.position, Quaternion.identity);
				onetime = true;
			}
			
		}
        
        //Destroy(gameObject);

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

	*/
}
