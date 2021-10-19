using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootItem
{
    public string name;
    public ItemObject item;
    [Header("Don't put -ve prob")]
    public float probability;
}

public class BobberHit : MonoBehaviour
{

    public LootItem[] lootTable;
    public bool fishHit = false;
    //public Fishventory fish;
    public InventoryObject playerInventory;
    public Collider collider;
    public GameObject minigame;

    public AudioManager sound;
    float totalLootProbability;

    void OnEnable()
    {
        Reset();
        totalLootProbability = 0;
        foreach (LootItem l in lootTable )
        {
            totalLootProbability += l.probability;
        }
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
            minigame.GetComponent<FishMinigame>().Reset();
            sound.Play("Fish");
            sound.Play("Reel");
        }
    }

    public ItemObject RandomLootTableItem()
    {
        ItemObject retval = null;
        if (totalLootProbability > 0)
        {
            //Make a random roll from 0 to the total of all item probs.
            //Then sequentially subtract from that roll and choose the 
            //item that causes the transition past 0.
            float randomRoll = Random.Range(0, totalLootProbability);
            foreach (LootItem l in lootTable)
            {
                randomRoll -= l.probability;
                if (randomRoll <= 0)
                {
                    retval = l.item;
                    break;
                }
            }
        }
        return retval;
    }

    public void GiveFish()
    {
        ItemObject randomItem = RandomLootTableItem();
        if (randomItem != null)
        {
            playerInventory.AddItem(RandomLootTableItem(), 1);
        }
        else
        {
            Debug.LogError("Random loot table lookup problem");
        }
        //fish.AddItem((FishType)Random.Range(0, 4));
    }
}
