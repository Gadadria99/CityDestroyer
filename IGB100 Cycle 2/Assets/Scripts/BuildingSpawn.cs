using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{

    [SerializeField] GameObject BuildingPreFab;
 
    void Start()
    {
        Instantiate(BuildingPreFab, transform.position, transform.rotation);
    }
}
