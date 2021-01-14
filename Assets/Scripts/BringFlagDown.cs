using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringFlagDown : MonoBehaviour
{
    public Transform endTransform;
    public float speed;
    Vector3 endPos;
    bool bringFlagDown = false;
    void Start()
    {
        endPos = endTransform.position;    
    }

    void Update()
    {
        if (bringFlagDown) {
            if (transform.position.y >= endPos.y) {
                Vector3 curPos = transform.position;
                curPos.y -= speed * Time.deltaTime;
                transform.position = curPos;
            } else {
                bringFlagDown = false;
            }
        }
    }

    public void FlagDown() {
        bringFlagDown = true;
    }

}
