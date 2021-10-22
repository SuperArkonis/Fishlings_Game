using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastUI : MonoBehaviour
{
    public Transform m_Camera;
	/*public bool amActive =false;
	public bool autoInit =false;
	GameObject myContainer;	
 
	void Awake(){
		if (autoInit == true){
			m_Camera = Camera.main;
			amActive = true;
		}
 
		myContainer = new GameObject();
		myContainer.name = "GRP_"+transform.gameObject.name;
		myContainer.transform.position = transform.position;
		transform.parent = myContainer.transform;
	}
 
    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate(){
        if(amActive==true){
        	myContainer.transform.LookAt(myContainer.transform.position + m_Camera.transform.rotation * Vector3.back, m_Camera.transform.rotation * Vector3.up);
	    }
    }*/

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(m_Camera);
    }
}
