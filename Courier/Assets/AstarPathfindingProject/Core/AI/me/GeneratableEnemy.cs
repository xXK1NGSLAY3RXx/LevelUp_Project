using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pathfinding
{
    public class GeneratableEnemy : MonoBehaviour
    {

        // public float scatterTimer;
        // public float startChaseTimer;
        //  public float chaseTimer;
        public GameObject P;
        public GameObject player;
        public Transform target;
       // public Transform playerP;
      //  public Transform[] targets;
      //  int index;

        IAstarAI agent;

        void Awake()
        {
            agent = GetComponent<IAstarAI>();
            if (P == null)
            {
                P = GameObject.FindWithTag("Player");
            }
        }


       /* void MoveToWaypoint()
        {

            if (targets.Length == 0) return;

            bool search = false;

            if (agent.reachedEndOfPath && !agent.pathPending)
            {
                index = index + 1;
                search = true;
            }

            index = index % targets.Length;
            target = targets[index];
            agent.destination = target.position;

            if (search) agent.SearchPath();
        }
*/
        void MoveToPlayer()
        {

            bool search = false;
     
            agent.destination = P.transform.position;
            search = true;

           // target = playerP;
          //  agent.destination = target.position;

            if (search) agent.SearchPath();
        }



        void rad()
        {
           
        }
        void Start()
        {
            //InvokeRepeating("SwitchToScatterState", 0.0f, scatterTimer);
            //InvokeRepeating("SwitchToChaseState", startChaseTimer, chaseTimer);

            // _rigidbody2D = GetComponent<Rigidbody2D>();
            _state = State.chase;

        }

        public enum State
        {
            scatter,
            chase
        }

        private State _state;

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
            switch (_state)
            {
                case State.scatter:
                    UpdateScatter();
                    break;
                case State.chase:
                    UpdateChase();
                    break;
            }
        }

        // state - scatter: //
        // void EnterScatter()
        // {


        // }

        void UpdateScatter()
        {

            //MoveToWaypoint();
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
