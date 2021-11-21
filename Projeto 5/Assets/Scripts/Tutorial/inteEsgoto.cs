using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inteEsgoto : MonoBehaviour
{
    public Image tutorialBackgrounddddd;

    public Text textoInteragirEsgoto;

    public GameObject _tutorialBackgrounddddd;
    public GameObject _textInteragirEsgoto;

    //public AudioSource runSound;

    void Start()
    {
        tutorialBackgrounddddd.enabled = false;
        textoInteragirEsgoto.enabled = false;

        _textInteragirEsgoto.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Est� dentro do Pensamento");
            textoInteragirEsgoto.enabled = true;
            tutorialBackgrounddddd.enabled = true;
            _textInteragirEsgoto.SetActive(true);
            _tutorialBackgrounddddd.SetActive(true);
    //runSound.Stop();
}
    }

    //void OnTriggerEnter(Collider other)
}