using Assets.Sources.Scripts.Gameplay.Characters.Companion.Setting;
using UnityEngine;

namespace Assets.Sources.Scripts.Gameplay.Characters.Companion
{
    public interface ICompanionView
    {
        public Transform Transform { get; }
        public Rigidbody Rigidbody { get; }

        public ICompanionSetting Setting { get; }
    }
}
