using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Slider>().value = PlayerPrefs.GetFloat("MasterVolume", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume(float volume)
    {
        Mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-30,0, volume));
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

}
