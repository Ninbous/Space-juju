using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    private static GameObject instance;
    
    public GameObject[] enemySpawners;
    public String[] str;

    private int level  = 1;

    public static GameObject GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = gameObject;
    }
    
    
    void Start()
    {
        StartLevel(level);
    }

     void StartLevel(int level)
     {
         Debug.Log("Start level: " + level);
        Instantiate(enemySpawners[level-1]);
     }
    
    public  void FinishSpawnWaves()
    {
        Debug.Log("Finish");
        //Сделать проверку на живых врагов
        
        //Устанавливаем следующий уровень
        level++;
        
        //Если уровней нет то победа, иначе стартануть следующий уровень
        if (enemySpawners.Length > 0)
        {
            StartLevel(level);
        }
        else
        {
            Debug.Log("Win!");
        }
    }
}
