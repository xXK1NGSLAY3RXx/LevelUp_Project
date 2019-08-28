using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    public static ObjectInfo instance;
    public static Vector2 objectpos;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        objectpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
