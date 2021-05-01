using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.Events;
public class Settings : MonoBehaviour
{
    public AudioMixerGroup masterAudioMixer;
    public AudioMixerGroup musicAudioMixer;
    public AudioMixerGroup voiceAudioMixer;
    public AudioMixerGroup sfxAudioMixer;
    public TMP_Dropdown resolutionDropdown;
    int currentResolutionIndex = 0;
    private InputMaster controls;
    public UnityEvent onEscape;

    
    
    
    Resolution[] resolutions;

    
    private void Awake()
    {
        controls = new InputMaster();
        controls.UI.Cancel.performed += ctx => onEscapeDown();
    }
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(ResolutionList(resolutions));
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    private void OnEnable()
    {
        controls.UI.Enable();
    }
    private void OnDisable()
    {
        controls.UI.Disable();
    }

    private void onEscapeDown()
    {
        Debug.Log("Esc");
        onEscape.Invoke();
    }

    public void SetMasterVolume(float volume)
    {
        masterAudioMixer.audioMixer.SetFloat("masterVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        musicAudioMixer.audioMixer.SetFloat("musicVolume", volume);
    }
    public void SetVoiceVolume(float volume)
    {
        voiceAudioMixer.audioMixer.SetFloat("voiceVolume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        sfxAudioMixer.audioMixer.SetFloat("sfxVolume", volume);
    }

    public void SetGraphicsQuality(int graphicsQuality)
    {
        QualitySettings.SetQualityLevel(graphicsQuality);
        Debug.Log(graphicsQuality);
    }

    private List<string> ResolutionList(Resolution[] resolutions)
    {
        List<string> resolutionList = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolution = resolutions[i].width + "x" + resolutions[i].height;
            resolutionList.Add(resolution);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        return resolutionList;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }
    public void SetVsync(bool isVsync)
    {
        if(isVsync == true)
        {
            QualitySettings.vSyncCount = 2;
        }
        else if(isVsync == false)
        {
            QualitySettings.vSyncCount = 0;
        }
        
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    
}
