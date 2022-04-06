using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody my_Rigidbody;
    //private Transform cameraMainTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        //cameraMainTransform = cameraMainTransform.main.transform;
    }

    // Update is called once per frame(matched to unity frame cap)
    void FixedUpdate()
    {
        //wasd xy movement
       if (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w") || Input.GetKey("s"))
        {
            Vector3 my_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //move relative to camera
            //my_Input = cameraMainTransform.forward * my_Input.z + cameraMainTransform.right * my_Input.x;
            //my_Input.y = 0f;
            my_Rigidbody.MovePosition(transform.position + my_Input * Time.deltaTime * 5f);
        }
       //jump code (hopefully)
       if (Input.GetKey("space"))
        {
            my_Rigidbody.MovePosition(transform.position += Vector3.up * Time.deltaTime);
        }

        
    }
}
