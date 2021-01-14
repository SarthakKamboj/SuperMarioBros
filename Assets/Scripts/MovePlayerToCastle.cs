using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToCastle : MonoBehaviour
{
    public Transform endTransform;
    Vector3 endPos;
    // Start is called before the first frame update
    void Start()
    {
        endPos = endTransform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
