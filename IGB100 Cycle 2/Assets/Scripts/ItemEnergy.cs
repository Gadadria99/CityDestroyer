using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnergy : MonoBehaviour
{
    public float rotateSpeed = 50f;
    //public bool bonus = false;
    private float energy;
    public AudioClip energySound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);
        energy = SingletonParams.Instance.energyLevel;
        //if (bonus)
        //{
        //    energy += 20;
        //    bonus = false;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && energy < 100)
        {

            SingletonParams.Instance.PlaySoundFXClip(energySound, transform, 0.7f);
            SingletonParams.Instance.RechargeItem(20);
            Debug.Log("!! - ITEM GET - !!");
            Destroy(this.gameObject);

        }
    }
}
