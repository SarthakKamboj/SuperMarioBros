using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float rotationsPerSecond = 1f;
    private float degPerSecond; 
    // Start is called before the first frame update
    void Start()
    {
        degPerSecond = rotationsPerSecond * 360;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f,degPerSecond*Time.deltaTime,0f));

    }
}
