using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int MaxHealth = 3;
    public int CurrentHealth { get; private set; }

    public float MaxSpeed = 5;
    public float CurrentSpeed { get; private set; }





    private void Awake()
    {

        CurrentHealth = MaxHealth;
        CurrentSpeed = MaxSpeed;
    }

    private void Update()
    {
        
      


    }

    public void takedamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            die();
        }

   
    }

    public void die()
    {
        Debug.Log(transform.name + "Died");
    }
}
