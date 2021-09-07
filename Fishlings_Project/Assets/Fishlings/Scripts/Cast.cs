using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CastingState
{
    START_CAST,
    MID_CAST,
    END_CAST,
    NOT_CASTING
}

public class Cast : MonoBehaviour
{
    public Animator bobberAnims;
    public Animator rodAnim;
    public Animator playerAnim;
    public CastingState castingState;
    public PlayerAttributes attributes;
    public GameObject bobber;
    public GameObject castText;
    public Transform castTarget; //end position for bobber
    public float waterSurfaceYCoord = 0.0f;
    public Transform bobberStartPosition;
    public float castTime = 2.0f;
    float castTimeElapsed;
    public bool fishHit = false;
    public Fishventory fish;

    public LayerMask whatIsWater;
    // Start is called before the first frame update
    void Start()
    {
        castingState = CastingState.NOT_CASTING;
    }

    // Update is called once per frame
    void Update()
    {
        if (castingState == CastingState.START_CAST)
        {
            //begin the cast.
            bobber.SetActive(true);
            bobber.transform.position = bobberStartPosition.position;
            attributes.canMove = false;
            castTimeElapsed = 0.0f;
            castingState = CastingState.MID_CAST;
            rodAnim.Play("Base Layer.Rod Pull");
            bobberAnims.Play("Base Layer.BobberCast");
            playerAnim.Play("Base Layer.Cast");
        }
        if (castingState == CastingState.MID_CAST)
        {
            castTimeElapsed += Time.deltaTime;
            if (castTimeElapsed >= castTime)
            {
                castingState = CastingState.END_CAST;
                bobber.transform.position = new Vector3(
                    bobber.transform.position.x,
                    waterSurfaceYCoord,
                    bobber.transform.position.z);
            }
            else
            {
                Vector3 waterPos = new Vector3(castTarget.position.x,
                                waterSurfaceYCoord,
                                castTarget.position.z);
                bobber.transform.position = Vector3.Lerp(bobberStartPosition.position, 
                                            waterPos, castTimeElapsed / castTime);
            }
        }
        if (castingState == CastingState.END_CAST)
        {
            
            //Other things to do would go here.
            bobberAnims.Play("Base Layer.BobberBob");
            //Allow canceling.
            if(Input.GetKey(KeyCode.E))
            {
                CastingCancelled();
            }
            
        }
        if(fishHit)
        {
            Debug.Log("Fish Caught!");
            fish.AddItem((FishType)Random.Range(0, 4));
            fishHit = false;
        }
    }

    void TryCast()
    {
        if (castingState != CastingState.NOT_CASTING)
            return;

        castingState = CastingState.START_CAST;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Water"))
        {
            Debug.Log("Collided with water");
            Collider[] watercols = Physics.OverlapSphere(castTarget.position, 0.05f, whatIsWater);
            attributes.canCast = true;
            if (watercols.Length > 0)
            {
                castText.SetActive(true);
                if (Input.GetKey(KeyCode.Space))
                {
                    TryCast();
                }
            }
            else
            {
                castText.SetActive(false);
            }
        }
        else
        {
            castText.SetActive(false);
        }
    }

    public void CastingCancelled()
    {
        bobberAnims.Play("Base Layer.NoAnim");
        rodAnim.Play("Base Layer.Rod Idle");
        playerAnim.Play("Base Layer.Player_Idle");
        bobber.SetActive(false);
        attributes.canMove = true;
        attributes.canCast = true;
        castingState = CastingState.NOT_CASTING;
    }
}
