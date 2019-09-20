using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //public GameObject EnemyType1;
    //private string EnemyType1_tag;
    //public GameObject EnemyType2;
    //private string EnemyType2_tag;
    //public GameObject EnemyType3;
    //private string EnemyType3_tag;
    //public GameObject EnemyType4;
    //private string EnemyType4_tag;
    public Queue<GameObject> enemies;
    
   
    
   
    // Start is called before the first frame update
    void Start()
    {
         EnemyType1_tag = EnemyType1.transform.tag;
         EnemyType2_tag = EnemyType2.transform.tag;
         EnemyType3_tag = EnemyType3.transform.tag;
         EnemyType4_tag = EnemyType4.transform.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(EnemyType1_tag);
        //Debug.Log(EnemyType2_tag);

    }
}
