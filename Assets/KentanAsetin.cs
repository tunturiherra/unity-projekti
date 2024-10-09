using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KentanAsetin : MonoBehaviour
{
    private GameObject ductTape;
    private GameObject toolBox;
    private GameObject crowBar;
    private GameObject flashLight;

    // Start is called before the first frame update
    void Start()
    {
        ductTape = GameObject.Find("ilmastointiteippi");

        ductTape.transform.position = new Vector3(-7, 0 , 7);

        toolBox = GameObject.Find("tyokalupakki");

        toolBox.transform.position = new Vector3(6, 0, -7);

        crowBar = GameObject.Find("sorkkarauta");

        crowBar.transform.position = new Vector3(-7, 1, -7);
        
        flashLight = GameObject.Find("taskulamppu");

        flashLight.transform.position = new Vector3(7, 1, 7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
