using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{

    [SerializeField] GameObject BuildingPreFab;
    [SerializeField] GameObject BuildingPreFab2;
    private float flip;

    private void Awake()
    {
        flip = Random.Range(0, 2);
    }

    void Start()
    {
        if (flip == 0)
        {
            Instantiate(BuildingPreFab, new Vector3(transform.position.x, 32, transform.position.z), transform.rotation);
        }
        else if (flip == 1)
        {
            Instantiate(BuildingPreFab2, transform.position, transform.rotation);
        }
    }
}
