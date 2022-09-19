using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider volumeChanger;
    [SerializeField] private GameObject noSound;
    [SerializeField] private GameObject sound;
    void Start()
    {
        volumeChanger.value = 50;
    }

    
    void Update()
    {
        if (volumeChanger.value == 0)
        {
            sound.SetActive(false);
            noSound.SetActive(true);
        }
        else
        {
            noSound.SetActive(false);
            sound.SetActive(true);
        }
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
