using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJuninho : MonoBehaviour
{
    public GameObject SpawnKid;
    public GameObject kidGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnKid.gameObject.SetActive(true);
            kidGame.gameObject.SetActive(false);
        }
    }
}
