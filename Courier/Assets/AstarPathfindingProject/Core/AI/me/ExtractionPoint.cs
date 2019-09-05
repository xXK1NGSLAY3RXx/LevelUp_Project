using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractionPoint : MonoBehaviour
{
    public static ExtractionPoint instance;
    public float Deposit_interval;
    public int extraction_rate_miltiplier;
    public float extraction_rate;
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

    private float period;
    private bool CanExtract;
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



        if (CanExtract == true )
        {
            period += Time.deltaTime;

            if (period > extraction_rate)
            {
                deposit();
                period = 0;

            }
            
            
        }
        
      
        Debug.Log("Extraction Site value =" + current_value);
       
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))

            
        {

            CanExtract = true;

            


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))


        {

            CanExtract = false;




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
                    
                        if(PlayerInventory.instance.CollectedCoins > 0)
                        {
                        PlayerInventory.instance.CollectedCoins -= 1 * extraction_rate_miltiplier;
                        current_value += 1 * extraction_rate_miltiplier;

                            
                        }

                    


                }
            }
        }   
    }
}
