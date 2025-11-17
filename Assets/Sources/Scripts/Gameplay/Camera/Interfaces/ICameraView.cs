using Assets.Sources.Scripts.Gameplay.Camera.Setting;
using UnityEngine;

namespace Assets.Sources.Scripts.Gameplay.Camera.Interfaces
{
    public interface ICameraView
    {
        public Transform Transform { get; }

        public ICameraSetting Setting { get; }
    }
}
