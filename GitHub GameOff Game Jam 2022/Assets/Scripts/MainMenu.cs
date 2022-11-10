using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string firstLevel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void OpenSettings()
    {
        Debug.Log("Open Settings");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }

    public void CloseSettings()
    {
        Debug.Log("Close Settings");
    }


}



