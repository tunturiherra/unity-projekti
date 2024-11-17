using UnityEngine;
using TMPro;
public class UIHandler : MonoBehaviour
{
    public TMP_Text tmp; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tmp = GameObject.Find("Meshpro").GetComponent<TMP_Text>();
        tmp.text = "ETSI SORKKARAUTA";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
