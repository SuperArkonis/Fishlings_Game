using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject shopKeeper;
    public GameObject shopMenu;

    void Update()
    {
        /*if(OnTriggerStay)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Start Convo");
                dialogueBox.SetActive(true);
                //shopKeeper.DialogueTrigger.TriggerDialogue();
                shopKeeper.GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }*/

        if(shopMenu.activeInHierarchy)
        {
            dialogueBox.SetActive(false);
        }
        if(Input.GetKey(KeyCode.P))
        {
            shopMenu.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Shopkeep")
        {
            Debug.Log("In Area");
            //if (Input.GetKey(KeyCode.E))
            //{
                Debug.Log("Start Convo");
                dialogueBox.SetActive(true);
                //shopKeeper.DialogueTrigger.TriggerDialogue();
                shopKeeper.GetComponent<DialogueTrigger>().TriggerDialogue();
            //}
        }
    }
    void OnTriggerExit(Collider other)
    {
        dialogueBox.SetActive(false);
    }
}
