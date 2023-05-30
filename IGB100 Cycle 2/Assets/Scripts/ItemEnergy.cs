using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnergy : MonoBehaviour
{
    public float rotateSpeed = 50f;
    public bool bonus = false;
    private float energy;
    // Start is called before the first frame update
    void Start()
    {
        energy = SingletonParams.Instance.energyLevel;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);
        if (bonus)
        {
            energy += 20;
            bonus = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && energy < 100)
        {
            Destroy(this);
            bonus = true;
            Debug.Log("!! - ITEM GET - !!");
        }
    }
}
