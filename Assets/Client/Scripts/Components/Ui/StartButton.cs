using Leopotam.Ecs;
using UnityEngine;

namespace SpaceJuJu {
    sealed class StartButton : IEcsAutoReset
    {
        public RectTransform rectTransform;
        
        void IEcsAutoReset.Reset () {
            rectTransform = null;
        }
    }
}