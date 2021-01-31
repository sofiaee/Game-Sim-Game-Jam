using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersonmovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f; 
    public float RotationSmoothing = 0.1f; //smooths the rotation of character towards the target angle they're facing higher value equals more smoothing but slower/less responsive turning
    float turnSmoothVelocity;
    public Transform cam;
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //calculates angle player is facing

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, RotationSmoothing);

            transform.rotation = Quaternion.Euler(0f, angle, 0f); //roates character towards target angle
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime); //moves character
        }
    }
}
