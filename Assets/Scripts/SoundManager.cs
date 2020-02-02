using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Drag a reference to the audio source which will play the sound effects.
    public AudioSource efxSource;
    
    // Drag a reference to the audio source which will play the music.
    public AudioSource musicSource;

    // Allows other scripts to call functions from SoundManager. 
    public static SoundManager instance = null;

    // The lowest a sound effect will be randomly pitched.
    public float lowPitchRange = 0.75f;

    // The highest a sound effect will be randomly pitched.
    public float highPitchRange = 1.25f;

    void Awake ()
        {
            // Checks if there is already an instance of SoundManager
            if (instance == null)
                instance = this;
            // If instance already exists, it's destroyed
            else if (instance != this)
                Destroy (gameObject);

            // Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
            DontDestroyOnLoad (gameObject);
        }
        
        /// <summary>
        /// Used to play single sound clips.
        /// </summary>
        /// <param name="clip"> Receives an audio clip as a parameter.</param>
        public void PlaySingle(AudioClip clip)
        {
            // Set the clip of our efxSource audio source to the clip passed in as a parameter.
            efxSource.clip = clip;

            // Play the clip.
            efxSource.Play ();
        }

        /// <summary>
        /// Chooses randomly between various audio clips and slightly changes their pitch.
        /// </summary>
        /// <param name="clips"> Receives an array of audio clips as a parameter.</param>
        public void RandomizeSfx (params AudioClip[] clips)
        {
            // Generate a random number between 0 and the length of our array of clips passed in.
            int randomIndex = Random.Range(0, clips.Length);

            // Choose a random pitch to play back our clip at between our high and low pitch ranges.
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);

            // Set the pitch of the audio source to the randomly chosen pitch.
            efxSource.pitch = randomPitch;

            // Set the clip to the clip at our randomly chosen index.
            efxSource.clip = clips[randomIndex];

            // Play the clip.
            efxSource.Play();
        }
}
