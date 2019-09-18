using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text win_text;
    public Text lose_text;

    public GameObject[] available_tiles;


    public bool WinByScore;
    public float Score_ToWin;

    public bool WinByExtractions;
    public int Extractions_ToWin;
    private int Extracted_num;
    public int ExtractedNum
    {
        get
        {
            return Extracted_num;
        }

        set
        {

            Extracted_num = value;
        }

    }

    public bool winbysurviving;
    public float SurviveTime_towin;

    private float timer;

    private GameObject[] spawned_extractionsites;

    public GameObject[] extraction_sites_ToSpawn;
    public float First_spawn;
    public float Spawn_interval;

    public int Max_extractionsite_count;

    public GameObject[] powerups__ToSpawn;



    private float score_ ;
    public float Score
    {
        get
        {
            return score_;
        }

        set
        {

          score_ = value;
        }
        

    }
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        updateNumber();
        InvokeRepeating("SpawnExtractionSite", First_spawn, Spawn_interval - First_spawn);
        //InvokeRepeating();

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.instance.Died == true)
        {
            lose();
        }
        
        if (winbysurviving == true)
        {
            SurviveTime_towin -= Time.deltaTime;
            if (SurviveTime_towin <= 0)
            {
                win();
            }
        }

        if (WinByExtractions == true)
        {
            if (Extractions_ToWin <= ExtractedNum)
            {
                win();
            }
        }

        if (WinByScore == true)
        {
            if (Score >= Score_ToWin)
            {
                win();
            }

        }

       
    }

    public void SpawnExtractionSite()
    {
        available_tiles = GameObject.FindGameObjectsWithTag("Blank");

        Debug.Log("try");
        if (Max_extractionsite_count > spawned_extractionsites.Length)
        {
            Instantiate(extraction_sites_ToSpawn[Random.Range(0, extraction_sites_ToSpawn.Length)], available_tiles[Random.Range(0, available_tiles.Length)].transform.position, transform.rotation);
            updateNumber();
        }
    }

    public void addscore(float bonus_score)
    {
        Score += bonus_score;
    }

    public void updateNumber()
    {
        spawned_extractionsites = GameObject.FindGameObjectsWithTag("Extractionsite");
    }

    private void win()
    {
        Time.timeScale = 0;
        win_text.enabled = true;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(2);
            Time.timeScale = 1;
        }
        
    }

   public void lose()
    {
        Time.timeScale = 0;
        lose_text.enabled = true;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
             Time.timeScale = 1;
        }


    }
}
