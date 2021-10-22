using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public PlayerAttributes attributes;
    public AudioManager sound;

    Vector3 initialDirectionForward;
    Vector3 initialDirectionRight;
    

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    float gravity = 9.8f;
    float vspeed = 0f;
    Animator playerAnim;
    Animator rodAnim;
    public GameObject player;
    public GameObject rod;
    public GameObject shop;
    AudioSource steps;
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        attributes = GetComponent<PlayerAttributes>();
        playerAnim = player.GetComponent<Animator>();
        rodAnim = rod.GetComponent<Animator>();
    }

    void Start()
    {
        initialDirectionForward = transform.forward;
        initialDirectionForward.y = 0;
        initialDirectionRight = transform.right;
        initialDirectionRight.y = 0;
        steps = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attributes.canMove == true)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //controller will use this as world relative
            //Vector3 camdirection = Camera.main.transform.forward;

            //applies gravity to character controller
            vspeed -= gravity * Time.deltaTime;
            if(direction.x != 0f || direction.z != 0f)
            {
                direction.y = vspeed;
            }
        

            //rotates character to movement direction
            if(direction.magnitude >= 0.1f)
            {
                //convert the direction to reflect 'forward' and 'right' in terms of player's initial rotation
                Vector3 moveDirection = (initialDirectionForward * vertical + initialDirectionRight * horizontal).normalized;
                direction.x = moveDirection.x;
                direction.z = moveDirection.z;
                controller.Move(direction * speed * Time.deltaTime);

                //Final rotation of character model depends on calculated direction
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                
                playerAnim.Play("Base Layer.Run");
                rodAnim.Play("Base Layer.Rod Run");

                attributes.isMoving = true;

                //sound.Play("Steps");
            }
            if(direction.magnitude < 0.1f)
            {
                playerAnim.Play("Base Layer.Player_Idle");
                rodAnim.Play("Base Layer.Rod Idle");
                attributes.isMoving = false;
            }
        }
        
        if(attributes.isMoving && !steps.isPlaying)
        {
            //sound.Play("Steps");
            steps.Play();
        }
        if(!attributes.isMoving)
        {
            steps.Stop();
        }

        if(shop.activeSelf)
        {
            attributes.canMove = false;
        }
        else if(!shop.activeSelf)
        {
            attributes.canMove = true;
        }
    }
}
