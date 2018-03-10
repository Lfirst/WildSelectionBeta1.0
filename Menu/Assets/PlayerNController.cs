using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerNController : MonoBehaviour {

    public float speed = 5f;
    public float lookSensitivity = 3f;
    public float gravity = 10;
    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }
    private void Update()
    {
        //Calculate movement velocity as a 3D vector
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        float yMove = Input.GetAxisRaw("Jump");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;
        Vector3 moveUp = transform.up * (yMove-gravity) ;

        //final movement vector
        Vector3 velocityC = (moveHorizontal + moveVertical).normalized * speed;

        //Apply movement
        motor.Move(velocityC);

        //Calculate rotation as a 3d vector (turning around)
        float yRotC = Input.GetAxisRaw("Mouse X");

        //Only rotation on y for the player and the camera (Vertical)
        Vector3 rotationC = new Vector3(0f, yRotC, 0f) * lookSensitivity;

        //Apply rotation
            motor.Rotate(rotationC);

        //Calculate camera rotation as a 3d vector 
        float xRotC = Input.GetAxisRaw("Mouse Y");
        //Only rotation on y for the camera (Horizontal)
        Vector3 CameraRotationC = new Vector3(xRotC,0f,  0f) * lookSensitivity;

        //Apply camera rotation ( There is a - before camera rotation to inverse axe x)
        motor.RotateCamera(-CameraRotationC);





    }

}
