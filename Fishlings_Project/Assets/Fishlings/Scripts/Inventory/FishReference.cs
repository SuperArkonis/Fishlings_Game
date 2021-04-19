using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishDetails
{
    public FishType fishType;
    public Sprite fishSprite;
    public string fishName;
    public int fishPrice;
}

public class FishReference : MonoBehaviour
{
    public FishDetails[] fishDetails;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public FishDetails GetDetailsFor(FishType t)
    {
        foreach (FishDetails f in fishDetails)
        {
            if (f.fishType == t)
            {
                return f;
            }
        }
        return null;
    }
}
