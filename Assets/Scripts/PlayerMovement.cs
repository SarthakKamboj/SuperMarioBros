using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 200f;
    public Camera mainCamera;
    public Vector3 jumpForce;
    public float maxSpeed;
    public int maxJumps = 2;
    public float groundCheckDist = 0.1f;
    public LayerMask layerMask;
    float yExtent;
    int jumpsLeft;


    void Start() {
        yExtent = GetComponent<Collider>().bounds.extents.y;
        jumpsLeft = maxJumps;
    }
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0) {
            Jump();
            jumpsLeft -= 1;
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ground") {
            jumpsLeft = maxJumps;
        }
    }
    
    void Move() {
        if (rb.velocity.magnitude > maxSpeed) {
            rb.velocity = rb.velocity.normalized * maxSpeed;
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(horizontal, 0f, vertical);
        float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
        Vector3 force = Quaternion.Euler(0f,angle,0f) * Vector3.forward;
 
        rb.AddForce(force * Time.deltaTime * speed * moveDir.magnitude, ForceMode.VelocityChange);
    }

    void Jump() {
        rb.AddForce(jumpForce, ForceMode.VelocityChange);
    }
}


