using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public GameObject inventoryCanvas;
    public bool canMove = true;
    public Canvas canvas;
    public bool canCast = true;
    Vector3 playerStart;

    private void Awake()
    {
        canvas = inventoryCanvas.GetComponent<Canvas>();
        playerStart = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
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
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Safety")
        {
            Debug.Log("Kill Zone");
            this.transform.position = playerStart;
        }
    }
}
