using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Player_Move;
    private CircleCollider2D player_collider;
    private float radius;



    private Rigidbody2D RB;

    [SerializeField]
    private float Speed;
    [SerializeField]
    private float Base_Speed;

    private Direction input_direction;
    private Direction face_direction;

    public Direction InputDirection
    {
        get
        {
            return input_direction;
        }

        set
        {
            if (face_direction == Direction.empty)
                face_direction = value;
            else if(face_direction != value)
                input_direction = value;
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
        radius = player_collider.radius * transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputDirection != Direction.empty)
        {
            if (!CheckCollision(InputDirection))
            {
                face_direction = InputDirection;
                InputDirection = Direction.empty;
            }
        }

        if (face_direction != Direction.empty)
        {
            CalculateMovement();
        }

    }


    public void Move(Direction dir)
    {
        transform.position = (Vector2)transform.position + TookKit.DirectionToVector(dir) * Speed * Time.deltaTime;
        //transform.position = Player_Position;



    }


    public bool CheckCollision(Direction dir)
    {


        Vector2 dir_vector = TookKit.DirectionToVector(dir);

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, dir_vector, 0.1f, LayerMask.GetMask("Block"));

        Debug.DrawRay(transform.position, dir_vector);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    private void CalculateMovement()
    {

        Vector2 face_vector = TookKit.DirectionToVector(face_direction);
        float distance = Speed * Time.deltaTime;


        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, face_vector, distance, LayerMask.GetMask("Block"));
        if (hit.collider != null)
        {
            distance *= hit.fraction;
            distance -= 0.01f;
            Debug.Log(hit.collider);
            Stop();
        }

        transform.position += (Vector3)face_vector * distance;
    }

    public void Stop()
    {
        face_direction = Direction.empty;
    }
}


