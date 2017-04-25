using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public GameObject mainMenuHolder;
    public GameObject settingsMenuHolder;

    public Slider[] volumeSliders;
    public Toggle[] resolutionsToggles;
    public int[] screenWidths;

    int activeScreenResolutionIndex;

    void Start()
    {
        activeScreenResolutionIndex = PlayerPrefs.GetInt("screenResolutionIndex");
        bool isFullscreen = (PlayerPrefs.GetInt("fullscreen") == 1) ? true : false;

        for(int i = 0; i < resolutionsToggles.Length; i++)
        {
            resolutionsToggles[i].isOn = i == activeScreenResolutionIndex;
        }

        SetFullscreen(isFullscreen);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SettingsMenu()
    {
        mainMenuHolder.SetActive (false);
        settingsMenuHolder.SetActive (true);
    }

    public void MainMenu()
    {
        mainMenuHolder.SetActive (true);
        settingsMenuHolder.SetActive (false);
    }

    public void SetScreenResolution(int i)
    {
        if (resolutionsToggles[i].isOn)
        {
            activeScreenResolutionIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);
            PlayerPrefs.SetInt("screenResolutionIndex", activeScreenResolutionIndex);
            PlayerPrefs.Save();
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        for(int i = 0; i < resolutionsToggles.Length; i++)
        {
            resolutionsToggles[i].interactable = !isFullscreen;
        }

        if (isFullscreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            SetScreenResolution(activeScreenResolutionIndex);
        }

        PlayerPrefs.SetInt("fullscreen", ((isFullscreen) ? 1 : 0));
        PlayerPrefs.Save();
    }

    public void SetMasterVolume(float value)
    {

    }

    public void SetMusicVolume(float value)
    {

    }

    public void SetSfxVolume(float value)
    {

    }
}
