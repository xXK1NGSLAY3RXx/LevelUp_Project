using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    //private Rigidbody2D _rigidbody2D;
    //public Transform[] waypoints;
    public GameObject player;
    //int cur;
    //public float speed = 0.3f;
    //public float sightDistance;
    //public LayerMask sightLayers;


    public enum State
    {
        scatter,
        chase
    }

    private State _state;

    void SwitchToChaseState()
    {
        LeaveScatter();
        _state = State.chase;
        EnterChase();
    }

    void SwitchToScatterState()
    {
        LeaveChase();
        _state = State.scatter;
        EnterScatter();
    }

    void Start()
    {
        InvokeRepeating("SwitchToScatterState", 0.0f, 5.0f);
        InvokeRepeating("SwitchToChaseState", 5.0f, 10.0f);

        // _rigidbody2D = GetComponent<Rigidbody2D>();
        _state = State.scatter;
       
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
    void EnterScatter()
    {
    }

    void UpdateScatter()
    {

        //if (PlayerInSight())
        //{
            //SwitchToChaseState();
       // }

       // MoveToWaypoint();
    }

    void LeaveScatter()
    {
    }

    // state - chase: //

    void EnterChase()
    {
    }

    void UpdateChase()
    {
       // MoveToWaypoint();
    }

   /* void MoveToWaypoint()
    {
        // Waypoint not reached yet? then move closer
        if (Vector2.Distance(transform.position, waypoints[cur].position) > 0.1f)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            _rigidbody2D.MovePosition(p);
        }
        // Waypoint reached, select next one
        else
            SelectNextWayPoint();
    }
    */
    void LeaveChase()
    {
    }

    /*void SelectNextWayPoint()
    {
        // change this line, select next point using a* algorithm
        cur = (cur + 1) % waypoints.Length;
    }
    */
    /*
    bool PlayerInSight()
    {
        Vector2 direction = player.transform.position - transform.position;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, sightDistance, sightLayers);
        Debug.DrawRay(transform.position, direction);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }
    */
    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "luarenz")
        {
            PlayerInventory.instance.coinloss(collectables.coin);
            Debug.Log("hit");
           // Destroy(co.gameObject);
        }
    }
}