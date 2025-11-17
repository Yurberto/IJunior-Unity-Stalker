using UnityEngine;

namespace Assets.Sources.Scripts.Gameplay.Camera.Interfaces
{
    public interface ICameraView
    {
        public Transform transform { get; }

        public ICameraSetting Setting { get; }
    }
}
