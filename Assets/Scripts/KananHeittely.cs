using UnityEngine;

public class KananHeittely : MonoBehaviour
{

    [SerializeField]
    GameObject karppisAmmus;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject karppisAmmusKlooni = Instantiate(karppisAmmus);
            GameObject lahtoPaikka = GameObject.Find("karppisLahtoPaikka");
            karppisAmmusKlooni.transform.position = lahtoPaikka.transform.position;
           
        }
    }
}
