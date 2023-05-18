using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{

    [SerializeField] GameObject BuildingPreFab;
 
    void Start()
    {
        Instantiate(BuildingPreFab, transform.position, transform.rotation);
        BuildingPreFab.transform.position = new  Vector3(transform.position.x, 200, transform.position.z);
    }
}
