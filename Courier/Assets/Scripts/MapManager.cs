using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    
    public  int row ;
    public  int column ;
    public GameObject coin;
    
    public GameObject[,] tile;




    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        GameObject[] Founded_gameobjects =  GameObject.FindGameObjectsWithTag("Block");
        
        tile = new GameObject[row, column];

        for (int j = 0; j < column; j++)
        {

            for (int i = 0; i < row; i++)
            {
               
               

                for (int k = 0; k < Founded_gameobjects.Length; k++)
                {

                    if (Founded_gameobjects[k].transform.position.x == i && Founded_gameobjects[k].transform.position.y == j)
                    {
                        tile[i, j] = Founded_gameobjects[k];

                    }

                }
                    
                    



                    
            }

        }
        for (int j = 0; j < column; j++)
        {
            for (int i = 0; i < row; i++)
            {
                if (tile[i, j] == null)
                {
                    Instantiate(coin, new Vector3(i, j, 0), transform.rotation);
                    
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(tile[PlayerMove.Player_Move.playerpos_x, PlayerMove.Player_Move.playerpos_y]);
        //Debug.Log(tile[3, 0]);
    }
}
