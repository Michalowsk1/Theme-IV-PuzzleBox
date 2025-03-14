using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;
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
        if (BodyChange.Human)
        {
            // Jump when the Jump button is pressed and we are on the ground.
            if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded))
            {
                rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
                Jumped?.Invoke();
            }
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
                jumpStrength = jumpStrength + 0.1f;

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
}

