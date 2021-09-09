using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobberHit : MonoBehaviour
{
    public bool fishHit = false;
    public Fishventory fish;
    public Collider collider;
    public GameObject minigame;

    public AudioManager sound;

    void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        collider.enabled = true; //turn the collider back on if it is off.
        Debug.Log("Collider Enabled");
    }

    // Update is called once per frame
    void Update()
    {
        /*if(fishHit)
        {
            Debug.Log("Fish Caught!");
            fish.AddItem((FishType)Random.Range(0, 4));
            fishHit = false;
        }*/
        if(Input.GetKey(KeyCode.E))
        {
            sound.Stop("Reel");
            minigame.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Fish")
        {
            //fishHit = true;
            //Destroy(col.gameObject);
            collider.enabled = false; //turn off the collider
            Debug.Log("Collider Off");
            minigame.SetActive(true);
            sound.Play("Fish");
            sound.Play("Reel");
        }
    }

    public void GiveFish()
    {
        fish.AddItem((FishType)Random.Range(0, 4));
    }
}
