using UnityEngine;

public class PallonLiikutin : MonoBehaviour
{
    public float nopeus;
    public int kokonaisluku;
    public string teksti;
    public bool tosi;

    public Rigidbody fysiikka;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fysiikka = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W-nappia on painettu "+nopeus);
            // 0, 0, 1 * 15 = 0, 0, 15
            fysiikka.AddForce(Vector3.forward*nopeus);
        }
        if( Input.GetKey(KeyCode.S))
        {
            Debug.Log("S-nappia on painettu");
            // 0, 0, -1 * 10 = 0, 0, -10
            fysiikka.AddForce(Vector3.forward* -nopeus);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A-nappia painettu");
            // -1, 0, 0 * 10 = -10, 0, 0
            fysiikka.AddForce(Vector3.left * nopeus);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D-nappia painettu");
            fysiikka.AddForce(Vector3.right * nopeus);
        }
    }
}
