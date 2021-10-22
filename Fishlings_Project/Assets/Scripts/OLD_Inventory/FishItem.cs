using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishItem : MonoBehaviour
{
    public Image fishImage;
    public TextMeshProUGUI fishName;
    public TextMeshProUGUI fishNumber;
    int _fishNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(FishType ftype, FishReference fr, int num = 1)
    {
        FishDetails fd = fr.GetDetailsFor(ftype);
        if (fd != null)
        {
            fishName.text = fd.fishName;
            fishImage.sprite = fd.fishSprite;
            fishNumber.text = num.ToString();
            _fishNumber = num;
        }
    }
    public void AlterNumber(int val)
    {
        _fishNumber += val;
        fishNumber.text = _fishNumber.ToString();
    }

}
