using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ataqueTutorial : MonoBehaviour
{
    public GameObject textoTutorial;
    public Image tutorialBackgrounddd;

    public Text textoAtacar;

    public GameObject _tutorialBackgrounddd;
    public GameObject _textAtacar;

    dashMove dashScript;
    PlayerJump jumpScript;

    public AudioSource runSound;

    private bool pauseddd = false;

    void Start()
    {
        tutorialBackgrounddd.enabled = false;
        textoAtacar.enabled = false;

        _tutorialBackgrounddd.SetActive(true);
        _textAtacar.SetActive(true);

        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
    }

    void Update()
    {
        if (pauseddd)
        {
            jumpScript.enabled = false;
            dashScript.enabled = false;

            if (Input.GetMouseButtonDown(0)) //(Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Saiu do Tutorial");
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                pauseddd = false;

                tutorialBackgrounddd.enabled = true;
                textoAtacar.enabled = true;
                _tutorialBackgrounddd.SetActive(false);
                _textAtacar.SetActive(false);

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
            if (!pauseddd)
            {
                Time.timeScale = 0;
                textoAtacar.enabled = true;
                tutorialBackgrounddd.enabled = true;
                //runSound.Stop();
                pauseddd = true;
                Debug.Log("pausou");
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                pauseddd = false;
            }

        }
    }
}