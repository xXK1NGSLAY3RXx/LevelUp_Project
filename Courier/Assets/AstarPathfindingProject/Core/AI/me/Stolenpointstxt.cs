using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stolenpointstxt : MonoBehaviour
{
    public static Stolenpointstxt instance;
    public Text text;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance=this;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                text.enabled = false;
            }
        }
    }

    public void enableStolentxt(int amount)
    {
        text.color = Color.red;
        text.text = "- " + amount;
        text.enabled = true;
        timer = 3;
    }

    public void enableTakentxt(int amount)
    {
        text.color = Color.green;
        text.text = "+ " + amount;
        text.enabled = true;
        timer = 3;
    }

}

