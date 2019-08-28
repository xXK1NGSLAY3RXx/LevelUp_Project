using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int MaxHealth = 3;
    public int CurrentHealth { get; private set; }

    public float MaxSpeed = 5;
    public float CurrentSpeed { get; private set; }

    public int playerpos_x;
    public int playerpos_y;
    public GameObject[,] current_tile;


    private void Awake()
    {

        CurrentHealth = MaxHealth;
        CurrentSpeed = MaxSpeed;
    }

    private void Update()
    {
        playerpos_x = Mathf.RoundToInt(transform.position.x);
        playerpos_y = Mathf.RoundToInt(transform.position.y);



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
