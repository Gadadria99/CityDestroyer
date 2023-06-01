using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonParams : MonoBehaviour
{
    private static SingletonParams manager;
    public static SingletonParams Instance { get { return manager; } }

    public float maxEnergy = 101f;
    public float energyLevel;
    public bool Grow = false;

    public Transform ScoutPosition;
    public Transform titanPosition;

    [SerializeField] private AudioSource soundFXObject;

    void Awake()
    {
        if (manager != null && manager != this)
            Destroy(gameObject);
        else
            manager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        energyLevel = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (energyLevel < 0)
        {
            energyLevel = 0;


        }
        else if (energyLevel > maxEnergy)
        {
            energyLevel = maxEnergy;
        }
    }

    public void Recharge(float eVal)
    {

        if (energyLevel < maxEnergy)
        {
            energyLevel += (eVal * 2 * Time.deltaTime);
        }

    }

    public void RechargeItem(float eVal)
    {

        if (energyLevel < maxEnergy)
        {
            energyLevel += eVal;
        }

    }

    public void energyDrain(float nrgVal)
    {
        if (energyLevel >= 0)
        {
            energyLevel -= (nrgVal * Time.deltaTime);
        }

    }


    //sound


    public void PlaySoundFXClip(AudioClip sound, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = sound;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);

    }
}
