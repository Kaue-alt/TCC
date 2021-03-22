using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEnemy : MonoBehaviour
{
    vidaPlayer vidaPlayerScript;

    public float damage = 20;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        vidaPlayerScript = FindObjectOfType<vidaPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dano1()
    {
        vidaPlayerScript.life -= damage;
        
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //player.transform.position = reset.transform.position;
            Debug.Log("Recebeu dano");
            Dano1();
        }
    }
}
