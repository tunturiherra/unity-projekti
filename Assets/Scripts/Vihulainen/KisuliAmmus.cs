using UnityEngine;

public class KisuliAmmus : MonoBehaviour
{

    [SerializeField]
    float tuhoamisTimer = 0f;

    [SerializeField]
    float tuhoutumisAika = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody fysiikkaKisuli = GetComponent<Rigidbody>();
        fysiikkaKisuli.AddRelativeForce(Vector3.forward*700f);   
    }

    // Update is called once per frame
    void Update()
    {
        tuhoamisTimer = tuhoamisTimer+Time.deltaTime;

        if( tuhoamisTimer > tuhoutumisAika )
        {
            Destroy(gameObject);
        }
    }
}
