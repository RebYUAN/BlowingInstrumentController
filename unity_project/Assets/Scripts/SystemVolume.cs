using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SystemVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    public AudioListener audioListener;
    public GameObject mute;
    public GameObject unmute;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void systemvolume()
    {
        
        audioMixer.SetFloat("SystemVolume", slider.value);
    }

    public void setMute()
    {
        audioListener.enabled = false;
        mute.SetActive(false);
        unmute.SetActive(true);
    }
    public void setUnmute()
    {
        audioListener.enabled = true;
        unmute.SetActive(false);
        mute.SetActive(true);
    }

}
