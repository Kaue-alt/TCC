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

    dashMove dashScript;
    PlayerJump jumpScript;

    public AudioSource runSound;

    private bool paused = false;

    void Start()
    {
        tutorialBackground.enabled = false;
        textoAndar.enabled = false;

        _tutorialBackground.SetActive(true);
        _textoAndar.SetActive(true);

        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
    }

    void Update()
    {
        if (paused)
        {

            jumpScript.enabled = false;
            dashScript.enabled = false;

            if (Input.GetMouseButtonDown(0)) //(Input.GetKeyDown(KeyCode.L)) //(Input.GetMouseButtonDown(0))
            {
                Debug.Log("Saiu do Tutorial");
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                paused = false;

                tutorialBackground.enabled = true;
                textoAndar.enabled = true;
                _tutorialBackground.SetActive(false);
                _textoAndar.SetActive(false);

                jumpScript.enabled = true;
                dashScript.enabled = true;

                //Destroy(gameObject);
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
                //runSound.Stop();
                paused = true;
                Debug.Log("pausou");
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
