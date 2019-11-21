using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap_Manager : MonoBehaviour
{
    int lap = 1;
    public int lapCount = 7;
    float currentLapTime = 0.0f;
    float lastLapTime = 0.0f;
    float bestLapTime = 0.0f;
    bool raceStart = false;

    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliDisplay;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;


    void Start()
    {
        lastLapTime = 0;
        bestLapTime = 0;
    }

 
    void OnTriggerEnter(Collider col)
    {
            if (col.gameObject.tag == "car_front" && raceStart == false)
            {
                raceStart = true;
                lastLapTime = 0;
                bestLapTime = 0;

         //   Debug.Log("First update");
            return;
            }
            else if (col.gameObject.tag == "car_front" && lap <= lapCount)
            {
                lap++;
                lastLapTime = currentLapTime;
                if (lastLapTime <= bestLapTime || bestLapTime == 0)
                {
                    bestLapTime = lastLapTime;
                }

                currentLapTime = 0.0f;
           // Debug.Log("Second  update");
        }
    }

    void Update()
    {
        if (raceStart == true)
        {
            currentLapTime += Time.deltaTime;
            MilliCount += currentLapTime * 10;
            MilliDisplay = MilliCount.ToString("F0");
            // MilliBox.GetComponent<Text>().text = "" + MilliDisplay;

            if (MilliCount >= 10)
            {
                MilliCount = 0;
                SecondCount += 1;
            }

            if (SecondCount <= 9)
            {
                // SecondBox.GetComponent<Text>().text = "0" + SecondCount + ".";
            }
            else
            {
                //SecondBox.GetComponent<Text>().text = "" + SecondCount + ".";
            }

            if (SecondCount >= 60)
            {
                SecondCount = 0;
                MinuteCount += 1;
            }

            if (MinuteCount <= 9)
            {
                //MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
            }
            else
            {
                // MinuteBox.GetComponent<Text>().text = "" + MinuteCount + ":";
            }


            Debug.Log("Current Lap Time:" + currentLapTime);
            Debug.Log("Last Lap Time:" + lastLapTime);
            Debug.Log("Best Lap Time:" + bestLapTime);
        }
    }

  
}
