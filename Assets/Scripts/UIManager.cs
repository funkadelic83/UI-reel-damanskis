using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour //maybe make this a singleton
{
    public new GameObject camera;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public AudioMixer mixer;
    public Slider slider;
    public float videoVolumeControl;
    private GameObject currentMenu;
    private bool darkMode;
    private bool musicOn;
    [SerializeField] private GameObject checkBox;
    [SerializeField] private GameObject videoInstructions;

    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _miniDocMenu;
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private GameObject _comedyMenu;

    void Start()
    {
        musicOn = true;
        currentMenu = null;
        _mainMenu.SetActive(true);
        darkMode = true;
        camera = GameObject.Find("Main Camera");
        camera.GetComponent<Camera>().backgroundColor = new Color32(85, 0, 0, 255);
        videoPlayer = camera.AddComponent<VideoPlayer>();
        videoPlayer.clip = null;
        videoPlayer.playOnAwake = false;
        slider.value = 1.0f;
        SetVolume(slider.value); //Can I do this using PlayerPrefs.GetFloat("VideoVolume"), 0.75f);
        videoVolumeControl = slider.value;
    }

    
    public void ToggleMusic()
    {
        if (musicOn)
        {
            musicOn = false;
            audioSource.Pause();
        } else if (!musicOn) {
            musicOn = true;
            audioSource.Play();
        }
    }

    public void ToggleDarkMode()
    {
        if (darkMode)
        {
            darkMode = false;
            camera.GetComponent<Camera>().backgroundColor = new Color32(0, 118, 191, 255);
        }
        else if (!darkMode)
        {
            darkMode = true;
            camera.GetComponent<Camera>().backgroundColor = new Color32(85, 0, 0, 255);
        }
    }
    public void ToggleMiniDocMenu()
    {
        currentMenu = _miniDocMenu;
        _mainMenu.gameObject.SetActive(false);
        _miniDocMenu.gameObject.SetActive(true);
    }

    public void ToggleComedyMenu()
    {
        currentMenu = _comedyMenu;
        _mainMenu.gameObject.SetActive(false);
        _comedyMenu.gameObject.SetActive(true);
    }

    public void ToggleOptionsMenu()
    {
        _mainMenu.gameObject.SetActive(false);
        _optionsMenu.gameObject.SetActive(true);
    }

    public void ReturnToMain(GameObject activeMenu)
    {
        activeMenu.gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(true);
    }

    public void PlayVideo(VideoClip videoToPlay)
    {
        videoPlayer.clip = videoToPlay;
        currentMenu.SetActive(false);
        videoPlayer.SetDirectAudioVolume(0, videoVolumeControl);
        audioSource.Pause();
        videoPlayer.Play();
        
        StartCoroutine("VideoPlayerInstructions");
        videoPlayer.loopPointReached += videoEndReached;
    }

    IEnumerator VideoPlayerInstructions()
    {
        videoInstructions.SetActive(true);
        yield return new WaitForSeconds(5);
       videoInstructions.SetActive(false);
        StopCoroutine("VideoPlayerInstructions");

    }
    public void videoEndReached(UnityEngine.Video.VideoPlayer vp)
    {
        videoPlayer.clip = null;
        currentMenu.SetActive(true);
        if (musicOn)
        {
        audioSource.Play();
        }
        videoInstructions.SetActive(false);

    }


public void SetVolume(float sliderValue)
{
    mixer.SetFloat("VideoVolume", (Mathf.Log10(sliderValue) * 20) - 10);
    videoVolumeControl = sliderValue;
    PlayerPrefs.SetFloat("VideoVolume", sliderValue);
}

    public void QuitGame()
    {
        Application.Quit();
    }
// Update is called once per frame
void Update()
    {
        if(videoPlayer.isPlaying == true && Input.GetKeyDown(KeyCode.Space))
        {
            videoPlayer.clip = null;
            if(musicOn)
            {
            audioSource.Play();

            }
            currentMenu.SetActive(true);
            videoInstructions.SetActive(false);
        }
    }
}
