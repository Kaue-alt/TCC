using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedbackDano : MonoBehaviour
{
    DamagePlayer danoScript;

    public Color corInicial;
    Material mat;

    public float tempoDeEspera = 2f;

    void Start()
    {
        danoScript = FindObjectOfType<DamagePlayer>();

        mat = GetComponent<MeshRenderer>().material;
        corInicial = mat.color;
    }

    void Update()
    {
        if (danoScript.recebeuDano == true)
        {
            mat.SetColor("_Color", Color.red);
            Debug.Log(danoScript.recebeuDano);
            Debug.Log("corVERMELHA");
            StartCoroutine("DeixarVerdadeira");
        }
    }

    public IEnumerator DeixarVerdadeira()
    {
        yield return new WaitForSeconds(tempoDeEspera);
        mat.color = corInicial;
    }
}
