using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphToGround : MonoBehaviour
{
    public enum Direction {Left = 1, Right = -1};

    public Direction direction = Direction.Left;
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GameObject ground = GameObject.Find("Ground");
        Bounds groundBounds = ground.GetComponent<Collider>().bounds;
        Vector3 groundScale = ground.transform.localScale;
        transform.localScale = new Vector3(groundScale.x, 100f, 1f);
        transform.position = ground.transform.position + new Vector3(0,0,(int) direction * groundBounds.extents.z);
    }


    void Update()
    {
                
    }
}
