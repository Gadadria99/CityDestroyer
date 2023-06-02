using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageAmount = 10f;
    public float playerHealth;

    void update()
    {
        playerHealth = SingletonParams.Instance.currentHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                SingletonParams.Instance.TakeDamage(10);
            
        }
    }
}