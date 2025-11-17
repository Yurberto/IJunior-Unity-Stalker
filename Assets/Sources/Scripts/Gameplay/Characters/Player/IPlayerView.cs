using UnityEngine;
using Assets.Sources.Scripts.Gameplay.Characters.Player.Setting;

namespace Assets.Sources.Scripts.Gameplay.Characters.Player
{
    public interface IPlayerView
    {
        public Transform Transform { get; }
        public CharacterController CharacterController { get; }

        public IPlayerSetting Setting { get; }
    }
}
