using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphics : MonoBehaviour
{
    public Animator ball;
   
    public Animator larry;
    public static PlayerGraphics instance; 
    private float rotation;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
      
      
        

        if (PlayerMove.Player_Move.FaceDirection != Direction.empty)
        {
            larry.SetBool("IsMoving", true);
            ball.SetBool("IsMoving", true);

        }
        else
        {
            larry.SetBool("IsMoving", false);
            ball.SetBool("IsMoving", false);

        }

        ball.SetInteger("CollectedCoins", PlayerInventory.instance.CollectedCoins);

    }
    public void updatesprite()
    {
         if (PlayerMove.Player_Move.FaceDirection == Direction.up)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (PlayerMove.Player_Move.FaceDirection == Direction.right)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else if (PlayerMove.Player_Move.FaceDirection == Direction.left)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (PlayerMove.Player_Move.FaceDirection == Direction.down)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        
    }
    
}

