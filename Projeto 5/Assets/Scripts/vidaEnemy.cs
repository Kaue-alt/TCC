using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemy : MonoBehaviour
{
    public float life = 100f;

    public AudioSource audioSourceMonster;

    void Update()
    {
        if (life <= 0f)
        {
            Debug.Log("Inimigo Morto");
            Destroy(gameObject);
            playAudio();
        }
        void playAudio()
        {
            audioSourceMonster.Play();
        }
    }
}
