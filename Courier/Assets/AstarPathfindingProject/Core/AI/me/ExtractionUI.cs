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
    private LineRenderer line;

    private int segments = 50;
    private float circle_Xradius ;
    private float circle_Yradius ;

    // Start is called before the first frame update
    void Start()
    {
        circle_Xradius = GetComponent<CircleCollider2D>().radius;
        circle_Yradius = GetComponent<CircleCollider2D>().radius;

        numbers = Instantiate(UI.GetComponentInChildren<Text>(), FindObjectOfType<Canvas>().transform).GetComponent<Text>();
        line = GetComponent<LineRenderer>();
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;
    }

    // Update is called once per frame
    void Update()
    {
        circle_Xradius = GetComponent<CircleCollider2D>().radius;
        circle_Yradius = GetComponent<CircleCollider2D>().radius;
        CreatePoints();

        currentValue = GetComponentInParent<ExtractionPoint>().CurrentValue;
        MaxValue = GetComponentInParent<ExtractionPoint>().max_value;

        numbers.text = currentValue.ToString() + " / " + MaxValue.ToString();
        numbers.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.5f, 0));
    }

    
    void CreatePoints()
    {
        float x;
        float y;

        float change = 2 * Mathf.PI / segments;
        float angle = change;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(angle) * circle_Xradius;
            y = Mathf.Cos(angle) * circle_Yradius;

            line.SetPosition(i, new Vector3(x, y , 0));

            angle += change;
        }
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
