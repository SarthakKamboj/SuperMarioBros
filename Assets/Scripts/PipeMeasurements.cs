using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMeasurements : MonoBehaviour
{
    // public Vector3 pipeBodyScale;
    public float pipeBodyScaleY;
    public Transform pipeBodyTop;
    public Collider pipeHeadCollider;
    void Start()
    {
        GameObject pipeBody = transform.Find("pipe_body").gameObject;
        pipeBody.transform.localScale = new Vector3(1f,pipeBodyScaleY,1f);

        Vector3 pipeHeadSize = pipeHeadCollider.bounds.size;
        GameObject pipeHead = transform.Find("pipe_head").gameObject;
        pipeHead.transform.position = pipeBodyTop.position;
    }

    void Update()
    {
        
    }
}
