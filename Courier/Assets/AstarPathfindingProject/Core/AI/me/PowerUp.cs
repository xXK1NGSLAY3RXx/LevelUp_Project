using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PowerUp : MonoBehaviour
{
    public bool speed_powerup;
    public float bonus_speed;
    public float active_time;

    private float timer;
    

    public bool magic_block;
    //public int MB_count;
    public GameObject MagicBlock_prefab;

    public bool Fire_bug;
    public float FireBug_duration;

    public bool health_Pickup;
    public int bonus_hp;

    

    
 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (speed_powerup)
            {

                PickedUp(PowerUps.speed_powerup);
            }
            else if (magic_block)
            {

                PickedUp(PowerUps.Magic_block);
            }
            else if (health_Pickup)
            {
                PickedUp(PowerUps.health_pickup);
            }
            else if (Fire_bug)
            {
                PickedUp(PowerUps.fire_bug);
                
            }
        }
        
    }

    private void PickedUp(PowerUps type)
    {
        if (type == PowerUps.speed_powerup)
        {
            PlayerStats.instance.Addspeed(bonus_speed, active_time);

        }

        else if (type == PowerUps.health_pickup)
        {
            PlayerStats.instance.Addhealth(bonus_hp);
        }

        else if (type == PowerUps.Magic_block)
        {
            PlayerInventory.instance.CollectedPowerup = MagicBlock_prefab;

        }
        else if (type == PowerUps.fire_bug)
        {
           
            FindObjectOfType<PlayerStats>().SwitchState(PlayerStats.States.onfire, FireBug_duration);

        }

        Destroy(gameObject);
    }
}
