using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    
    public  int row ;
    public  int column ;
    public GameObject coin;
    public GameObject Blank;
    
    public GameObject[,] tile;




    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        tilesaving();



        for (int j = 0; j < column; j++)
        {
            for (int i = 0; i < row; i++)
            {
                if (tile[i, j] == null)
                {
                    Instantiate(Blank, new Vector3(i, j, 0), transform.rotation);
                    Instantiate(coin, new Vector3(i, j, 0), transform.rotation);
                    
                }

            }
        }

        tilesaving();


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(tile[PlayerMove.Player_Move.playerpos_x, PlayerMove.Player_Move.playerpos_y]);
        Debug.Log(tile[1, 1]);
    }

    public void tilesaving()
    {
        GameObject[] Founded_gameobjects_1 = GameObject.FindGameObjectsWithTag("Block") ;
        GameObject[] Founded_gameobjects_2 = GameObject.FindGameObjectsWithTag("Blank");
        GameObject[] Founded_gameobjects = Founded_gameobjects_1.Concat(Founded_gameobjects_2).ToArray();


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
    }
}
