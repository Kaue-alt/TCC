using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    private int level;
    private int currentExp;
    private int expNextLevel;

    public LevelSystem()
    {
        level = 0;
        currentExp = 0;
        expNextLevel = 100;
       
    }
    public void AddExp(int amount)
    {
        currentExp += amount;
        if (currentExp >= expNextLevel)
        {
            level++;
            currentExp -= expNextLevel;
        }
    }

    public int LevelNumb()
    {
        return level;
    }
}
