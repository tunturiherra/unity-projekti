using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChicken : MonoBehaviour
{
    public float speed;
    public float turnforce;
    public Rigidbody physic;
    public float jump;
    public bool isGrounded;
    

    // Start is called before the first frame update
    void Start()
    {
        physic = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Keycap W has been pressed.");
            physic.AddRelativeForce(Vector3.forward * speed);
        }
         if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Keycap S has been pressed.");
            physic.AddRelativeForce(Vector3.forward* -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Keycap A has been pressed.");
            // -1, 0, 0 * 10 = -10, 0 ,0
            physic.AddRelativeTorque(Vector3.up * - turnforce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Keycap D has been pressed.");
            physic.AddRelativeTorque(Vector3.up * turnforce);
        }

         if ( Input.GetKey(KeyCode.Space) && isGrounded == false )
        {
            Debug.Log("Keycap Space has been pressed.");
            physic.AddRelativeForce(Vector3.up * jump );
            isGrounded = true;
        }
    }

    void OnCollisionEnter (Collision collision)
    {
        Debug.Log("Collision detected."+collision.gameObject);
        isGrounded = false;
    }
}
