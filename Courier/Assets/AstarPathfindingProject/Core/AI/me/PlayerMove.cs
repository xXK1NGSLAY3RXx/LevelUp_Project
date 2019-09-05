using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Player_Move;
    private CircleCollider2D player_collider;
    private float radius;
    private PlayerStats stats;

    private GameObject[,] currenttile;

    private int f_X = 0;
    private int f_Y = 0;
    private int i_X = 0;
    private int i_Y = 0;
    

    private int playerpos_x;
    public int PlayerPosX
    {
        get
        {
            return playerpos_x;
        }

        set
        {

            playerpos_x = value;
        }
    }
    private int playerpos_y;
    public int PlayerPosY
    {
        get
        {
            return playerpos_y;
        }

        set
        {

            playerpos_y = value;
        }
    }





    private float Speed;
   

    private Direction input_direction;
    private Direction face_direction;
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

    public Direction InputDirection
    {
        get
        {
            return input_direction;
        }

        set
        {
            
                input_direction = value;
        }
    }

   

    // Start is called before the first frame update
    void Start()
    {
        Player_Move = this;
        stats = GetComponent<PlayerStats>();

        updatespeed();
        face_direction = Direction.empty;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        DirectionHandle();
        currenttile = MapManager.instance.tile;

        if (f_X == 1)
        {
           
            playerpos_x = Mathf.RoundToInt(transform.position.x - 0.4f);
        }
        else if (f_X == -1)
        {
            playerpos_x = Mathf.RoundToInt(transform.position.x + 0.4f);
        }
        else if (f_X == 0)
        {
            playerpos_x = Mathf.RoundToInt(transform.position.x);
        }

        if (f_Y == 1)
        {
            playerpos_y = Mathf.RoundToInt(transform.position.y - 0.4f);
        }
        else if (f_Y == -1)
        {
            playerpos_y = Mathf.RoundToInt(transform.position.y + 0.4f);

        }
        else if (f_Y == 0)
        {
            playerpos_y = Mathf.RoundToInt(transform.position.y);
        }
        



        if (InputDirection != Direction.empty)
        {
            if (currenttile[playerpos_x, playerpos_y].CompareTag("Blank"))
            {

                if (currenttile[playerpos_x + i_X, playerpos_y + i_Y].CompareTag("Blank"))
                {
                    
                    face_direction = InputDirection;
                    PlayerGraphics.instance.updatesprite();
                    
                }

            }
        }


        if (currenttile[playerpos_x, playerpos_y].CompareTag("Blank"))
        {
            if (currenttile[playerpos_x + f_X , playerpos_y + f_Y ].CompareTag("Block"))
            {
                Stop();
            }
            else { Move(face_direction); }

        }


        //if (InputDirection != Direction.empty)
        //{
        //    if (!CheckCollision(InputDirection))
        //    {
        //        face_direction = InputDirection;
        //        InputDirection = Direction.empty;
        //    }
        //}

        //if (face_direction != Direction.empty)
        //{
        //    CalculateMovement();
        //}

    }


    public void Move(Direction dir)
    {
        transform.position = (Vector2)transform.position + TookKit.DirectionToVector(dir) * Speed * Time.deltaTime;
    }

    public void DirectionHandle()
    {
        if (face_direction == Direction.left)
        {
            f_X = -1; f_Y = 0;
        }
        else if (face_direction == Direction.up)
        {
            f_X = 0; f_Y = 1;
        }
        else if (face_direction == Direction.right)
        {
            f_X = 1; f_Y = 0;
        }
        else if (face_direction == Direction.down)
        {
            f_X = 0; f_Y = -1;
        }
        else
        {
            f_X = 0; f_Y = 0;
        }

        if (InputDirection == Direction.left)
        {
            i_X = -1; i_Y = 0;
        }
        else if (InputDirection == Direction.up)
        {
            i_X = 0; i_Y = 1;
        }
        else if (InputDirection == Direction.right)
        {
            i_X = 1; i_Y = 0;
        }
        else if (InputDirection == Direction.down)
        {
            i_X = 0; i_Y = -1;
        }
        else if (InputDirection == Direction.empty)
        {
            i_X = 0;
            i_Y = 0;
        }
        
    }

    public void updatespeed()
    {
        Speed = stats.CurrentSpeed;
    }

    //public bool CheckCollision(Direction dir)
    //{


    //    Vector2 dir_vector = TookKit.DirectionToVector(dir);

    //    RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, dir_vector, 0.1f, LayerMask.GetMask("Block"));

    //    Debug.DrawRay(transform.position, dir_vector);
    //    if (hit.collider != null)
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    //private void CalculateMovement()
    //{

    //    Vector2 face_vector = TookKit.DirectionToVector(face_direction);
    //    float distance = Speed * Time.deltaTime;


    //    RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, face_vector, distance, LayerMask.GetMask("Block"));
    //    if (hit.collider != null)
    //    {
    //        distance *= hit.fraction;
    //        distance -= 0.01f;
    //        Debug.Log(hit.collider);
    //        Stop();
    //    }

    //    transform.position += (Vector3)face_vector * distance;
    //}

    public void Stop()
    {
        
        face_direction = Direction.empty;
    }
}


