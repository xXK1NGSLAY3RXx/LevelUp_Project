using UnityEngine;
using System.Collections;
using Pathfinding;

namespace Pathfinding
{
    /// <summary>
    /// Sets the destination of an AI to the position of a specified object.
    /// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
    /// This component will then make the AI move towards the <see cref="target"/> set on this component.
    ///
    /// See: <see cref="Pathfinding.IAstarAI.destination"/>
    ///
    /// [Open online documentation to see images]
    /// </summary>
    [UniqueComponent(tag = "ai.destination")]
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
    public class AIDestinationSetter : VersionedMonoBehaviour
    {
        /// <summary>The object that the AI should move to</summary>

        public float scatterTimer;    
        public float startChaseTimer;
        public float chaseTimer;

        public GameObject player;
        public Transform target;
        public Transform playerP;
        public Transform[] targets;
        int index;

        IAstarAI agent;

        void  Awake()
        {
            agent = GetComponent<IAstarAI>();
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
            InvokeRepeating("SwitchToScatterState", 0.0f, scatterTimer);
            InvokeRepeating("SwitchToChaseState", startChaseTimer, chaseTimer);

            // _rigidbody2D = GetComponent<Rigidbody2D>();
            //_state = State.scatter;

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
