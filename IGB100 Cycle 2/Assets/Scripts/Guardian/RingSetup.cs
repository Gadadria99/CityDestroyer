using UnityEngine;

public class RingSetup : MonoBehaviour
{
    public float rotateSpeed;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);
    }
}