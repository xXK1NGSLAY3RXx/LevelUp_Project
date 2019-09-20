using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour
{
    private int bag_amount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void FillTheBag(int amount)
    {
        bag_amount = amount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInventory>().collecting(collectables.coin, bag_amount);
            Stolenpointstxt.instance.enableTakentxt(bag_amount);
            Destroy(gameObject);

        }
    }
}
