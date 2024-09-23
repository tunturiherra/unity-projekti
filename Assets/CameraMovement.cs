using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject chickenObject;

    // Start is called before the first frame update
    void Start()
    {
        chickenObject = GameObject.Find("KANA");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(chickenObject.transform);
    }
}
