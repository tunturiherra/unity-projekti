using TMPro;
using UnityEngine;

public class KameranLiikutus : MonoBehaviour
{
    public GameObject kentanKana;
    public TMP_Text tekstikentta;

    public float kameranEtaisyys = 4f;
    public float kameranKorkeus = 2f;

    public float kulunutAika = 0f;

    Vector3 haluttuKameranPaikka;

    [SerializeField]
    float kameranNopeus = 0.1f;

    void Start()
    {
        kentanKana = GameObject.Find("Kananen");

        // If "Kananen" isn't found, try to find "Haamu"
        if (kentanKana == null)
        {
            kentanKana = GameObject.Find("Haamu");
            if (kentanKana == null)
            {
                Debug.LogError("Error: Neither 'Kananen' nor 'Haamu' was found in the scene.");
            }
        }

        // Find and check for the TMP_Text component
        GameObject tekstiosio = GameObject.Find("TekstiOsio");
        if (tekstiosio != null)
        {
            tekstikentta = tekstiosio.GetComponent<TMP_Text>();
            if (tekstikentta == null)
            {
                Debug.LogError("'TekstiOsio' found, but it has no TMP_Text component.");
            }
        }
        else
        {
            Debug.LogError("'TekstiOsio' object not found in the scene.");
        }
    }

    void Update()
    {
        // Check if kentanKana is assigned before using it
        if (kentanKana == null)
        {
            Debug.LogWarning("Warning: 'kentanKana' is null, skipping camera update.");
            return;
        }

        kulunutAika += Time.deltaTime;

        /*
        if (kulunutAika > 2f)
        {
            tekstikentta.text = "TÄMÄHÄN TOIMII!";
        } 
        */

        // Calculate the desired camera position
        haluttuKameranPaikka = kentanKana.transform.TransformPoint(Vector3.back * kameranEtaisyys +
            Vector3.up * kameranKorkeus);

        transform.position = Vector3.Lerp(transform.position, haluttuKameranPaikka, kameranNopeus);

        // Make the camera look at the target object
        transform.LookAt(kentanKana.transform);
    }
}
