using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

[Serializable]
class PlayerData
{
    public float life;
    public float playerPosX, playerPosY;
    public int[] weaponId;
    public int currentWeaponId;
}
public class gameManager : MonoBehaviour
{
    public Fade fadeScript;

    public float life;
    public float playerPosX, playerPosY;
    public int[] weaponId;
    public int currentWeaponId;

    public static gameManager gm;

    private string filePath;

    void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
        else if(gm != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        filePath = Application.persistentDataPath + "/playerInfo.dat";
    }

    public void Save()
    {
        vidaPlayer player = FindObjectOfType<vidaPlayer>();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);

        PlayerData data = new PlayerData();

        data.life = player.life;
        data.playerPosX = player.transform.position.x;
        data.playerPosY = player.transform.position.y;

        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Jogo Salvo!");
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            fadeScript.Transition("Tutorial");
            Cursor.lockState = CursorLockMode.Locked;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            life = data.life;
            playerPosX = data.playerPosX;
            playerPosY = data.playerPosY;

            Debug.Log("Jogo carregado!");

        }
        else
        {
            Debug.Log("Não há jogo salvo para ser carregado!");
        }
    }



    /*public string objectID;
    // Start is called before the first frame update

    private void Awake()
    {
        object= name + transform.position.ToString();
    }
    void Start()
    {
        for (int i-0; i < Object.FindObjectsOfType<gameManager>().Length; i++)
        {
            if(Object.FindObjectsOfType<gameManager>()[i] != this)
            {
                if (Object.FindObjectsOfType<gameManager>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
