using Assets.Sources.Scripts.Gameplay.Characters.FSM.Factories;
using Assets.Sources.Scripts.Gameplay.Characters.Player;
using Assets.Sources.Scripts.Gameplay.Characters.Player.Input;
using Assets.Sources.Scripts.Gameplay.Characters.Services.Implementations;
using Assets.Sources.Scripts.Gameplay.Characters.Services.Interfaces;
using UnityEngine;

namespace Assets.Sources.Scripts.Gameplay
{
    internal class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private PlayerCamera _playerCamera;
        [SerializeField] private Animator _playerAnimator;

        private IInputService _inputService;

        private void Awake()
        {
            PlayerInput playerInput = new();
            _inputService = new InputService(playerInput);
        }

        private void OnEnable()
        {
            _inputService.Enable();
            InitializePlayer(_inputService);
        }

        private void OnDisable()
        {
            _inputService.Disable();
        }

        private void InitializePlayer(IInputService inputService)
        {
            IPlayerAnimator playerAnimator = new PlayerAnimator(_playerAnimator);
            IMover mover = new CharacterControllerMover(_player.CharacterController);
            IRotator rotator = new Rotator(_player.transform);

            PlayerStateMachineFactory stateMachineFactory = new(inputService, playerAnimator, _player, _playerCamera, mover, rotator);
            StateMachine stateMachine = stateMachineFactory.Create();

            _player.Initialize(stateMachine);
            _playerCamera.Initialize(inputService);
        }
    }
}
