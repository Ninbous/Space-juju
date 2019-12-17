using Leopotam.Ecs;
#if UNITY_EDITOR
using Leopotam.Ecs.UnityIntegration;
#endif
using UnityEngine;

namespace SpaceJuJu {
    sealed class GameStartup : MonoBehaviour {
        EcsSystems _systems;
        EcsWorld _world;
        public GameObject playerPrefab;

        void OnEnable () {
            _world = new EcsWorld ();
#if UNITY_EDITOR
            EcsWorldObserver.Create (_world);
#endif
            _systems = new EcsSystems (_world)
                .Add(new StartGameSystem())
                .Add (new UserInputSystem());
            _systems.Init ();
#if UNITY_EDITOR
            EcsSystemsObserver.Create (_systems);
#endif
        }

        void Update ()
        {
            _systems.Run ();
            _world.EndFrame ();
        }

        void OnDisable () {
            _systems.Destroy ();
            _systems = null;
            _world.Destroy ();
            _world = null;
        }
    }
}