using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puloTutorial : MonoBehaviour
{
    public Image tutorialBackgroundd;

    public Text textoPular;

    public GameObject _tutorialBackgroundd;
    public GameObject _textPular;

    dashMove dashScript;
    PlayerJump jumpScript; 

    public AudioSource runSound;

    private bool pausedd = false;

    void Start()
    {
        tutorialBackgroundd.enabled = false;
        textoPular.enabled = false;

        _textPular.SetActive(true);

        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
    }

    void Update()
    {
        if (pausedd == true)
        {
            jumpScript.enabled = false;
            dashScript.enabled = false;

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Saiu do Tutorial");
                Time.timeScale = 1;
                pausedd = false;

                tutorialBackgroundd.enabled = false;
                textoPular.enabled = false;

                jumpScript.enabled = true;
                dashScript.enabled = true;

                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (pausedd == false)
            {
                Time.timeScale = 0;
                textoPular.enabled = true;
                tutorialBackgroundd.enabled = true;
                //runSound.Stop();
                pausedd = true;
                Debug.Log("pausou");
            }
        }
    }
}
