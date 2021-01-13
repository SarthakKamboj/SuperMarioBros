using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockHit : MonoBehaviour
{
    [SerializeField]
    private Mesh questionBlockHitMesh;

    [SerializeField]
    private Material questionBlockHitMaterial;
    [SerializeField]
    private List<MonoBehaviour> compsToKeep;

    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Player") {
            GetComponent<MeshFilter>().mesh = questionBlockHitMesh;
            GetComponent<MeshRenderer>().sharedMaterial = questionBlockHitMaterial;

            MonoBehaviour[] allComps = GetComponents<MonoBehaviour>();
            foreach(MonoBehaviour comp in allComps) {
                // if (!compsToKeep.Contains(comp)) {
                    comp.enabled = false;
                // }
            }
        }
    }
    
}
