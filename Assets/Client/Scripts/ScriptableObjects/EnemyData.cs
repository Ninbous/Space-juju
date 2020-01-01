using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Enemy", fileName = "New Enemy")]
public class EnemyData : ScriptableObject {
    
    [SerializeField] private float speed;
    public float Speed {
        get => speed;
        protected set => speed = value;
    }

    [SerializeField] private float health;
    public float Health {
        get => health;
        protected set => health = value;
    }
}