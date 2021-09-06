using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobberHit : MonoBehaviour
{
    public bool fishHit = false;
    public Fishventory fish;

    // Update is called once per frame
    void Update()
    {
        if(fishHit)
        {
            Debug.Log("Fish Caught!");
            fish.AddItem((FishType)Random.Range(0, 4));
            fishHit = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Fish")
        {
            fishHit = true;
            Destroy(col.gameObject);
        }
    }
}
