using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishInventoryUI : MonoBehaviour
{
    public FishReference fishReference;
    public FishItem fishItemUIPrefab;
    public Dictionary<FishType, FishItem> _fishDict;
    
    void Awake()
    {
        _fishDict = new Dictionary<FishType, FishItem>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateWithNewFish(FishType t)
    {
        if (_fishDict.ContainsKey(t))
        {
            _fishDict[t].AlterNumber(1);
        }
        else
        {
            FishItem item = Instantiate(fishItemUIPrefab);
            item.Init(t, fishReference);
            item.transform.SetParent(transform);
            _fishDict[t] = item;
        }
    }

}
