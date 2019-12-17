using Leopotam.Ecs;
using UnityEngine;

namespace SpaceJuJu
{
    sealed class InitSystem : IEcsInitSystem
    {
        const string PlayerTag = TagsDictionary.Player;
        readonly EcsWorld _world = null;
    
        public void Init()
        {
            foreach (var unityObject in GameObject.FindGameObjectsWithTag(PlayerTag))
            {
                var tr = unityObject.transform;
                EcsEntity player = _world.NewEntityWith<Unit, Player> (out var unitComponent, out var playerComponent);
                var pos = tr.localPosition;
                unitComponent.position.x = pos.x;
                unitComponent.position.y = pos.z;
                unitComponent.transform = tr;
            }
        }
    }

}
