using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
     [Tooltip("Maximum slope the character can jump on")]
    [Range(5f, 60f)]
    public float slopeLimit = 45f; //prevents going up slopes steeper than the float
    [Tooltip("Move speed in metres/second")]
    public float moveSpeed = 6f;
    [Tooltip("Turn speed in degrees/second, left (+) or right (-)")]
    public float turnSpeed = 200;

    
    public float ForwardInput { get; set; }
    public float TurnInput { get; set; }
    public GameObject inventoryCanvas;
    public bool canMove = true;
    public Canvas canvas;

    new private Rigidbody rigidbody;
    private CapsuleCollider capsuleCollider;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        canvas = inventoryCanvas.GetComponent<Canvas>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.enabled = !canvas.enabled;
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        ProcessActions();
    }


    void ProcessActions() //converts inputs into movement
    {
        if(canMove)
        {
            // Turning
            if (TurnInput != 0f)
            {
                float angle = Mathf.Clamp(TurnInput, -1f, 1f) * turnSpeed;
                transform.Rotate(Vector3.up, Time.fixedDeltaTime * angle);

            }

            // Movement
            Vector3 move = transform.forward * Mathf.Clamp(ForwardInput, -1f, 1f) *
                moveSpeed * Time.fixedDeltaTime;
            rigidbody.MovePosition(transform.position + move);
        }

    }
}

//reference: https://www.immersivelimit.com/tutorials/simple-character-controller-for-unity