using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{

    public Toggle soundToggle;
    public Toggle musicToggle;
    public Toggle fullscreenToggle;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;

    private Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        //Set toggle states depending on current settings
        soundToggle.isOn = GameSettings.sounds;
        musicToggle.isOn = GameSettings.music;
        fullscreenToggle.isOn = Screen.fullScreen;

        //Populate resolutions dropdown
        SetUpResolutions();

        //Set selected quality to current quality
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();
    }

    void SetUpResolutions()
    {
        //Get all available resolutions
        List<Resolution> allResolutions = new List<Resolution>();
        List<Resolution> displatedResolutions = new List<Resolution>();
        allResolutions.AddRange(Screen.resolutions);

        foreach (Resolution resolution in allResolutions)
        {
            if (!(resolution.width < 800 && resolution.height < 600))
            {
                displatedResolutions.Add(resolution);
            }
        }
        resolutions = displatedResolutions.ToArray(); ;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        //Add each resolution to dropdown options
        for (int i = 0; i < resolutions.Length; i++)
        {
            
            options.Add(resolutions[i].width + " x " + resolutions[i].height);

            //Check if current iteration is the same as current resolution
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
            
        }

        

        resolutionDropdown.AddOptions(options);
        //Set selected resolution to current resolution
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void ToggleSound(bool soundEnabled)
    {
        GameSettings.sounds = soundEnabled;
    }

    public void ToggleMusic(bool musicEnabled)
    {
        GameSettings.music = musicEnabled;
    }

    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution()
    {
        //Get value of resolution dropdown & set new resolution accordingly
        int resolutionIndex = resolutionDropdown.value;
        Resolution newResolution = resolutions[resolutionIndex];

        //Only change resolution if selected is different to current
        if (newResolution.width != Screen.width || newResolution.height != Screen.height)
        {
            Screen.SetResolution(newResolution.width, newResolution.height, Screen.fullScreen);
        }
    }

    public void SetQuality()
    {
        //Get value of quality dropdown & set new quality accordingly
        int qualityIndex = qualityDropdown.value;
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
