using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour {

    public float FlySpeed = 5;
    public float YawAmount = 120;
    public Transform propeller;
    
    
    float speed_rotate_propeller;
    float Yaw;

    // Update is called once per frame
    void Update() {

        // move forward
        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        // inputs ...also you can using Joystick
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // yaw, pitch, roll
        Yaw += horizontalInput * YawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        // apply rotation
        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);

        // apply rotate propeller  
        speed_rotate_propeller += 10 ;
		propeller.Rotate (0.0f , 0.0f, speed_rotate_propeller);
    }
}
