/* using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject chickenObject;
    public float cameraDistance = 4f;
    public float cameraHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        chickenObject = GameObject.Find("KANA");
    }

    // Update is called once per frame
    void Update()
    {
        

        // kameran kiinteä piste
        // transform.position = new Vector3(10f, 5f, 3f);

        transform.position = chickenObject.transform.position + 
            Vector3.forward*cameraDistance + Vector3.up*cameraHeight;

        transform.LookAt(chickenObject.transform);
    }
}*/
