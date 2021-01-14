using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using static Cinemachine.CinemachineFreeLook;

public class ZoomOutCamera : MonoBehaviour
{
    bool zoomingOut = false;
    CinemachineFreeLook cinemachineCamera;
    public float radiusZoomOutSpeed;
    public float heightZoomOutSpeed;
    float initialYValue, initialXValue;
    Orbit[] orbits;
    float[] initialRadii;
    float[] initialHeight;
    float timeLeft;
    
    void Start() {
        cinemachineCamera = GetComponent<CinemachineFreeLook>();
        orbits = cinemachineCamera.m_Orbits;
        initialRadii = new float[orbits.Length];
        initialHeight = new float[orbits.Length];
        for (int i = 0; i < orbits.Length; i++) {
            initialRadii[i] = orbits[i].m_Radius;
            initialHeight[i] = orbits[i].m_Height;
        }
    }

    void Update() {
        if (zoomingOut) {
            for (int i = 0; i < orbits.Length; i++) {
                orbits[i].m_Radius += radiusZoomOutSpeed * Time.deltaTime;
                orbits[i].m_Height += heightZoomOutSpeed * Time.deltaTime;
            }

            timeLeft -= Time.deltaTime;
            zoomingOut = timeLeft > 0;
        }
    }

    public void ZoomOut(float timeToZoomOut) {
        zoomingOut = true;
        timeLeft = timeToZoomOut;
    }
}
