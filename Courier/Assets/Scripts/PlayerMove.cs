using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Player_Move;
    private Collider2D player_collider;



    private Rigidbody2D RB;

    [SerializeField]
    private float Speed;
    [SerializeField]
    private float Base_Speed;

    
    private Direction face_direction ;

    public Direction FaceDirection
    {
        get
        {
            return face_direction;
        }

        set
        {
            face_direction = value;
        }
    }

    private Vector2 Player_Position;

    // Start is called before the first frame update
    void Start()
    {
        player_collider = GetComponent<CircleCollider2D>();
        face_direction = Direction.empty;
        Speed = Base_Speed;
        Player_Move = this;
        Player_Position = transform.position;
        RB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (face_direction != Direction.empty)
        {
            if (CheckCollision(FaceDirection))
             Stop();


        }
        Move(FaceDirection);

    }
   

    public void Move(Direction dir)
    {
        transform.position = (Vector2)transform.position + TookKit.DirectionToVector(dir) * Speed * Time.deltaTime;
        //transform.position = Player_Position;



    }
    

    public bool CheckCollision(Direction dir)
    {
        Vector2 trans = transform.position;
        //LayerMask mask = LayerMask.GetMask("Block");
        //var hit = new RaycastHit2D[10000];
        //ContactFilter2D filter = new ContactFilter2D() ;
        Vector2 dir_vector = TookKit.DirectionToVector(dir);
        //int hit_num = player_collider.Cast(dir_vector,filter,hit,0.1f);
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.47f, dir_vector,10,LayerMask.GetMask("Block"));
        
        if (hit.collider != null)
        {
            if (Vector2.Distance(transform.position, hit.point) < 0.55)
         
            {
                Debug.Log("hit");

                return true;
            }





        }
        return false;
    }

    public void Stop()
    {
        face_direction = Direction.empty;
    }
}


