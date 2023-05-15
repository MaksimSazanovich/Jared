using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WitingSettings : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Slider slider;
    private float volume = 0.5f;
    private float speedWriting;
    private InformationManager informationManager; 
    private void Start()
    {
        informationManager = GetComponent<InformationManager>();
        Load();
        ValueMusic();
    }

    public void SliderMusic()
    {
        volume = slider.value;
        Save();
        ValueMusic();
    }

    public void ToggleMusic()
    {
        if (toggle.isOn == true)
            volume = 1;
        else
            volume = 0.0001f;
        slider.value = volume;
        Save();
        ValueMusic();
    }
    public void ValueMusic()
    {
        //musicMixer.SetFloat("Volume", (float)Math.Log10(volume) * 20f);
        speedWriting = slider.value / 10;
        if (volume <= 0.0001f)
            toggle.isOn = false;
        else
            toggle.isOn = true;
        informationManager.SetWritingSpeed(speedWriting);
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("Volume", volume);
    }

    private void Load()
    {
        volume = PlayerPrefs.GetFloat("Volume", volume);
        slider.value = volume;
    }
}