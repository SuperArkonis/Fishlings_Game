using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
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
    }
}
//Reference: https://www.tech-recipes.com/rx/75347/how-to-set-camera-to-follow-the-player-in-unity-3d-game-development/