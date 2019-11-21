using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchScript : MonoBehaviour
{
    public Button Play;
    public Button Exit;
    // Start is called before the first frame update
    void Start()
    {
                
    }

    public void LoadGame(string SceneName)
    {
        SceneManager.LoadScene("Drift Track");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
