using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Slider volumeChanger;
    [SerializeField] private GameObject noSound;
    [SerializeField] private GameObject sound;
    [SerializeField] private GameObject settingsPanel;
    public string MainMenu;
    [SerializeField] private bool settings = false;
    [SerializeField] TMP_Text gameOverText;
    void Start()
    {
        settingsPanel.SetActive(false);
        /*if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", .5f);
            Load();
        }
        else
        {
            Load();
        }*/
    }

    private void Update()
    {

    }
    void FixedUpdate()
    {
        //VolumeChanger();
    }

    /*private void ChangeVolume()
    {
        AudioListener.volume = volumeChanger.value;
        Save();
    }
    private void Load()
    {
        volumeChanger.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeChanger.value);
    }*/
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
        if (!settings)
        {
            settings = true;
            Debug.Log("clicked settings button");
            settingsPanel.SetActive(true);
            Time.timeScale = 0;
            gameOverText.text = "Game Paused";
        }
        else
        {
            Debug.Log("clicked settings button");
            settingsPanel.SetActive(false);
            Time.timeScale = 1;
            settings = false;
        }
    }

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("GameBoard");
    }
    /*private void VolumeChanger()
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
    }*/

    public void RetryButtonClick()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void ResumeButtonClick()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
