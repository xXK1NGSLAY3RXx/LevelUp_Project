using UnityEngine;
using System.Collections;
using Pathfinding;

namespace Pathfinding
{
    public class SpawnerEnemy : MonoBehaviour
    {
        /// <summary>The object that the AI should move to</summary>

        //public float scatterTimer;
        //public float startChaseTimer;
       // public float chaseTimer;
        //public float startSpawnTimer;
        //public float spawnTimer;

        public GameObject player;
        public GameObject spawner;
        public Transform target;
        public Transform playerP;
        public Transform[] targets;
        int index;
        float t = 0.0f;
        public float timer;
        IAstarAI agent;
	
        void Awake()
        {
            agent = GetComponent<IAstarAI>();
        }


        public void tt()
        {
            t += Time.deltaTime;
            if (t - timer > 0.2f)
            {
                SpawnEnemy();
                t = 0;
            }
        }

        void SpawnEnemy()
        {
            Instantiate(spawner, transform.position , Quaternion.identity);
        }

        void MoveToWaypoint()
        {

            if (targets.Length == 0) return;

            bool search = false;

            // Check if the agent has reached the current target.
            // We must check for 'pathPending' because otherwise we might
            // detect that the agent has reached the *previous* target
            // because the new path has not been calculated yet.
            if (agent.reachedEndOfPath && !agent.pathPending)
            {
                index = index + 1;
                search = true;
            }

            // Wrap around to the start of the targets array if we have reached the end of it
            index = index % targets.Length;
            target = targets[index];
            agent.destination = target.position;

            // Immediately calculate a path to the target.
            // Note that this needs to be done after setting the destination.
            if (search) agent.SearchPath();
        }


        void MoveToPlayer()
        {

            bool search = false;

            // Check if the agent has reached the current target.
            // We must check for 'pathPending' because otherwise we might
            // detect that the agent has reached the *previous* target
            // because the new path has not been calculated yet.
            agent.destination = target.position;
            search = true;

            // Wrap around to the start of the targets array if we have reached the end of it

            target = playerP;
            agent.destination = target.position;

            // Immediately calculate a path to the target.
            // Note that this needs to be done after setting the destination.
            if (search) agent.SearchPath();
        }




        void Start()
        {
            //InvokeRepeating("SwitchToScatterState", 0.0f, scatterTimer);
            //InvokeRepeating("SwitchToChaseState", startChaseTimer, chaseTimer);
           // InvokeRepeating("SpawnEnemy", startSpawnTimer, spawnTimer);

            // _rigidbody2D = GetComponent<Rigidbody2D>();
            _state = State.scatter;

        }

        public enum State
        {
            scatter,
            chase,
            spawn
        }

        private State _state;

        void SwitchToSpawnState()
        {
            _state = State.spawn;
        }

        void SwitchToChaseState()
        {
            // LeaveScatter();
            _state = State.chase;
            // EnterChase();
        }

        void SwitchToScatterState()
        {
            // LeaveChase();
            _state = State.scatter;
            // EnterScatter();
        }


        void FixedUpdate()
        {

            tt();
            switch (_state)
            {
                case State.scatter:
                    UpdateScatter();
                    break;
                case State.chase:
                    UpdateChase();
                    break;
                case State.spawn:
                    UpdateSpawn();
                    break;
            }
        }

        // state - spawn: //

        // void EnterSpawn()
        // {


        // }


        void UpdateSpawn()
        {
           // SpawnEnemy();
        }

        // void LeaveSpawn()
        // {

        //  }


        // state - scatter: //
        // void EnterScatter()
        // {


        // }

        void UpdateScatter()
        {


            MoveToWaypoint();
        }

        // void LeaveScatter()
        // {

        //  }



        // state - chase: //

        //   void EnterChase()
        //  {

        //  }

        void UpdateChase()
        {

            MoveToPlayer();
        }

        // void LeaveChase()
        // {

        // }


        void OnTriggerEnter2D(Collider2D co)
        {
            if (co.name == "luarenz")
            {
                // PlayerInventory.instance.coinloss(collectables.coin);
                Debug.Log("hit");
                // Destroy(co.gameObject);
            }
        }


    }
}

