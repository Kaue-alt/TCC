using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemy : MonoBehaviour
{
    public float life = 100f;

    public AudioSource audioSourceMonster;

    private GameObject player;
    public float expValue;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (life <= 0f)
        {
            Debug.Log("Inimigo Morto");
            Destroy(gameObject);
            playAudio();
            player.GetComponent<LevelSystem>().SetExperience(expValue);
        }
        void playAudio()
        {
            audioSourceMonster.Play();
        }
    }
}
