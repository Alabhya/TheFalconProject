using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Lap_Manager : MonoBehaviour
{
    int lap = 1;
    int lapCount = 7;
    float currentLapTime = 0.0f;
    float lastLapTime = 0.0f;
    float bestLapTime = 0.0f;
    bool raceStart = false;
    bool raceEnd = false;

    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliDisplay;

    public GameObject current_lap_obj;
    public GameObject last_lap_obj;
    public GameObject best_lap_obj;
    public GameObject lap_count_obj;
    public GameObject ExitPanel;
    TextMeshProUGUI current_lap_txt;
    TextMeshProUGUI last_lap_txt;
    TextMeshProUGUI best_lap_txt;
    TextMeshProUGUI lap_count_txt;

    TimeSpan span;

    void Start()
    {
        lastLapTime = 0;
        bestLapTime = 0;

        current_lap_txt = current_lap_obj.GetComponent<TextMeshProUGUI>();
        last_lap_txt = last_lap_obj.GetComponent<TextMeshProUGUI>();
        best_lap_txt = best_lap_obj.GetComponent<TextMeshProUGUI>();
        lap_count_txt = lap_count_obj.GetComponent<TextMeshProUGUI>();
        
    }


    void OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.tag == "car_front" && raceStart == false)
        {
            raceStart = true;
            lastLapTime = 0;
            bestLapTime = 0;
            lap_count_txt.text = lap + "/" + lapCount;
            Debug.Log("First update");
            return;
        }
        else if (col.gameObject.tag == "car_front" && lap <= lapCount)
        {
            lastLapTime = currentLapTime;
            if (lastLapTime <= bestLapTime || bestLapTime == 0)
            {
                bestLapTime = lastLapTime;
            }

            currentLapTime = 0.0f;
            span = TimeSpan.FromSeconds(currentLapTime);
            current_lap_txt.text = span.ToString(@"mm\:ss\.fff");
            span = TimeSpan.FromSeconds(bestLapTime);
            best_lap_txt.text = span.ToString(@"mm\:ss\.fff");
            span = TimeSpan.FromSeconds(lastLapTime);
            last_lap_txt.text = span.ToString(@"mm\:ss\.fff");

            lap_count_txt.text = lap + "/" + lapCount;
            lap++;

            // Debug.Log("Second  update");
        }
        
        if (lap > lapCount)
        {
            raceEnd = true;
            raceStart = false;
        }
        
    }




    void Update()
    {
        Debug.Log(raceEnd);
        if (raceStart)
        {
            currentLapTime += Time.deltaTime;

            span = TimeSpan.FromSeconds(currentLapTime);
            current_lap_txt.text = span.ToString(@"mm\:ss\.fff");
        }
        if (raceEnd)
        {
            Time.timeScale = 0;
            ExitPanel.SetActive(true);
        }
       
    }

  
}
