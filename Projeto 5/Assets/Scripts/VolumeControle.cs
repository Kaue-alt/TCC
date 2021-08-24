using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControle : MonoBehaviour
{
    float volumeGeral1;
  
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void volumeGeral2 (float volume)
    {
        volumeGeral1 = volume;
        AudioListener.volume = volumeGeral1;
    }
}
