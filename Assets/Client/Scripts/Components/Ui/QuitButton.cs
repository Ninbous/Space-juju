using Leopotam.Ecs;
using UnityEngine;

namespace SpaceJuJu {
    sealed class QuitButton : IEcsAutoReset
    {
        public RectTransform rectTransform;
        
        void IEcsAutoReset.Reset () {
            rectTransform = null;
        }
    }
}