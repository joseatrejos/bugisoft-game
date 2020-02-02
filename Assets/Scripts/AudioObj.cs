using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObj : MonoBehaviour {

    float pitch;

    void Start()
    {

    }

    void Update()
    {
         pitch = AudioVisualizer.instance.GetPitch;

        if (pitch > 0.5)
        {
            GetComponent<Player>().enabled = true;
        }
        else GetComponent<Player>().enabled = false;
    }    
}
