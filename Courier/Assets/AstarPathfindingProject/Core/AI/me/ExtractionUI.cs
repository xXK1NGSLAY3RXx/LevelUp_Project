using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtractionUI : MonoBehaviour
{
    public static ExtractionUI instance;
    public GameObject UI;
    protected Text numbers;
    protected Scrollbar bar;
    private int currentValue;
    private int MaxValue;
    private LineRenderer line;

    private float active_time;
    private int segments = 50;
    private float circle_Xradius ;
    private float circle_Yradius ;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        circle_Xradius = GetComponentInParent<CircleCollider2D>().radius;
        circle_Yradius = GetComponentInParent<CircleCollider2D>().radius;
        //circle_Xradius = GetComponent<CircleCollider2D>().radius;
        //circle_Yradius = GetComponent<CircleCollider2D>().radius;

        //bar = Instantiate(UI.GetComponentInChildren<Scrollbar>(), FindObjectOfType<Canvas>().transform);
        numbers = Instantiate(UI.GetComponentInChildren<Text>(), FindObjectOfType<Canvas>().transform).GetComponent<Text>();
        line = GetComponent<LineRenderer>();
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        CreatePoints();

        currentValue = GetComponentInParent<ExtractionPoint>().CurrentValue;
        MaxValue = GetComponentInParent<ExtractionPoint>().max_value;
        active_time = GetComponentInParent<ExtractionPoint>().active_time;

        //bar.size = active_time / 10;
        //bar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.5f, 0));
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

    public void disabletxt()
    {
        numbers.enabled = false;
    }

    public void disablebar()
    {
       
        bar.enabled = false;
    }


   

}
