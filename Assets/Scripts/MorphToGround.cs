using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphToGround : MonoBehaviour
{
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GameObject ground = GameObject.Find("Ground");
        Vector3 groundScale = ground.transform.localScale;
        transform.localScale = new Vector3(groundScale.x, 100f, 1f);
    }
    
}
