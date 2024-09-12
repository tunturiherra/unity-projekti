using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kananLiikutin : MonoBehaviour
{   
    public float speed;
    public Rigidbody physic;

    // Start is called before the first frame update
    void Start()
    {
        physic = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
        {
            physic.AddRelativeForce(Vector3.forward * speed);

        }
        if(Input.GetKey("s"))
        {
            physic.AddRelativeForce(Vector3.back * speed);

        }
            if(Input.GetKey("a"))
        {
            physic.AddRelativeTorque(Vector3.down * speed);

        }
            if(Input.GetKey("d"))
        {
            physic.AddRelativeTorque(Vector3.up * speed);

        }
    }
}
