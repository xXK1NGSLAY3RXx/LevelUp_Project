using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public static PlayerStats instance;

    private float State_active_time;
    public float safe_time;
    public SpriteRenderer firesprite;

    private int onfireState_damage_amount = 1;
    public float onfireState_takingdamage_interval;
    private float onfireState_takingdamage_interval_timer;


    private float bonus_speed;

    public float BonusSpeed
    {
        get
        {
            return bonus_speed;
        }

        set
        {
            bonus_speed = value;
        }
    }



    private int earned_points;
    public int EarnedPoints
    {
        get
        {
            return earned_points;
        }

        set
        {
            earned_points = value;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Current_state = States.normal;
        
            
    }

    // Update is called once per frame
    void Update()
    {
        execute(Current_state);

        //Debug.Log(Current_state);

       
    }

    public void Addspeed(float bonusspeed, float time)
    {
        CurrentSpeed += bonusspeed;
        PlayerMove.Player_Move.updatespeed();

        Invoke("SetBackSpeed", time);
        
    }

    private void SetBackSpeed()
    {
        CurrentSpeed = starting_speed ;
        PlayerMove.Player_Move.updatespeed();
    }



    public void Addhealth(int bonushealth)
    {
        if (CurrentHealth < MaxHealth)
        {
            CurrentHealth += bonushealth;
        }

    }
    public void takedamage(int damage)
    {
        if (Current_state == States.normal)
        {
            CurrentHealth -= damage;
            SwitchState(States.invulnerable, safe_time);


        }
        else if (Current_state == States.onfire)
        {
            CurrentHealth -= damage;
        }

            if (CurrentHealth <= 0)
            {
                die();
            }

        



    }

    public void die()
    {
        Died = true;
    }

    public enum States
    {
        normal, invulnerable,onfire
    }

    public States Current_state { get; private set; }

    public void SwitchState(States NewState, float active_time)
    {

        exit(Current_state);
        Current_state = NewState;
        enter(Current_state, active_time);


    }

    private void enter(States State, float time)
    {

        if (State == States.normal)
        {
            firesprite.enabled = false;
        }
        else if (State == States.invulnerable)
        {
            State_active_time = time;

        }
        else if (State == States.onfire)
        {
            State_active_time = time;
        }

    }

    private void exit(States State)
    {
        if (State == States.normal)
        {

        }
        else if (State == States.invulnerable)
        {

        }

    }

    public void execute(States State)
    {
        if (State == States.normal)
        {
           
        }
        else if (State == States.invulnerable)
        {

            if (State_active_time > 0)
            {
                State_active_time -= Time.deltaTime;

            }

            if (State_active_time <= 0)
            {
                SwitchState(States.normal, 0);
            }

        }
        else if (State == States.onfire)
        {

            if (State_active_time > 0)
            {
                firesprite.enabled = true;
                 State_active_time -= Time.deltaTime;
                if (onfireState_takingdamage_interval > 0)
                {
                    onfireState_takingdamage_interval_timer += Time.deltaTime;
                    if (onfireState_takingdamage_interval_timer >= onfireState_takingdamage_interval)
                    {
                        takedamage(onfireState_damage_amount);
                        onfireState_takingdamage_interval_timer = 0f;
                    }
                }

            }

            if (State_active_time <= 0)
            {
                
                SwitchState(States.normal, 0);
            }

        }


    }











}
