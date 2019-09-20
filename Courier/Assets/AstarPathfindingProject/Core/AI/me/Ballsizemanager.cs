using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballsizemanager : MonoBehaviour
{
    public static Ballsizemanager instance;
    [Range(1, 2)]
    private float ball_extra_size;
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
       
        Debug.Log( scale.x);
        ball_extra_size = 1 + (float)PlayerInventory.instance.CollectedCoins / 100f;
        updatescale();
       
    }

    public void updatescale()
    {
        transform.localScale = new Vector3(1 * ball_extra_size, 1 * ball_extra_size, 0);
      
    }
}
