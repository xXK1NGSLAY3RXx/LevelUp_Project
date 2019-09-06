using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphics : MonoBehaviour
{
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
        
    }
    public void updatesprite()
    {
         if (PlayerMove.Player_Move.FaceDirection == Direction.up)
        {
            transform.eulerAngles = new Vector3(0, 0, -13);
        }
        else if (PlayerMove.Player_Move.FaceDirection == Direction.right)
        {
            transform.eulerAngles = new Vector3(0, 0, -106);
        }
        else if (PlayerMove.Player_Move.FaceDirection == Direction.left)
        {
            transform.eulerAngles = new Vector3(0, 0, 77);
        }
        else if (PlayerMove.Player_Move.FaceDirection == Direction.down)
        {
            transform.eulerAngles = new Vector3(0, 0, 167);
        }
        
    }
    
}

