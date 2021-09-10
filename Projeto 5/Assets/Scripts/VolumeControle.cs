using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControle : MonoBehaviour
{
    public float volumeMaster, volumeEfeito, volumeMusica;
  
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void VolumeMaster (float volume)
    {
        volumeMaster = volume;
        AudioListener.volume = volumeMaster;
    }

    public void VolumeEfeito (float volume)
    {
        volumeEfeito = volume;
        GameObject[] Fxs = GameObject.FindGameObjectsWithTag("FX");
        for(int i=0; i<Fxs.Length; i++)
        {
            Fxs[i].GetComponent<AudioSource>().volume = volumeEfeito;
        }
    }

    public void VolumeMusica (float volume)
    { 
        volumeMusica = volume;
        GameObject[] Musicas = GameObject.FindGameObjectsWithTag("Musica");
        for (int i=0; i<Musicas.Length; i++)
        {
            Musicas[i].GetComponent<AudioSource>().volume = volumeMusica;
        }

        GameObject[] Musicas1 = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < Musicas1.Length; i++)
        {
            Musicas1[i].GetComponent<AudioSource>().volume = volumeMusica;
        }
    }
}
