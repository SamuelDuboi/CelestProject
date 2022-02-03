using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
public class OptionHandler : MonoBehaviour
{
    public Toggle resolutionToggle;
    public TMP_Dropdown resolutionDropDown;
    public AudioMixer mainMixer;
    public Slider volumeSlider;
    private List<string> resolutionEnum = new List<string>();
    private List<Resolution> resolutionList = new List<Resolution>();
    private float currentVolume;
    private void Awake()
    {
        foreach (var resolution in Screen.resolutions)
        {
            resolutionEnum.Add(resolution.ToString());
        }
        resolutionDropDown.ClearOptions();
        resolutionDropDown.AddOptions(resolutionEnum);
        resolutionList =new List<Resolution>(Screen.resolutions);
    }

    private void OnEnable()
    {
        resolutionToggle.isOn = Screen.fullScreen;
        resolutionDropDown.value = resolutionList.IndexOf(Screen.currentResolution);
        mainMixer.GetFloat("MainVolume", out currentVolume);
        volumeSlider.value = currentVolume;
    }

    public void SetFullScreen(bool value)
    {
        Screen.fullScreen = value;
    }
    public void ChangeResolution(int  enumValue)
    {
        Screen.SetResolution( Screen.resolutions[enumValue].width, Screen.resolutions[enumValue].height, Screen.fullScreen);
    }
    public void OnChangeVolume(float value)
    {
        mainMixer.SetFloat("MainVolume", value);
    }
}
