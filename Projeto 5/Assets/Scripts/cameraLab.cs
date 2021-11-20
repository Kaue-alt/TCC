using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cameraLab : MonoBehaviour
{
    cameraFollowPlayer camScript;
    public GameObject nextCol;
    public float add;

    void Start()
    {
        camScript = FindObjectOfType<cameraFollowPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(changeDirection());
            nextCol.SetActive(true);
        }
    }

    IEnumerator changeDirection()
    {
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        camScript.horizontal += add;
        yield return new WaitForSecondsRealtime(0.04f);
        Destroy(this);
    }
}
