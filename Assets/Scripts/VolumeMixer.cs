using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeMixer : MonoBehaviour
{
    [SerializeField] private Slider Music;
    [SerializeField] private Slider Sound;
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer soundMixer;

    void Start()
    {
        Music.value = PlayerPrefs.GetFloat("Music");
        Sound.value = PlayerPrefs.GetFloat("Sound");
    }

    public void UpdatePlayerPrefs()
    {
        PlayerPrefs.SetFloat("Music", Music.value);
        PlayerPrefs.SetFloat("Sound", Sound.value);
        musicMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("Music"));
        soundMixer.SetFloat("SoundVolume", PlayerPrefs.GetFloat("Sound"));
    }
}
