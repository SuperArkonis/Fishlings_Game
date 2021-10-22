using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public GameObject fish;
    public float speed = 8f;
    public float distance = 12f;
    float zStartPos;
    // Start is called before the first frame update
    void Start()
    {
        zStartPos = fish.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if((speed < 0 && fish.transform.localPosition.z < zStartPos) || (speed > 0 && fish.transform.localPosition.z > zStartPos + distance))
        {
            speed *= -1;
        }
        fish.transform.localPosition = new Vector3(fish.transform.localPosition.x, fish.transform.localPosition.y, fish.transform.localPosition.z + speed * Time.deltaTime);
    }
}
