using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemy : MonoBehaviour
{
    public float life = 100f;

    void Update()
    {
        if (life <= 0f)
        {
            Debug.Log("Inimigo Morto");
            Destroy(gameObject);
        }
    }
}
