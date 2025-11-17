using UnityEngine;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.Interfaces;

namespace Assets.Sources.Scripts.Gameplay.Characters.Player
{
    public class Player : MonoBehaviour, IPlayerView
    {
        [SerializeField] private PlayerSetting _playerSetting;
        [SerializeField] private CharacterController _characterController;

        private IStateUpdater _stateUpdater;

        public IPlayerSetting Setting => _playerSetting;
        public CharacterController CharacterController => _characterController;

        public void Initialize(IStateUpdater stateUpdater) =>
            _stateUpdater = stateUpdater;

        private void FixedUpdate() =>
            _stateUpdater.FixedUpdateState();

        private void Update() => 
            _stateUpdater.UpdateState();
    }
}
