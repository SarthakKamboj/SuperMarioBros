using System.Collections;
using UnityEngine;

public class QuestionBlockHit : MonoBehaviour
{
    [SerializeField]
    private Mesh questionBlockHitMesh;

    [SerializeField]
    private Material questionBlockHitMaterial;
    private BlockHitByPlayer blockHitByPlayer;
    void Start() {
        blockHitByPlayer = GetComponent<BlockHitByPlayer>();
    }

    void OnCollisionEnter(Collision col) {
        StartCoroutine(HitValid());
    }

    IEnumerator HitValid() {
        yield return new WaitForSeconds(Time.deltaTime);
        if (blockHitByPlayer.numObjectsInstantiated != 0) {
            GetComponent<MeshFilter>().mesh = questionBlockHitMesh;
            GetComponent<MeshRenderer>().sharedMaterial = questionBlockHitMaterial;

            MonoBehaviour[] allComps = GetComponents<MonoBehaviour>();
            foreach(MonoBehaviour comp in allComps) {
                comp.enabled = false;
            }
        }
    }
    
}
