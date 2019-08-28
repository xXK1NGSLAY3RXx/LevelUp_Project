using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerMove.Player_Move.InputDirection = Direction.left;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerMove.Player_Move.InputDirection = Direction.right;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerMove.Player_Move.InputDirection = Direction.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerMove.Player_Move.InputDirection = Direction.down;
        }



    }
}
