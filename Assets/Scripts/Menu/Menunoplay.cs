using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menunoplay : MonoBehaviour
{
    public AudioClip impact;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void heheh(){
        SceneManager.LoadScene("Level01");
    }
    public void aresureaudio(){
        audioSource.PlayOneShot(impact, 0.7F);
    }
}
