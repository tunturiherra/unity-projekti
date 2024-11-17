using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject PauseMenu; //  Pausemenun objekti
    public Button continueButton; // lisätään nappi

    private bool isPaused = false; // Pelin pause-toiminnallisuus

    void Start()
    {
        // Piilotetaan pausemenu pelin alussa
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false);
        }
        else
        {
            Debug.Log("PauseMenu ei ole asetettu!");
        }

        // Napin toiminnallisuus tässä
        if (continueButton != null)
        {
            continueButton.onClick.AddListener(ResumeGame);
        }
        else
        {
            Debug.Log("ContinueButton ei ole asetettu. Käytä P-näppäintä jatkaaksesi peliä.");
        }
    }

    void Update()
    {
        // Tässä aktivoidaan pausemenu
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P-näppäintä painettu");
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(true); // Näytetään pausmenu
        }
        Time.timeScale = 0f; // Pysäytetään pelin aika
        Debug.Log("Peli pausella, Time.timeScale = " + Time.timeScale);
    }

    void ResumeGame()
    {
        isPaused = false;
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false); // Piilotetaan pause-valikko
        }
        Time.timeScale = 1f; // Jatketaan pelin aikaa
        Debug.Log("Peli jatkuu, Time.timeScale = " + Time.timeScale);
    }
}
