using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceJuJu {
    sealed class LoadLevelSystem : IEcsInitSystem, IEcsRunSystem {
        readonly EcsFilter<LevelChange> _levelChangeFilter = null;
        readonly EcsFilter<Level> _levelUiFilter = null;
        readonly EcsWorld _world = null;

        public void Init() {
            foreach (var unityObject in GameObject.FindGameObjectsWithTag(TagsDictionary.UiLevelText)) {
                RectTransform levelTextTransform = unityObject.GetComponent<RectTransform>();
                _world.NewEntityWith<Level>(out var levelComponent);
                levelComponent.value = 0;
                levelComponent.rectTransform = levelTextTransform;
                levelComponent.ui = unityObject.GetComponent<Text>();
                levelComponent.ui.text = $"Level {levelComponent.value}";
                levelComponent.ui.color = new Color(1, 1, 1, 0);
            }
        }

        void IEcsRunSystem.Run() {

            foreach (var levelIdx in _levelUiFilter) {
                var level = _levelUiFilter.Get1[levelIdx];
                if (level.fadeTime > 0) {
                    level.ui.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, level.fadeTime));
                    level.fadeTime -= 1 * Time.deltaTime;
                }

                foreach (var levelChangeIdx in _levelChangeFilter) {
                    var value = _levelChangeFilter.Get1[levelChangeIdx].value;
                    level = _levelUiFilter.Get1[levelIdx];
                    level.value = value;
                    level.ui.text = $"Level {level.value}";
                    level.fadeTime = 3f;
                    level.ui.color = Color.white;
                }
            }
        }
    }
}