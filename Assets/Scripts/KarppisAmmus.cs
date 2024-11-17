using UnityEngine;

public class KarppisAmmus : MonoBehaviour
{
    [SerializeField]
    float tuhoamisTimer = 0f;

    [SerializeField]
    float tuhoutumisAika = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody fysiikkaKarppis = GetComponent<Rigidbody>();
        float randomSivuVoima = Random.Range(-100f, 100f);
        float randomPystyVoima = Random.Range(-100f, 100f);
        fysiikkaKarppis.AddForce(Vector3.up*550f+Vector3.forward*randomPystyVoima+Vector3.right*randomSivuVoima);
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
