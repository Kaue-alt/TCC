using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel : MonoBehaviour
{
    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
        Debug.Log(levelSystem.LevelNumb());
        levelSystem.AddExp(50);
        Debug.Log(levelSystem.LevelNumb());
        levelSystem.AddExp(60);
        Debug.Log(levelSystem.LevelNumb());
    }
}
 