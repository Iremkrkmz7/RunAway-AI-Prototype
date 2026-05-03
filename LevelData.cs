using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]

public class LevelData 
{
    public int levelNumber;
    public EnvironmentType environment;
    public float planeSize;
    public int coinCount;
    public int enemyCount;
    public float enemySpeed;
    public Color groundColor;
    public Color skyColor;
    public string ambientSound;
  }
