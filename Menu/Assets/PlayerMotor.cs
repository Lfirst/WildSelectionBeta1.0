using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {
    public Camera cam;
    private Vector3 velocityM = Vector3.zero;
    private Vector3 rotationM = Vector3.zero;
    private Vector3 CameraRotationM = Vector3.zero;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Get a movement Vector

    public void Move(Vector3 velocityC)
    {
        velocityM = velocityC;
    }

    // Get a rotational Vector

    public void Rotate(Vector3 rotationC)
    {
        rotationM = rotationC;
    }

    // Get a camera rotational Vector

    public void RotateCamera(Vector3 CameraRotationC)
    {
        CameraRotationM = CameraRotationC;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Perform movement based on velocty variable
    void PerformMovement()
    {
        if (velocityM != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocityM * Time.fixedDeltaTime);
        }
    }

    //Perform rotation
    void PerformRotation()
    {

        rb.MoveRotation(rb.rotation* Quaternion.Euler(rotationM));

        if (cam != null)
        {
            cam.transform.Rotate(CameraRotationM);
            
        }
    }


}
