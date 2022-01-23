using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EffectSound : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        if (!PlayerPrefs.HasKey("effectVolume"))
        {
            PlayerPrefs.SetFloat("effectVolume", 1);
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("effectVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("effectVolume", volumeSlider.value);
    }

}
