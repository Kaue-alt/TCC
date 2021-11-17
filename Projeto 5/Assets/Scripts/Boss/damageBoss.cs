using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageBoss : MonoBehaviour
{
    public Animator bossAnimator;

    //Danos


    //Declarar scripts
    Boss bossScript;
    vidaPlayer vidaPlayerScript;
    feedbackPlayer fbPlayerScript;
    KnockBack kbScript;

    private void Start()
    {
        //Invocar Scripts
        bossScript = FindObjectOfType<Boss>();
        vidaPlayerScript = FindObjectOfType<vidaPlayer>();
        fbPlayerScript = FindObjectOfType<feedbackPlayer>();
        kbScript = GetComponent<KnockBack>();
    }
    private void OnTriggerEnter (Collider collider)
    {
        if (bossAnimator.GetCurrentAnimatorStateInfo(0).IsName("BossSimpleSlash"))
        {
            if(collider.gameObject.tag == "Player")
            {
                Debug.Log("Chamou método1");
                bossScript.corteRapido();
                vidaPlayerScript.life -= bossScript.danoDoCorteLeve;
                kbScript.active = true;
                fbPlayerScript.damage = true;
            }
        }
        if (bossAnimator.GetCurrentAnimatorStateInfo(0).IsName("BossSlowSlash"))
        {
            if(collider.gameObject.tag == "Player")
            {
                Debug.Log("Chamou método2");
                bossScript.cortePesado();
                vidaPlayerScript.life -= bossScript.danoDoCortePesado;
                kbScript.active = true;
                fbPlayerScript.damage = true;
            }
        }


    }
}
