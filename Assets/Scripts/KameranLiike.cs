using TMPro;
using UnityEngine;

public class KameranLiike : MonoBehaviour
{
    public GameObject kentanKana;

    public TMP_Text textField;

    public float kameranEtaisyys = 4f;
    public float kameranKorkeus = 2f;

    public float kulunutAika = 0f;

    Vector3 haluttuKameranPaikka;
    
    [SerializeField]
    float kameranNopeus = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Etsitään Hierarkiasta Chicken niminen GameObject
        kentanKana = GameObject.Find("KANA");

        GameObject TextUI = GameObject.Find("TextUI");
        textField = TextUI.GetComponent<TMP_Text>();
        textField.text = "Tämähän toimii!";

        // Update is called once per frame
    }
    void Update()
    {
        kulunutAika = kulunutAika + Time.deltaTime;

        // Kun aikaa on kulunut yli 2 sekunttia, päivitä UI teksti

      /*  if (kulunutAika > 2f)
        {
            tekstikentta.text = "TÄMÄHÄN TOIMII!";
        }*/

        
        // kameran kiinteään paikkaan asettaminen käyttäen
        // Vector3 luokasta tehtyä oliota
        //  transform.position = new Vector3(10f, 5f, 3f);
        
    // Lasketaan haluttu kameran paikka suhteessa kanaan
    haluttuKameranPaikka = kentanKana.transform.TransformPoint(Vector3.back * kameranEtaisyys + Vector3.up * kameranKorkeus);
    

    // Sijoitetaan kamera paikkaan kohti haluttua paikkaa Lerpillä
    transform.position = Vector3.Lerp(transform.position, haluttuKameranPaikka, kameranNopeus);

    // Kamera seuraa kanaa ja katsoo sitä
    transform.LookAt(kentanKana.transform);
        
        /*transform.position = kentanKana.transform.position + 
            Vector3.forward*kameranEtaisyys+
            Vector3.up*kameranKorkeus;*/


    }
}
