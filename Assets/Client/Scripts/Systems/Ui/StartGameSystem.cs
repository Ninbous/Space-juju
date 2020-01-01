using Leopotam.Ecs;
using UnityEditor;
using UnityEngine;

namespace SpaceJuJu {
    sealed class StartGameSystem : IEcsInitSystem, IEcsRunSystem {
        readonly EcsFilter<StartButton> _startButtonFilter = null;
        readonly EcsFilter<QuitButton> _quitButtonFilter = null;

        readonly EcsWorld _world = null;

        private Vector3 touchPosition;

        private RectTransform startButtonGO;
        private RectTransform quitButtonGO;

        void IEcsInitSystem.Init() {
            foreach (var unityObject in GameObject.FindGameObjectsWithTag(TagsDictionary.UiStartButton)) {
                startButtonGO = unityObject.GetComponent<RectTransform>();
                _world.NewEntityWith<StartButton>(out var startButtonComponent);
                startButtonComponent.rectTransform = startButtonGO;
            }

            foreach (var unityObject in GameObject.FindGameObjectsWithTag(TagsDictionary.UiQuitButton)) {
                quitButtonGO = unityObject.GetComponent<RectTransform>();
                _world.NewEntityWith<QuitButton>(out var quitButtonComponent);
                quitButtonComponent.rectTransform = quitButtonGO;
            }
        }

        public void Run() {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began) {
                    touchPosition = touch.position;

                    foreach (var startButtonIdx in _startButtonFilter) {
                        var startButton = _startButtonFilter.Get1[startButtonIdx];

                        if (touchPosition.x <=
                            startButton.rectTransform.position.x + startButton.rectTransform.rect.width / 2 &&
                            touchPosition.x >= startButton.rectTransform.position.x -
                            startButton.rectTransform.rect.width / 2 &&
                            touchPosition.y <= startButton.rectTransform.position.y +
                            startButton.rectTransform.rect.height / 2 &&
                            touchPosition.y >= startButton.rectTransform.position.y -
                            startButton.rectTransform.rect.height / 2) {
                            Debug.Log("Start");
                            GameObject playerPrefab =
                                GameController.GetInstance().GetComponent<UnitsDictionary>().playerPrefab;
                            EcsEntity player =
                                _world.NewEntityWith<Unit, Player>(out var unitComponent, out var playerComponent);
                            var tr = Object.Instantiate(playerPrefab).transform;
                            tr.gameObject.tag = TagsDictionary.Player;
                            var pos = tr.localPosition;
                            unitComponent.position.x = pos.x;
                            unitComponent.position.y = pos.z;
                            unitComponent.transform = tr;
                            _startButtonFilter.Entities[startButtonIdx].Destroy();
                            _quitButtonFilter.Entities[0].Destroy();
                            startButtonGO.gameObject.SetActive(false);
                            quitButtonGO.gameObject.SetActive(false);
                            
                            _world.NewEntityWith<LevelChange>(out var levelChange);
                            levelChange.value = 1;
                        }
                    }

                    foreach (var quitButtonIdx in _quitButtonFilter) {
                        var quitButton = _quitButtonFilter.Get1[quitButtonIdx];
                        
                        if (touchPosition.x <=
                            quitButton.rectTransform.position.x + quitButton.rectTransform.rect.width / 2 &&
                            touchPosition.x >= quitButton.rectTransform.position.x -
                            quitButton.rectTransform.rect.width / 2 &&
                            touchPosition.y <= quitButton.rectTransform.position.y +
                            quitButton.rectTransform.rect.height / 2 &&
                            touchPosition.y >= quitButton.rectTransform.position.y -
                            quitButton.rectTransform.rect.height / 2) {
                            Debug.Log("Quit");
                            Application.Quit();
#if UNITY_EDITOR
                            EditorApplication.isPlaying = false;
#endif
                        }
                    }
                }
            }
        }
    }
}