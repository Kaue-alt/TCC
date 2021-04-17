using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTutorial : MonoBehaviour
{
    private Collider[] Colisores;
    public float TempoTexto;
    public Text textoAndar;
    public Text textoPular;
    public Text textoAtirar;

    public GameObject _textoAndar;
    public GameObject _textoPular;
    public GameObject _textoAtirar;

    void Start()
    {
        textoAndar.enabled = false;
        textoAtirar.enabled = false;
        textoPular.enabled = false;

        _textoAndar.SetActive(true);
        _textoAtirar.SetActive(true);
        _textoPular.SetActive(true);

        Colisores = transform.GetComponentsInChildren<Collider>();
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        StartCoroutine(EsperarTempo(TempoTexto));
    }

    IEnumerator EsperarTempo(float tempo)
    {
        textoAndar.enabled = true;

        if (textoAndar.enabled == true)
        {
            foreach (Collider coll in Colisores)
            {
                coll.enabled = false;
            }
            yield return new WaitForSeconds(tempo);
            textoAndar.enabled = false;
        }

        textoAtirar.enabled = true;

        if (textoAtirar.enabled == true)
        {
            foreach (Collider coll in Colisores)
            {
                coll.enabled = false;
            }
            yield return new WaitForSeconds(tempo);
            textoAtirar.enabled = false;
        }

        textoPular.enabled = true;

        if (textoPular.enabled == true)
        {
            foreach (Collider coll in Colisores)
            {
                coll.enabled = false;
            }
            yield return new WaitForSeconds(tempo);
            textoPular.enabled = false;
        }

        Destroy(gameObject);
    }
}
