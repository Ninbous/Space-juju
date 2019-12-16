
using Leopotam.Ecs;
using UnityEngine;

namespace SpaceJuJu {
    sealed class QuitGameSystem : IEcsRunSystem, IEcsInitSystem {
        
        readonly EcsFilter<QuitButton> _quitButtonFilter = null;
        
        // Auto-injected fields.
        readonly EcsWorld _world = null;

        private const string UiQuitButtonTag = TagsDictionary.UiQuitButton;
        private Vector3 touchPosition;

        public void Init()
        {
            foreach (var unityObject in GameObject.FindGameObjectsWithTag(UiQuitButtonTag))
            {
                var tr = unityObject.GetComponent<RectTransform>();
                _world.NewEntityWith<QuitButton> (out var quitButtonComponent);
                quitButtonComponent.rectTransform = tr;
            }
        }

        void IEcsRunSystem.Run () {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    var quitButton = _quitButtonFilter.Get1[0];
                    
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition = touch.position;
//                    Debug.Log("Touch x: " + touchPosition.x + " y: " + touchPosition.y);
//                    Debug.Log("Quit x: " + quitButton.rectTransform.position.x + 
//                              " y: " + quitButton.rectTransform.position.y);
//                    Debug.Log("Touch width: " + quitButton.rectTransform.rect.width + 
//                              " height: " + quitButton.rectTransform.rect.height);

                    if (touchPosition.x <= quitButton.rectTransform.position.x + quitButton.rectTransform.rect.width/2 &&
                        touchPosition.x >= quitButton.rectTransform.position.x  - quitButton.rectTransform.rect.width/2 &&
                        touchPosition.y <= quitButton.rectTransform.position.y + quitButton.rectTransform.rect.height/2 &&
                        touchPosition.y >= quitButton.rectTransform.position.y - quitButton.rectTransform.rect.height/2)
                    {
                        Debug.Log("ПОПАЛ!");
                        Application.Quit();
                    }
                    
                }
            }
        }
    }
}