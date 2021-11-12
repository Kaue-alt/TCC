using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class destroyWall : MonoBehaviour
{

    private Material mat;
    public GameObject wall;
    float alf = 1;
    int cont = 0;

    void Start()
    {
        mat = wall.GetComponent<MeshRenderer>().material;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && cont == 0)
        {
            StartCoroutine(destroyObj());
        }
    }

    IEnumerator destroyObj()
    {
        mat.color = Color.magenta;
        yield return new WaitForSecondsRealtime(0.5f);
        DestroyObject(wall);
        //StartCoroutine(destroyObj());
    }
}
