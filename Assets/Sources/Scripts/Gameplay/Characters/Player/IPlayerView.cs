using UnityEngine;

namespace Assets.Sources.Scripts.Gameplay.Characters.Player
{
    public interface IPlayerView
    {
        public Transform transform { get; }
        public CharacterController CharacterController { get; }

        public IPlayerSetting Setting { get; }
    }
}
