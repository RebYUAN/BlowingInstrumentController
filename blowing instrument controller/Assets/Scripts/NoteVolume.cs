using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteVolume : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pressure = SocketClient.pressure;
        Debug.Log(pressure);
    }

    public void setVolume()
    {
        this.GetComponent<AudioSource>().volume = 1;
    }
}
