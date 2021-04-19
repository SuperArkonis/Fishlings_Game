using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public GameObject bobber;
    public GameObject castText;
    float zStartPos;
    public float startSpeed = 12;
    public float speed;
    public float distance;
    Vector3 startPoint;
    public bool fishHit = false;
    public Fishventory fish;
    public bool canCast = true;
    public GameObject player;
    public SimpleCharacterController playerMove;

    // Start is called before the first frame update
    void Start()
    {
        bobber.transform.localPosition = new Vector3(0, 0.5f, 0);
        startPoint = bobber.transform.localPosition;
        zStartPos = bobber.transform.position.z;
        playerMove = player.GetComponent<SimpleCharacterController>();
        speed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Casting Stopped");
            speed = 0;
            canCast = false;
        }
        if(fishHit)
        {
            Debug.Log("Fish Caught!");
            fish.AddItem((FishType)Random.Range(0, 4));
            fishHit = false;
        }
    }

    void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Water")
        {
            //Debug.Log("Fishing Area");
            castText.SetActive(true);
            if(Input.GetKey(KeyCode.Space) && canCast == true)
            {
                bobber.SetActive(true);
                playerMove.canMove = false;
                
                if((speed < 0 && bobber.transform.localPosition.z < zStartPos) || (speed > 0 && bobber.transform.localPosition.z > zStartPos + distance))
                {
                    speed *= -1;
                }
                bobber.transform.localPosition = new Vector3(bobber.transform.localPosition.x, bobber.transform.localPosition.y, bobber.transform.localPosition.z + speed * Time.deltaTime);
            }   
            //else 

            if(Input.GetKey(KeyCode.E))
            {
                bobber.SetActive(false);
                playerMove.canMove = true;
                canCast = true;
                bobber.transform.localPosition = startPoint;
                fishHit = false;
                speed = startSpeed;  
            }
        }

             
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            castText.SetActive(false);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fish")
        {
            fishHit = true;
            Destroy(other.gameObject);
        }
    }

}
