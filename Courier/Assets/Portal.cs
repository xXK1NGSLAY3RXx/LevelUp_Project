using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int Portal_code;
    private float disable_timer = 0;
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        Debug.Log(disable_timer);
        if (disable_timer > 0)
        {
            disable_timer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("KillerEnemy") || other.CompareTag("ThiefEnemy") && disable_timer <= 0)
        {
            foreach (Portal PT in FindObjectsOfType<Portal>())
            {
                if (PT.Portal_code == Portal_code && PT != this)
                {
                    PT.disable_timer = 0.1f;
                    Vector3 portal_position = PT.gameObject.transform.position;
                    other.gameObject.transform.position = portal_position;
                }
            }
        }
        
    }
}
