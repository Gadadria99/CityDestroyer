using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableMaterial : MonoBehaviour
{
    public ShieldGen ShieldScript;
    public Material[] material;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (ShieldScript.shieldDead)
        {
            rend.sharedMaterial = material[1];
        }
    }
}
