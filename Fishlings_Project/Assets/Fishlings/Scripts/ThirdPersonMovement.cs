using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public PlayerAttributes attributes;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    float gravity = 9.8f;
    float vspeed = 0f;
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        attributes = GetComponent<PlayerAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attributes.canMove == true)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            //applies gravity to character controller
            vspeed -= gravity * Time.deltaTime;
            if(direction.x != 0f || direction.z != 0f)
            {
                direction.y = vspeed;
            }
        

            //rotates character to movement direction
            if(direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                controller.Move(direction * speed * Time.deltaTime);
            }
        }
        
    }
}
