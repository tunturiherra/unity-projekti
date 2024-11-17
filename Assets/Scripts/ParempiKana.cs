using UnityEngine;

public class ParempiKana : MonoBehaviour
{
    [SerializeField]
    float nopeus = 10f;

    [SerializeField]
    float pyorimisnopeus = 5f;

    Rigidbody fysiikka;

    bool wnappelipainettu = false;
    bool snappelipainettu = false;
    bool anappelipainettu = false;
    bool dnappelipainettu = false;

    bool poimittiinSafetyBox = false;

    [SerializeField]
    GameObject safetyBoxTemplaatti;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fysiikka = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("w"))
        {
            wnappelipainettu = true;
        }
        else
        {
            wnappelipainettu = false;
        }

        if (Input.GetKey("s"))
        {
            snappelipainettu = true;
        }
        else
        {
            snappelipainettu = false;
        }

        if (Input.GetKey("a"))
        {
            anappelipainettu = true;
        }
        else
        {
            anappelipainettu = false;
        }

        if (Input.GetKey("d"))
        {
            dnappelipainettu = true;
        }
        else
        {
            dnappelipainettu = false;
        }

        // JOS safetybox on poimittu JA t-nappi on painettu
        if (poimittiinSafetyBox == true && Input.GetKeyDown("t"))
        {
            GameObject kloonisafety = Instantiate(safetyBoxTemplaatti);
            kloonisafety.transform.position = transform.TransformPoint(Vector3.forward * 2f + Vector3.up*3f );
            poimittiinSafetyBox = false;
        }
    }

    void FixedUpdate()
    {
        if (wnappelipainettu == true )
        {
            fysiikka.AddRelativeForce(Vector3.forward * nopeus);
        }
        if (snappelipainettu == true )
        {
            fysiikka.AddRelativeForce(Vector3.back * nopeus);
        }
        if ( anappelipainettu == true )
        {
            fysiikka.AddTorque(Vector3.down * pyorimisnopeus);
        }
        if (dnappelipainettu == true)
        {
            fysiikka.AddTorque(Vector3.up * pyorimisnopeus);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Kananen kopsahti: " + collision.gameObject.name);

        // JOS osuttiin safetyBoxiin -> poimitaan se.
        if (collision.gameObject.name.Contains("safety"))
        {
            Destroy(collision.gameObject);
            poimittiinSafetyBox = true;
        }
    }

}
