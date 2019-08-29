using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractionPoint : MonoBehaviour
{
    public static ExtractionPoint instance;
    public int max_value;
    private int current_value;
    public int CurrentValue
    {
        get
        {
            return current_value;
        }

        set
        {
            current_value = value;
        }

    }
    public int deposit_limit_max;
    public int deposit_limit_min;
    private int collectable_points;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Extraction Site value =" + current_value);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))

            
        {
            
                deposit();

            


        }
    }

    public void deposit()
    {   collectable_points = max_value - current_value;
        if (current_value < max_value && max_value >= deposit_limit_max)
        {
        
            if (PlayerInventory.instance.CollectedCoins > deposit_limit_min)
            {
              
                if (collectable_points > 0 )
                {
                    for (int i = 0; i  < collectable_points; i ++)
                    {
                        if(PlayerInventory.instance.CollectedCoins > 0)
                        { 
                        PlayerInventory.instance.CollectedCoins -= 1;
                        current_value += 1;


                        }

                    }


                }
            }
        }   
    }
}
