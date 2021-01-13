using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInstatiateFromBlock : MonoBehaviour
{

    public float forceMultiplier = 10f;
    void Start()
    {
        Vector3 instantiateForce = (new Vector3(Random.Range(-1f,1f),Random.Range(0f,1f),Random.Range(-1f,1f))).normalized;
        GetComponent<Rigidbody>().AddForce(instantiateForce * forceMultiplier, ForceMode.VelocityChange);
    }

}
