using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Video;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    public VideoPlayer videoPlayer;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("VideoVolume", 0.75f);
      //  videoPlayer = FindObjectOfType < "Camera" > ();
    }
    public void SetVolume(float sliderValue)
    {
        mixer.SetFloat("VideoVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        //VideoPlayer.Track0[2 ch].Volume
    }

    void SetDirectAudioVolume(ushort trackIndex, float volume)
    {

    }

}
