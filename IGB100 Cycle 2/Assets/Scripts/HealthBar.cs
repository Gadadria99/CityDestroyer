using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float maxScale = 0.55f;
    private float minScale = 0.0f;
    public float percent;
    private float currentHealth;
    public GameObject healthBar;
    public
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = SingletonParams.Instance.currentHealth;
        percent =  currentHealth * 0.55f / 100;

        healthBar.transform.localScale = new Vector3(percent, healthBar.transform.localScale.y, healthBar.transform.localScale.z); 
    }
}
