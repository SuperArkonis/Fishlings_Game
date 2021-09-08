using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishMinigame : MonoBehaviour
{

    public UnityEvent OnMinigameWin;
    public UnityEvent OnMinigameLose;
    
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [SerializeField] Transform fish;

    float fishPos;
    float fishDest;
    float fishTimer;

    [SerializeField] float timerMultiplier = 3f;
    float fishSpeed;

    [SerializeField] float smoothMotion = 1f;
    [SerializeField] Transform hook;
    float hookPos;
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower = 5f;
    float hookProg;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravPower = 0.005f;
    [SerializeField] float hookProgDegredationPower = 0.1f;

    [SerializeField] Transform progBarContainer;

    private float hundredpctLocalScale;
    public float initialCompletion = 0.8f;

    void Start()
    {
        //Resize();
        hundredpctLocalScale = progBarContainer.localScale.y;
        SetProgress(initialCompletion);
    }
    
    // Update is called once per frame
    void Update()
    {
        Fish();
        Hook();
        ProgressCheck();
    }

    public void Reset()
    {
        Vector3 ls = progBarContainer.localScale;
        ls.y = 0.4f * hundredpctLocalScale;
        progBarContainer.localScale = ls;
    }

    void SetProgress(float pct)
    {
        Vector3 ls = progBarContainer.localScale;
        float val = Mathf.Clamp(pct * hundredpctLocalScale, 0f, hundredpctLocalScale);
        ls.y = val;
        progBarContainer.localScale = ls;

        if (val < 0.01f)
        {
            Debug.Log("You lost");
            OnMinigameLose.Invoke();
            
        }
        else if (pct > 0.99f)
        {
            Debug.Log("you win");
            OnMinigameWin.Invoke();
            
        }
    }

    void ProgressCheck()
    {
        //Vector3 ls = progBarContainer.localScale;
        //ls.y = hookProg;
        //progBarContainer.localScale = ls;

        float min = hookPos - hookSize / 2;
        float max = hookPos + hookSize / 2;

        if(min< fishPos && fishPos < max)
        {
            hookProg += hookPower * Time.deltaTime;
        }
        else
        {
            hookProg -= hookProgDegredationPower * Time.deltaTime;
        }

        hookProg = Mathf.Clamp(hookProg, 0f, 1.0f);
        SetProgress(hookProg);
    }

    void Hook()
    {
        if(Input.GetMouseButton(0))
        {
            //Debug.Log("ButtonPressed");
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }
        hookPullVelocity -= hookGravPower * Time.deltaTime;
        hookPullVelocity = Mathf.Clamp(hookPullVelocity, -1, 1);
        hookPos += hookPullVelocity;
        hookPos = Mathf.Clamp(hookPos, hookSize/2, 1 - hookSize/2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPos);
    }

    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if(fishTimer < 0f)
        {
            fishTimer = UnityEngine.Random.value * timerMultiplier;
            fishDest = UnityEngine.Random.value;
        }

        fishPos = Mathf.SmoothDamp(fishPos, fishDest, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPos);
    }

    void Resize()
    {
        Vector3 imageLS = hook.localScale;
        float distance = Vector3.Distance(topPivot.position, bottomPivot.position);
        imageLS.y = (distance / imageLS.y*hookSize);
    }
}
