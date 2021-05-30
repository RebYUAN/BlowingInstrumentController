using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ToneChange : MonoBehaviour
{
    Dropdown dropDownItem;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        dropDownItem = this.GetComponent<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dropDownItem.value == 0)
        {
            audioMixer.SetFloat("pitch", 1);
        }
        if (dropDownItem.value == 1)
        {
            audioMixer.SetFloat("pitch", 0.75f);
        }
    }
}
