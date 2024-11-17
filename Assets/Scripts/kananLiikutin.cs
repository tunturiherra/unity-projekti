using UnityEngine;

public class KananLiikutin : MonoBehaviour
{
    [SerializeField]
    float nopeus;

    [SerializeField]
    float kaantovoima;

    [SerializeField]
    int kokonaisluku;

    [SerializeField]
    string teksti;

    [SerializeField]
    bool tosi;

    [SerializeField]
    Rigidbody fysiikka;

    [SerializeField]
    bool hyppytehty = false;

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
            Debug.Log("W-nappia on painettu " + nopeus);
            // 0, 0, 1 * 15 = 0, 0, 15
            fysiikka.AddRelativeForce(Vector3.forward * nopeus);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S-nappia on painettu");
            // 0, 0, -1 * 10 = 0, 0, -10
            fysiikka.AddRelativeForce(Vector3.forward * -nopeus);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A-nappia painettu");
            // -1, 0, 0 * 10 = -10, 0, 0
            //fysiikka.AddForce(Vector3.left * nopeus);
            fysiikka.AddRelativeTorque(Vector3.up * -kaantovoima);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D-nappia painettu");
            //fysiikka.AddForce(Vector3.right * nopeus);
            fysiikka.AddRelativeTorque(Vector3.up * kaantovoima);
        }

        // JOS välilyöntiä on painettu
        if( Input.GetKey(KeyCode.Space) && hyppytehty == false )
        {
            // Kana hahmo pomppaa pari yksikkö ilmaan
            Debug.Log("Space painettu");
            fysiikka.AddForce(Vector3.up * 1000f);
            hyppytehty = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter saavutettu "+collision.gameObject.name);
        // Kun osutaan takaisin hypyn jälkeen lattiaan,
        // Mahdollistetaan uusi hyppy laittamalla hyppytehty muuttuja
        // arvoon false++++++
        hyppytehty = false;
    }

}
