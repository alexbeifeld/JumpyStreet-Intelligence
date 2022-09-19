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
    [SerializeField] private GameObject settingsPanel;
    private bool settingsStatus;
    void Start()
    {
        settingsStatus = false;
        settingsPanel.SetActive(false);
        volumeChanger.value = 50;
    }

    
    void FixedUpdate()
    {
        VolumeChanger();
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
        if (settingsStatus == false)
        {
            settingsPanel.SetActive(true);
            settingsStatus = true;
            Time.timeScale = 0;
        }
        else if (settingsPanel == true)
        {
            settingsPanel.SetActive(false);
            settingsStatus = false;
            Time.timeScale = 1;
        }
    }

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("GameBoard");
    }
    private void VolumeChanger()
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
}
