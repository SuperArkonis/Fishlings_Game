using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fishing : MonoBehaviour
{
    public GameObject bobber;
    public GameObject castText;
    public TMP_Text text;
    float zStartPos;
    public float startSpeed = 12;
    public float speed;
    public float distance;
    Vector3 startPoint;
    public bool fishHit = false;
    public Fishventory fish;
    public GameObject player;
    public PlayerAttributes attributes;
    Vector3 newScale;
    Vector3 oldScale;

    public float firingAngle = 45f;
    public float gravity = 9.8f;
    public Transform projectile;
    Transform myTrans;
    public Transform target;
    

    // Start is called before the first frame update
    void Start()
    {
        //bobber.transform.localPosition = new Vector3(0, 0.5f, 0);
        //startPoint = bobber.transform.localPosition;
        myTrans = transform;
        //zStartPos = bobber.transform.position.z;
        attributes = GetComponent<PlayerAttributes>();
        speed = startSpeed;
        newScale = new Vector3(text.transform.localScale.x * -1f, text.transform.localScale.y, text.transform.localScale.z);
        oldScale = new Vector3(text.transform.localScale.x, text.transform.localScale.y, text.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Casting Stopped");
            speed = 0;
            attributes.canCast = false;
        }
        if(fishHit)
        {
            Debug.Log("Fish Caught!");
            fish.AddItem((FishType)Random.Range(0, 4));
            fishHit = false;
        }

        //face cast text towards camera always
        /*if(player.transform.eulerAngles.y >= -89f || player.transform.eulerAngles.y <= 89f)
        {
            text.transform.localScale = oldScale;
        }
        if(player.transform.eulerAngles.y <= -90f || player.transform.eulerAngles.y >= 90f)
        {
            text.transform.localScale = newScale;
        }*/
    }

    void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Water")
        {
            //Debug.Log("Fishing Area");
            castText.SetActive(true);
            if(Input.GetKey(KeyCode.Space) && attributes.canCast == true)
            {
                bobber.SetActive(true);
                attributes.canMove = false;

                StartCoroutine(SimulateProjectile());
                
                /*if((speed < 0 && bobber.transform.localPosition.z < zStartPos) || (speed > 0 && bobber.transform.localPosition.z > zStartPos + distance))
                {
                    speed *= -1;
                }
                bobber.transform.localPosition = new Vector3(bobber.transform.localPosition.x, bobber.transform.localPosition.y, bobber.transform.localPosition.z + speed * Time.deltaTime);*/
            }   
            //else 

            if(Input.GetKey(KeyCode.E))
            {
                bobber.SetActive(false);
                attributes.canMove = true;
                attributes.canCast = true;
                //bobber.transform.localPosition = startPoint;
                fishHit = false;
                //speed = startSpeed;  
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

    //reference https://forum.unity.com/threads/throw-an-object-along-a-parabola.158855/#post-1087673
    IEnumerator SimulateProjectile()
    {

        myTrans = target;
       
        // Move projectile to the position of throwing object + add some offset if needed.
        projectile.position = myTrans.position + new Vector3(0, 0.5f, 0);
       
        // Calculate distance to target
        float target_Distance = Vector3.Distance(projectile.position, target.position);
 
        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
 
        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
 
        // Calculate flight time.
        float flightDuration = target_Distance / Vx;
   
        // Rotate projectile to face the target.
        projectile.rotation = Quaternion.LookRotation(target.position - projectile.position);
       
        float elapse_time = 0;
 
        while (elapse_time < flightDuration)
        {
            projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
           
            elapse_time += Time.deltaTime;
 
            yield return null;
        }
    }  
}
