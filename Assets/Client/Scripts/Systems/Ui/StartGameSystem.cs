using Leopotam.Ecs;

namespace Client {
    sealed class StartGameSystem : IEcsInitSystem {
        // Auto-injected fields.
        readonly EcsWorld _world = null;
        
        void IEcsInitSystem.Init () {
            // Add your initialize code here.
        }
    }
}