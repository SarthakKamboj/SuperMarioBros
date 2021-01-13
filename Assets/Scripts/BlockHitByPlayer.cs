using UnityEngine;

public class BlockHitByPlayer : MonoBehaviour
{
    Vector3 boundCenter;
    Vector3 boundsExtent;
    Bounds brickBounds;
    [SerializeField]
    private InstantiableObject[] objects;

    void Start() {
        brickBounds = gameObject.GetComponent<Collider>().bounds;
        boundCenter = brickBounds.center;
        boundsExtent = brickBounds.extents;
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Vector3 colPoint = collision.contacts[0].point;
            if (ColPointOnBottom(colPoint)) {
                float y = boundsExtent.y;
                Vector3 yInc = new Vector3(0f,y + 2f,0f);
                int index = Random.Range(0, objects.Length);
                InstantiableObject obj = objects[index];
                GameObject newObject = Instantiate(obj.prefab, boundCenter + new Vector3(0f,y,0f), Quaternion.Euler(Vector3.up));
                Behaviour comp = (Behaviour) newObject.GetComponent(obj.componentToCall.GetType());
                comp.enabled = true;
            }
        }
    }

    bool ColPointOnBottom(Vector3 colPoint) {
        float cX = colPoint.x;
        float cY = colPoint.y;
        float cZ = colPoint.z;

        float bX = boundCenter.x;
        float bY = boundCenter.y;
        float bZ = boundCenter.z;

        float beX = boundsExtent.x;
        float beY = boundsExtent.y;
        float beZ = boundsExtent.z;

        if (cY <= bY - beY) {
            if (Mathf.Abs(cX - bX) <= beX && Mathf.Abs(cZ - bZ) <= beZ) {
                return true;
            }
        }

        return false;
    }

}

[System.Serializable]
class InstantiableObject {
    public GameObject prefab;
    public Component componentToCall;
}
