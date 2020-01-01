using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceJuJu {
    sealed class Level : IEcsAutoReset {
        public int value;
        public RectTransform rectTransform;
        public Text ui;
        public float fadeTime;

        public void Reset() {
            rectTransform = null;
            ui = null;
        }
    }
}