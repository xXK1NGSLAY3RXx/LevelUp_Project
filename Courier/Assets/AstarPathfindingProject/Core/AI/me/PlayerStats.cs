using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public static PlayerStats instance;

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
        

       


}
