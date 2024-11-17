using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class VihulaisenAI : MonoBehaviour
{
    NavMeshAgent agentti;
    GameObject kananen;

    [SerializeField]
    GameObject kisuliAmmusTemplate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agentti = GetComponent<NavMeshAgent>();

        kananen = GameObject.Find("Kananen");
        agentti.destination = kananen.transform.position;

        float etaisyysKananJaPenguiniinValilla = Vector3.Distance(transform.position, kananen.transform.position);
        Debug.Log("Kanan ja pigviinin välinen etäisyys: " +  etaisyysKananJaPenguiniinValilla );
        
        StartCoroutine("PaivitaKohteenSijainti");
        StartCoroutine("KisuliHeittely");
    }

    IEnumerator KisuliHeittely()
    {
        float randomOdotusAika = Random.Range(1f, 3f);
        yield return new WaitForSeconds(1f+randomOdotusAika);

        GameObject starttipiste = GameObject.Find("AmmuksenStarttiPiste1");
        Vector3 suunta = kananen.transform.position-starttipiste.transform.position;
        Debug.DrawRay(starttipiste.transform.position, suunta, Color.red, 10f);
        // todo: Seuraavaksi luodaan raycast, joka tarkistaa onko näköyhteys kohteeseen olemassa.
        RaycastHit osuma = new RaycastHit();
        bool osuikoJohonkin = Physics.Raycast( starttipiste.transform.position, suunta, out osuma );
        if ( osuikoJohonkin == true )
        {
            Debug.Log("Osuttiin johonkin:" + osuma.transform.name + " Etäisyys: " + osuma.distance );
        
            if ( osuma.transform.name.Contains("Kananen") && osuma.distance < 10f )
                {
                Instantiate(kisuliAmmusTemplate, starttipiste.transform.position, starttipiste.transform.rotation);
                Debug.Log("VIHOLLINEN, AMPU TULOO");
                }
        }
        
        StartCoroutine("KisuliHeittely");
    }

    IEnumerator PaivitaKohteenSijainti()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Kohteen sijainnin päivitys");
        agentti.destination = kananen.transform.position;
        StartCoroutine("PaivitaKohteenSijainti");
    }


    // Update is called once per frame
    void Update()
    {
       float etaisyysKananJaPenguiniinValilla = Vector3.Distance(transform.position, kananen.transform.position);

        if( etaisyysKananJaPenguiniinValilla < 3f)
        {
            agentti.isStopped = true;
            // tallennetaan alkurotaatio
            Quaternion vihollisenAlkuRotaatio = transform.rotation;
            // Käännetään hahmo loppurotaation paikkaan
            transform.LookAt(kananen.transform);
            // Talenetaan loppurotaatio
            Quaternion vihollisenLoppuRotaatio = transform.rotation;
            // Interpoloidaan pieni pätkä loppurotaation suuntaan.
            transform.rotation = Quaternion.Lerp(vihollisenAlkuRotaatio, vihollisenLoppuRotaatio, 0.005f);
        }
        else
        {
            agentti.isStopped = false;
        }
        

    }
}
