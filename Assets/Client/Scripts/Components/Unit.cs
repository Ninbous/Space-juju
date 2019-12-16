using Leopotam.Ecs;
using UnityEngine;

namespace SpaceJuJu {
    
    struct Position {
        public float x;
        public float y;
    }
    sealed class Unit {
        public Health health;
        public Position position;
        public Transform transform;
    }
}