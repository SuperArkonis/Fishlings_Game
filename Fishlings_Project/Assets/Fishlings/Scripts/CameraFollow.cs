using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    /*public GameObject player;
    //store offset between player and camera
    Vector3 offset; 

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    //LateUpdate is called after Update to account for positional and rotational changes smoothly
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }*/

    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera fishCam;

    void Start()
    {
        mainCam.Priority = 1;
        fishCam.Priority = 0;
    }

    void Update()
    {
        //swap camera view when going into and out of fishing mode
        if(Input.GetKeyUp(KeyCode.Space))
        {
            mainCam.Priority = 0;
            fishCam.Priority = 1;
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            mainCam.Priority = 1;
            fishCam.Priority = 0;
        }
    }
}
//Reference: https://www.tech-recipes.com/rx/75347/how-to-set-camera-to-follow-the-player-in-unity-3d-game-development/