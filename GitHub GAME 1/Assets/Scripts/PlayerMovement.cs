using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody my_Rigidbody;
    public Transform cam;
    //private Transform cameraMainTransform;
    public float jumpForce = 1f;
    // Start is called before the first frame update
    public float turnSmoothTime = 0.001f;
    float turnSmoothVelocity;

    void FixedUpdate()
    {
        //wasd xy movement
       if (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w") || Input.GetKey("s"))
        {
            Vector3 my_Input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            //move relative to camera
            //my_Input = cameraMainTransform.forward * my_Input.z + cameraMainTransform.right * my_Input.x;
            //my_Input.y = 0f;
            float targetAngle = Mathf.Atan2(my_Input.x, my_Input.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angleY = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angleY, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            my_Rigidbody.MovePosition(transform.position + moveDirection.normalized * Time.deltaTime * 5f);
        }
        //jump code (hopefully)
       if (Input.GetKey("space"))
        {
            Vector3 jumpVector3 = new Vector3(0, Input.GetAxis("Jump") * jumpForce, 0);
            //my_Rigidbody.MovePosition(transform.position += Vector3.up * jumpForce * Time.deltaTime);
            my_Rigidbody.AddForce(jumpVector3,ForceMode.VelocityChange);
        }
       
        
    }
}
