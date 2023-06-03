using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MmenuAudio : MonoBehaviour
{


    [Header("sound")]
    public AudioClip menuAudio;



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = menuAudio;
        GetComponent<AudioSource>().Play();
    }


}
