using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{

    //*** CODE FROM HERE


    [SerializeField] Rigidbody rigidbody;
    public float jumpStrength = 2;
    public event System.Action Jumped;

    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;


    void Reset()
    {
        // Try to get groundCheck.
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        // Get rigidbody.
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (BodyChange.Human) //NOT INCLUDING
        {

            // Jump when the Jump button is pressed and we are on the ground.
            if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded))
            {
                rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
                Jumped?.Invoke();
            }

            ///*** TO HERE REFERNCED IN README FILE UNDER MOVEMENT TITLE
        }

        if (BodyChange.Bird)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rigidbody.AddForce(Vector3.up * 1.5f * jumpStrength);
            }
        }

        if (BodyChange.Spider)
        {
            
            if (Input.GetKey(KeyCode.Space))
            {
                jumpStrength = jumpStrength + 0.2f;

                if(jumpStrength > 25)
                {
                    jumpStrength = 25;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rigidbody.AddForce(Vector3.up * 10 * jumpStrength);
                jumpStrength = 0;
            }
        }
    }

    IEnumerator CeilingHit()
    {
        yield return new WaitForSeconds(2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(BodyChange.Bird)
        {
            if(collision.gameObject.tag == "Ceiling")
            {
                jumpStrength = 0;
                StartCoroutine(CeilingHit());
                jumpStrength = 2;
            }
        }
    }
}

