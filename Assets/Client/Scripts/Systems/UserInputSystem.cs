using Leopotam.Ecs;
using UnityEngine;

namespace SpaceJuJu
{
    sealed class UserInputSystem : IEcsRunSystem, IEcsInitSystem
    {
        readonly EcsFilter<Player> _playerFilter = null;
        readonly EcsFilter<Unit> _unitFilter = null;

        private Vector3 touchPosition;
        private BoxCollider collider;

        public void Init()
        {
            foreach (var i in _unitFilter)
            {
                var player = _unitFilter.Get1[i];
            }
        }

        public void Run()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    var player = _unitFilter.Get1[0];

                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.y = 10;

                    if (touchPosition.x <= player.position.x + 10f && 
                        touchPosition.x >= player.position.x - 10f &&
                        touchPosition.z <= player.position.y + 10f && 
                        touchPosition.z >= player.position.y - 10f)
                    {
                        player.position.x = touchPosition.x;
                        player.position.y = touchPosition.z;
                        player.transform.localPosition = new Vector3(player.position.x, 10f, player.position.y);
                    }

//                    Debug.Log("position x: " + player.position.x + " y: " + player.position.y);
                }
            }
        }
    }
}