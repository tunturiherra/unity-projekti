using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody physic;
    public float jumpHeight;
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
            physic.AddRelativeForce(Vector3.forward*speed);
        }
         if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Keycap S has been pressed.");
            physic.AddRelativeForce(-Vector3.forward*speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Keycap A has been pressed.");
            // -1, 0, 0 * 10 = -10, 0 ,0
            physic.AddRelativeForce(Vector3.left*speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Keycap D has been pressed.");
            physic.AddRelativeForce(Vector3.right*speed);
        }

    if (isGrounded)
   {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Keycap space has been pressed.");
            physic.AddForce(Vector3.up * jumpHeight);
        }
   }
       
    }
void OnCollisionEnter(Collision other)
{
    if (other.gameObject.tag == "Ground")
    {
        isGrounded = true;
    }
}

void OnCollisionExit(Collision other)
{
    if (other.gameObject.tag == "Ground")
    {
        isGrounded = false;
    }
}
}
