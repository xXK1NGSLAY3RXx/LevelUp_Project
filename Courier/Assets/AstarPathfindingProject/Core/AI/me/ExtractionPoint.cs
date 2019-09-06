using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractionPoint : MonoBehaviour
{
    public static ExtractionPoint instance;

    public float active_time;
    


    public GameObject[] powerups;
    public float Deposit_interval;
    public float score_per_extract;
    public float full_extraction_score;
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

        Debug.Log(current_value);
        if (active_time > 0)
        {
            active_time -= Time.deltaTime;
            if (active_time <= 0)
            {

                Destroy(gameObject);
            }

        }



        if (CanExtract == true )
        {
            period += Time.deltaTime;

            if (period > extraction_rate)
            {
                deposit();
                period = 0;

            }
            
            
        }
        
      
        
       
        
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

                         GameManager.instance.addscore(score_per_extract);
                         PlayerInventory.instance.CollectedCoins -= 1 * extraction_rate_miltiplier;
                         current_value += 1 * extraction_rate_miltiplier;

                            
                        }

                    


                }
            }
        }

        if (current_value == max_value)
        {
            GameManager.instance.addscore(full_extraction_score);
            Instantiate(powerups[Random.Range(0, powerups.Length)], transform.position, transform.rotation);
            GameManager.instance.ExtractedNum += 1;
            Destroy(gameObject);

        }
    }

    private void OnDestroy()
    {
        GetComponentInChildren<ExtractionUI>().disabletxt();
        //GetComponentInChildren<ExtractionUI>().disablebar();

        GameManager.instance.updateNumber();
    }
}
