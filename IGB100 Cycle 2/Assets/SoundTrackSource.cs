using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrackSource : MonoBehaviour
{

    [Header("sound")]
    public AudioClip SoundTrackAudio;



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = SoundTrackAudio;
        GetComponent<AudioSource>().Play();
    }

}
