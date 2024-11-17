using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    public Image uikuva;
    public Material teippiMateriaali;
    float timefade = 4f;
    float alphaValue = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alphaValue += Time.deltaTime;
        uikuva.color = new Color(uikuva.color.r, uikuva.color.g, uikuva.color.b, alphaValue/timefade);
        if (alphaValue/timefade > 1f)
        {
            alphaValue = 0f;
        }
    }
}
