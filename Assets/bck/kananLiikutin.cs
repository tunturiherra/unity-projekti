using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kananLiikutin : MonoBehaviour
{
    [SerializeField]
    float speed;
    public Rigidbody physic;

    [SerializeField]
    float turnSpeed;

    [SerializeField]
    float turboSpeed;

    private Transform holdableItem;

    bool wKeyPressed = false;
    bool aKeyPressed = false;
    bool sKeyPressed = false;
    bool dKeyPressed = false;
    bool shiftKeyPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        physic = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            wKeyPressed = true;
        }
        else
        {
            wKeyPressed = false;
        }

        if (Input.GetKey("s"))
        {
            sKeyPressed = true;
        }
        else
        {
            sKeyPressed = false;
        }
        if (Input.GetKey("a"))
        {
            aKeyPressed = true;
        }
        else
        {
            aKeyPressed = false;
        }
        if (Input.GetKey("d"))
        {
            dKeyPressed = true;
        }
        else
        {
            dKeyPressed = false;
        }
        if (Input.GetKey("left shift"))
        {
            shiftKeyPressed = true;
        }
        else
        {
            shiftKeyPressed = false;
        }

        if (holdableItem != null)
        {
            Vector3 headPosition = transform.TransformPoint(new Vector3(0, 1, 0)); // 1.5f on arvioitu korkeus
            holdableItem.position = headPosition; // Aseta esineen sijainti
        }

        if (Input.GetKeyDown(KeyCode.Q) && holdableItem != null)
        {
            // Laske esineen sijainti pelaajan eteen (1 metrin p��h�n pelaajasta)
            Vector3 dropPosition = transform.TransformPoint(Vector3.forward * 2);
            holdableItem.position = dropPosition;

            // Vapauta esine
            holdableItem = null;
        }
    }

    
    
    void FixedUpdate()
    {
        if (wKeyPressed == true)
        {
            physic.AddRelativeForce(Vector3.forward * speed);
        }
        if (aKeyPressed == true)
        {
            physic.AddRelativeTorque(Vector3.down * turnSpeed);
        }
        if (sKeyPressed == true)
        {
            physic.AddRelativeForce(Vector3.back * speed);
        }
        if (dKeyPressed == true)
        {
            physic.AddRelativeTorque(Vector3.up * turnSpeed);
        }
        if (shiftKeyPressed == true)
        {
            physic.AddRelativeForce(Vector3.forward * turboSpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Lattia")
        {
            return; // Ohita lattian t�rmäys
        }

        // Varmistetaan, ettei toinen esine ole jo nostettuna
        if (holdableItem == null)
        {
            if (collision.gameObject.name == "ilmastointiteippi" || 
                collision.gameObject.name == "tyokalupakki" || 
                collision.gameObject.name == "sorkkarauta" || 
                collision.gameObject.name == "taskulamppu")
            {
                holdableItem = collision.transform;
                Debug.Log("Osuit kohteeseen: " + holdableItem.name);
            
                // Jos haluat varmistaa, että esine pysyy päällä, voit asettaa sen kineettiseksi
                var rb = holdableItem.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true; // Pysyy paikoillaan eikä putoa
                }
            }
        }
    }




}
