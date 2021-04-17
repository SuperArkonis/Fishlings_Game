using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public GameObject bobber;
    public GameObject castText;
    float zStartPos;
    public float speed = 8;
    public float distance;
    Vector3 startPoint;
    public bool fishHit = false;
    public Fishventory fish;

    // Start is called before the first frame update
    void Start()
    {
        bobber.transform.localPosition = new Vector3(0, 0.5f, 0);
        startPoint = bobber.transform.localPosition;
        zStartPos = bobber.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Water")
        {
            //Debug.Log("Fishing Area");
            castText.SetActive(true);
            if(Input.GetKey(KeyCode.Space))
            {
                bobber.SetActive(true);
                
                if((speed < 0 && bobber.transform.localPosition.z < zStartPos) || (speed > 0 && bobber.transform.localPosition.z > zStartPos + distance))
                {
                    speed *= -1;
                }
                bobber.transform.localPosition = new Vector3(bobber.transform.localPosition.x, bobber.transform.localPosition.y, bobber.transform.localPosition.z + speed * Time.deltaTime);
            }   
            else if(Input.GetKeyUp(KeyCode.Space))
            {
                speed = 0;
                if(fishHit)
                {
                    Debug.Log("Fish Caught!");
                    fish.AddItem((FishType)Random.Range(0, 4));
                }
            }

            if(Input.GetKey(KeyCode.E))
            {
                bobber.SetActive(false);
                bobber.transform.localPosition = startPoint;
                fishHit = false;
                speed = 8;  
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
        }
    }

}
