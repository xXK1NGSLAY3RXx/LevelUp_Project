using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Start is called before the first frame update
   
    private bool died;
    public bool Died
    {
        get
        {
            return died;
        }

        set
        {
           died = value;
        }

    }
    public int MaxHealth;
    public int starting_health;
    private int current_health;
    public int CurrentHealth
    {
        get
        {
            return current_health;
        }

        set
        {
           current_health = value;
        }
    }

    public float MaxSpeed ;
    public float starting_speed;
    private float current_speed;
    public float CurrentSpeed
    {
        get
        {
            return current_speed;
        }

        set
        {
            current_speed = value;
        }
    }





    private void Awake()
    {
       

        CurrentHealth = starting_health;
        CurrentSpeed = starting_speed;
    }

    private void Update()
    {
        //execute(Current_state);

        //if (CurrentHealth <= 0)
        //{
        //    die();
        //}


    }
       





}
