using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{

    float[] spectrum;
    public float frequencyValue {get; set;}

    float pitch;

    bool lowPitch = false;

    AudioSource music;

    public static AudioVisualizer instance;

    void Start()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        spectrum = new float[256];
        music = GetComponent<AudioSource>();
        InvokeRepeating("ChangePitch", 2.0f, 3.0f);
        InvokeRepeating("CheckPitch", 0.5f, 0.5f);
    }

    void ChangePitch()
    {
        if (lowPitch == true)
        {
            music.pitch = 1.0f;
            lowPitch = false;
        }
        else
        {
            music.pitch = 0.4f;
            lowPitch = true;
        }
    }

    void Update()
   {
    }

    void CheckPitch()
    {
        pitch = music.pitch;
        Debug.Log(pitch);
    }

   public float GetPitch
   {
       get => pitch;
   }
}
