using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puloTutorial : MonoBehaviour
{
    public GameObject textoTutorial;
    public Image tutorialBackgroundd;

    public Text textoPular;

    public GameObject _tutorialBackgroundd;
    public GameObject _textPular;

    public AudioSource runSound;

    private bool pausedd = false;

    void Start()
    {
        tutorialBackgroundd.enabled = false;
        textoPular.enabled = false;

        _tutorialBackgroundd.SetActive(true);
        _textPular.SetActive(true);
    }

    void Update()
    {
        if (pausedd)
        {
            if (Input.GetMouseButtonDown(0)) //(Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Saiu do Tutorial");
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                pausedd = false;

                tutorialBackgroundd.enabled = true;
                textoPular.enabled = true;
                _tutorialBackgroundd.SetActive(false);
                _textPular.SetActive(false);

                //Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!pausedd)
            {
                Time.timeScale = 0;
                textoPular.enabled = true;
                tutorialBackgroundd.enabled = true;
                //runSound.Stop();
                pausedd = true;
                Debug.Log("pausou");
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                pausedd = false;
            }

        }
    }
}
