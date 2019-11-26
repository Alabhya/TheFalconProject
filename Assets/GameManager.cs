using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Utility;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button Attack;
    public Button Neutral;
    public Button Defend;
    public Slider DriverFocus;
    public GameObject Car;
    public float startcounter = 3;
    float drivefocus = 10;


    public CarAIControl ai;
    
    // Start is called before the first frame update
    void Start()
    {
        
        ai = Car.GetComponent<CarAIControl>();
        
    }


    public void AttackAction()
    {
        Debug.Log("Currently attacking! ");
        ai.SetCautionSpeedFactor(0.8f);
        ai.SetAccelerationSensitivity(1.0f);
    }

    public void NeutralAction()
    {
        Debug.Log("Currently neutral! ");
        ai.SetCautionSpeedFactor(0.6f);
        ai.SetAccelerationSensitivity(1.0f);
    }

    public void DefendAction()
    {
        Debug.Log("Currently defending! ");
        ai.SetCautionSpeedFactor(0.4f);
        ai.SetAccelerationSensitivity(1.0f);
    }
    

    public void ExitAction()
    {
        SceneManager.LoadScene("LaunchScreen");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitAction();
        }
    }
}
