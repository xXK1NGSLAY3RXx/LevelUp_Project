using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TargetSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
         GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectsWithTag("ExtractionSitetarget")[Random.Range(0,3)].transform;
    }
}
