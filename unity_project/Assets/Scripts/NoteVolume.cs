using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NoteVolume : MonoBehaviour
{
    double pressure;
    double volume;
    public bool isFirstPlayed = true;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        pressure = SocketClient.pressure;
        volume = 0.0035641975308641975 * System.Math.Abs(pressure) - 0.30078024691358024;
        //volume = 1;
    }
    public void setVolume()
    {



        // if (isFirstPlayed && !source.isPlaying)
        // {
        //     source.clip = start;
        //     source.Play();
        //     source.volume = 1;
        //     isFirstPlayed = false;
        //     Debug.Log(1);
        //     StartCoroutine(AudioPlayFinished(start.length));
        // }
        //else if(!source.isPlaying && source.clip == loop)
        // {
        //     source.Play();
        //     source.volume = 1;
        //     source.loop = true;
        //     Debug.Log(3);
        // }

        source.volume = float.Parse(volume.ToString());
        //source.volume = 1;


        //if (source.isPlaying)
        //{
        //    source.clip = loop;
        //    source.volume = 1;
        //    Debug.Log(1);
        //}
        //else if (!isFirstPlayed)
        //{source.clip = loop;

        //    source.loop = true;
        //    source.volume = 1;
        //    Debug.Log(2);
        //}
        //else
        //{

        //}

        Debug.Log(pressure);
        Debug.Log(volume);
        //source.volume = float.Parse(volume.ToString());


    }
    public void setMute()
    {
        //source.Stop();
        //isFirstPlayed = true;
        //source.loop = false;
        ////source.clip = start;
        ////this.GetComponent<AudioSource>().volume = 0;
        //Debug.Log(4);
        StartCoroutine(AudioPlayFinished(source));
        //source.volume = 0;
        
    }

    private IEnumerator AudioPlayFinished(AudioSource source)
    {
        while (source.volume > 0)
        {
            source.volume = source.volume / 20 - 0.001f;
        }
        Debug.Log("AudioPlayFinished");
        //source.clip = loop;
        //yield return new WaitForSeconds(time);
        //声音播放完毕后之下往下的代码  

        //#region   声音播放完成后执行的代码

        ////print("声音播放完毕，继续向下执行");
        ////source.clip = loop;
        //////source.Play();
        //////source.loop = true;
        //////source.volume = 1;
        ////Debug.Log(2);
        //#endregion
      yield  return 0;
    }
}
