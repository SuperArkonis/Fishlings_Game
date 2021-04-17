using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public GameObject inventory;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotationSpeed = 100.0f;

    Vector3 moveDirection = Vector3.zero;
    Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        //characterController.Move(moveDirection * Time.deltaTime);

        //Rotate character with movement
        this.rotation = new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        Vector3 move = new Vector3(0, 0, Input.GetAxis("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        characterController.Move(move * speed);
        this.transform.Rotate(this.rotation);
        

        if(Input.GetKeyDown(KeyCode.Tab))
        {

        }
    }
}*/
