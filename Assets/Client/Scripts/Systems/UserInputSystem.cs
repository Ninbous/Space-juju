using Leopotam.Ecs;
using UnityEngine;

namespace SpaceJuJu
{
    sealed class UserInputSystem : IEcsRunSystem
    {
        readonly EcsFilter<Player, Unit> _playerFilter = null;

        private Vector3 touchPosition;
        private BoxCollider collider;
        
        public void Run()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    var player = _playerFilter.Get2[0];

                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                    if (touchPosition.x <= player.position.x + 15f && 
                        touchPosition.x >= player.position.x - 15f &&
                        touchPosition.z <= player.position.y + 15f && 
                        touchPosition.z >= player.position.y - 15f)
                    {
                        player.position.x = touchPosition.x;
                        player.position.y = touchPosition.z;
                        player.transform.localPosition = new Vector3(player.position.x, 0f, player.position.y);
                    }
                }
            }
        }
    }
}