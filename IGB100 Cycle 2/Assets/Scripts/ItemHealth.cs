using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    public float rotateSpeed = 50f;
   // public bool bonus = false;
    public float health;
    public PlayerHealth ph;
    public AudioClip healthSound;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<AudioSource>().playOnAwake = false;
        ph = GameObject.FindWithTag("PlayerBody").GetComponent<PlayerHealth>();
        //GetComponent<AudioSource>().clip = healthSound;
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);
        //if (bonus)
        // {
        //health += 10;
        //bonus = false;

        health = ph.currentHealth;
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && health < 100)
        {
            //GetComponent<AudioSource>().Play();
            ph.healthBonus(10);
            //if(TryGetComponent(out PlayerHealth playerHealth))
            //{

            //}
            SingletonParams.Instance.PlaySoundFXClip(healthSound, transform, 0.7f);
            Debug.Log("!! - ITEM GET - !!");
            Destroy(this.gameObject);

            //bonus = true;


        }
    }
}
