using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //No se hasta que punto esto va con FMOD, pero ahi está
using UnityEngine.UI;
public class SettingsMenuScript : MonoBehaviour
{
    public AudioMixer audioMixer; //FMOD???

    //Data
    Resolution[] resolutions;
    List<string> resolutionsString;
    private string[] inputModes = { "Teclado, Mando" }; //Temporal, tengo que meter lo de la traduccion

    //Variables
    int currentResolutionIndex;
    int currentMusicVolume;
    int currentSFX_Volume;
    bool fullscreen;

    //Default Values
    bool defaultFullscreenValue = false;
    int defaultMusicVolume = 50;
    int defaultSFX_Volume = 50;

    //Texts
    public Text fullScreen;
    public Text resolution;
    public Text musicVolume;
    public Text sfxVolume;
    public Text inputMode;

    // Start is called before the first frame update
    void Start()
    {
        resolutionsString = new List<string>();
        resolutions = Screen.resolutions;
        currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            resolutionsString.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        LoadSettings(currentResolutionIndex);
        UpdateText();
    }

    protected void UpdateText()
    {
        if (fullscreen)
            fullScreen.text = "Si";
        else
            fullScreen.text = "No";

        resolution.text = resolutionsString[currentResolutionIndex];
        musicVolume.text = currentMusicVolume.ToString();
        sfxVolume.text = currentSFX_Volume.ToString();
        //inputMode.text = 
    }

    public void changeFullScreen()
    {
        fullscreen = !fullscreen;

        if (fullscreen)
        {
            fullScreen.text = "Si";
        }
        else
        {
            fullScreen.text = "No";
        }

        Screen.fullScreen = fullscreen;
    }

    public void lessResolution()
    {
        if (currentResolutionIndex > 0)
            currentResolutionIndex -= 1;
        else
            currentResolutionIndex = resolutions.GetLength(0) - 1;

        SetResolution(currentResolutionIndex);
        resolution.text = resolutionsString[currentResolutionIndex];
    }

    public void moreResolution()
    {
        if (currentResolutionIndex < (resolutions.GetLength(0) - 1))
            currentResolutionIndex += 1;
        else
            currentResolutionIndex = 0;

        SetResolution(currentResolutionIndex);
        resolution.text = resolutionsString[currentResolutionIndex];
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void moreSFX_Volume()
    {
        if (currentSFX_Volume <= 95)
        {
            currentSFX_Volume += 5;
            //audioMixer.SetFloat("Volume", currentSFX_Volume); //FMOD, o distinto parametro??

            sfxVolume.text = currentSFX_Volume.ToString(); //UpdateText
        }
        else
        {

        }
    }

    public void lessSFX_Volume()
    {
        if (currentSFX_Volume >= 5)
        {
            currentSFX_Volume -= 5;
            //audioMixer.SetFloat("Volume", currentSFX_Volume); //FMOD, o distinto parametro??

            sfxVolume.text = currentSFX_Volume.ToString(); //UpdateText
        }
        else
        {

        }
    }

    public void moreMusicVolume()
    {
        if (currentMusicVolume <= 95)
        {
            currentMusicVolume += 5;
            //audioMixer.SetFloat("Volume", currentMusicVolume); //FMOD, o distinto parametro??

            musicVolume.text = currentMusicVolume.ToString(); //UpdateText
        }
        else 
        {
        
        }
    }

    public void lessMusicVolume()
    {
        if (currentMusicVolume >= 5)
        {
            currentMusicVolume -= 5;
            //audioMixer.SetFloat("Volume", currentMusicVolume); //FMOD, o distinto parametro??

            musicVolume.text = currentMusicVolume.ToString(); //UpdateText
        }
        else
        {

        }
    }

    public void changeInputMode()
    {

    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("ResolutionIndexPreference", currentResolutionIndex);
        PlayerPrefs.SetInt("FullscreenPreference", Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetInt("MusicVolumePreference", currentMusicVolume);
        PlayerPrefs.SetInt("SFX_VolumePreference", currentSFX_Volume);
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("ResolutionIndexPreference"))
            currentResolutionIndex = PlayerPrefs.GetInt("AntiAliasingPreference");
        else
            currentResolutionIndex = resolutions.GetLength(0) - 1;
        
        if (PlayerPrefs.HasKey("FullscreenPreference"))
        {
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
            fullscreen = Screen.fullScreen;
        }
        else
        {
            Screen.fullScreen = defaultFullscreenValue;
            fullscreen = defaultFullscreenValue;
        }

        Screen.SetResolution(resolutions[currentResolutionIndex].width, resolutions[currentResolutionIndex].height, fullscreen);

        if (PlayerPrefs.HasKey("MusicVolumePreference"))
            currentMusicVolume = PlayerPrefs.GetInt("MusicVolumePreference");
        else
            currentMusicVolume = defaultMusicVolume;

        //audioMixer.SetFloat("Volume", currentMusicVolume);

        if (PlayerPrefs.HasKey("SFX_VolumePreference"))
            currentSFX_Volume = PlayerPrefs.GetInt("SFX_VolumePreference");
        else
            currentSFX_Volume = defaultSFX_Volume;

        //audioMixer.SetFloat("Volume", currentMusicVolume);
    }
}
