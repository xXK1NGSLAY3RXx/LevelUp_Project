using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtractionUI : MonoBehaviour
{
    public GameObject UI;
    protected Text numbers;
    private int currentValue;
    private int MaxValue;
    // Start is called before the first frame update
    void Start()
    {
        
        numbers = Instantiate(UI.GetComponentInChildren<Text>(),FindObjectOfType<Canvas>().transform).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentValue = GetComponentInParent<ExtractionPoint>().CurrentValue;
        MaxValue = GetComponentInParent<ExtractionPoint>().max_value;

        numbers.text = currentValue.ToString() + " / " + MaxValue.ToString() ;
        numbers.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3 (0,0.5f,0));
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            numbers.enabled = true;
        }
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            numbers.enabled = false;
        }
    }

}
