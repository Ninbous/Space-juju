using Leopotam.Ecs;
using UnityEngine;

namespace SpaceJuJu {
    
    struct Position {
        public float x;
        public float y;
    }
    sealed class Unit : IEcsAutoReset
    {
        public Health health;
        public Position position;
        public Transform transform;
        
        void IEcsAutoReset.Reset () {
            transform = null;
        }
    }
    
    
}