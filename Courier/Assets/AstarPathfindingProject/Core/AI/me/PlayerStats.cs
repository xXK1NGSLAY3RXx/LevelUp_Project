using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public static PlayerStats instance;

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
    }

    // Update is called once per frame
    void Update()
    {


        Debug.Log(CurrentSpeed);
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

    





}
