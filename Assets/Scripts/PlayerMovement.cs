using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 200f;
    public Camera mainCamera;
    public Vector3 jumpForce;
    public float maxSpeed;

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }
    
    void Move() {
        if (rb.velocity.magnitude > maxSpeed) {
            rb.velocity = rb.velocity.normalized * maxSpeed;
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


