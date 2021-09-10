using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCanvas : MonoBehaviour
{
    public GameObject textoTutorial;
    public Image tutorialBackground;

    public Text textoAndar;

    public GameObject _tutorialBackground;
    public GameObject _textoAndar;

    public AudioSource runSound;

    private bool paused = false;

    void Start()
    {
        tutorialBackground.enabled = false;
        textoAndar.enabled = false;

        _tutorialBackground.SetActive(true);
        _textoAndar.SetActive(true);
    }

    void Update()
    {
        if (paused)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Apertou L");
                Time.timeScale = 1;
                paused = false;
                Cursor.lockState = CursorLockMode.None;
                runSound.Stop();
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                textoAndar.enabled = true;
                tutorialBackground.enabled = true;
                paused = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                paused = false;
            }
        }
    }
}
