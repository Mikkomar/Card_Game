using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource musicSource;
    AudioSource effectSource;

    static GameObject singleton; // So DontDestroyOnLoad won't duplicate the object if singleton exists

    private void Awake()
    {
        musicSource = gameObject.GetComponents<AudioSource>()[0];
        effectSource = gameObject.GetComponents<AudioSource>()[1];

        if (singleton == null)
        {
            singleton = transform.gameObject;
            DontDestroyOnLoad(transform.gameObject);
            playMusic();
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }

    public void playMusic()
    {
        if (musicSource.isPlaying)
        {
            return;
        }
        else
        {
            musicSource.Play();
        }
    }
}
