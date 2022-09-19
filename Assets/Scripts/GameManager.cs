using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OnClickInstructionsButton()
    {

    }

    public void OnClickSettingsButton()
    {

    }

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("GameBoard");
    }
}
