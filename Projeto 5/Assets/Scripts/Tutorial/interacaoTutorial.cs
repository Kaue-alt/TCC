using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interacaoTutorial : MonoBehaviour
{
    public GameObject textoTutorial;
    public Image tutorialBackgroundddd;

    public Text textoInteragir;

    public GameObject _tutorialBackgroundddd;
    public GameObject _textInteragir;

    dashMove dashScript;
    PlayerJump jumpScript;

    public AudioSource runSound;

    private bool pausedddd = false;

    void Start()
    {
        tutorialBackgroundddd.enabled = false;
        textoInteragir.enabled = false;

        _tutorialBackgroundddd.SetActive(true);
        _textInteragir.SetActive(true);

        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
    }

    void Update()
    {
        if (pausedddd)
        {
            jumpScript.enabled = false;
            dashScript.enabled = false;

            if (Input.GetMouseButtonDown(0)) //(Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Saiu do Tutorial");
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                pausedddd = false;

                tutorialBackgroundddd.enabled = true;
                textoInteragir.enabled = true;
                _tutorialBackgroundddd.SetActive(false);
                _textInteragir.SetActive(false);

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
            if (!pausedddd)
            {
                Time.timeScale = 0;
                textoInteragir.enabled = true;
                tutorialBackgroundddd.enabled = true;
                //runSound.Stop();
                pausedddd = true;
                Debug.Log("pausou");
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                pausedddd = false;
            }

        }
    }
}