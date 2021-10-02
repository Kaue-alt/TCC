using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interacaoTutorial : MonoBehaviour
{
    public Image tutorialBackgroundddd;

    public Text textoInteragir;

    public GameObject _tutorialBackgroundddd;
    public GameObject _textInteragir;

    dashMove dashScript;
    PlayerJump jumpScript;
    Combos attackScript;

    public AudioSource runSound;

    private bool pausedddd = false;

    void Start ()
    {
        tutorialBackgroundddd.enabled = false;
        textoInteragir.enabled = false;

        _textInteragir.SetActive(true);

        dashScript = FindObjectOfType<dashMove>();
        jumpScript = FindObjectOfType<PlayerJump>();
        attackScript = FindObjectOfType<Combos>();
    }

    void Update()
    {
        if (pausedddd)
        {
            jumpScript.enabled = false;
            dashScript.enabled = false;
            attackScript.enabled = false;

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Saiu do Tutorial");
                Time.timeScale = 1;
                pausedddd = false;

                tutorialBackgroundddd.enabled = false;
                textoInteragir.enabled = false;

                jumpScript.enabled = true;
                dashScript.enabled = true;
                attackScript.enabled = true;

                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (pausedddd == false)
            {
                Time.timeScale = 0;
                textoInteragir.enabled = true;
                tutorialBackgroundddd.enabled = true;
                //runSound.Stop();
                pausedddd = true;
            }
        }
    }
}