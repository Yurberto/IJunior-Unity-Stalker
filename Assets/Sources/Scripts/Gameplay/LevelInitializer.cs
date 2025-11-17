using Assets.Sources.Scripts.Gameplay.Characters.Companion;
using Assets.Sources.Scripts.Gameplay.Characters.Companion.Animator;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.Factories;
using Assets.Sources.Scripts.Gameplay.Characters.Player;
using Assets.Sources.Scripts.Gameplay.Characters.Player.Animator;
using Assets.Sources.Scripts.Gameplay.Characters.Player.Input;
using Assets.Sources.Scripts.Gameplay.Characters.Services.Implementations;
using Assets.Sources.Scripts.Gameplay.Characters.Services.Interfaces;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Assets.Sources.Scripts.Gameplay
{
    internal class LevelInitializer : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private Player _player;
        [SerializeField] private PlayerCamera _playerCamera;
        [SerializeField] private Animator _playerAnimator;

        [Header("Companion")]
        [SerializeField] private Companion _companion;
        [SerializeField] private Animator _companionAnimator;

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
            InitializeCompanion();
        }

        private void OnDisable()
        {
            _inputService.Disable();
        }

        private void InitializePlayer(IInputService inputService)
        {
            IPlayerAnimator animator = new PlayerAnimator(_playerAnimator);
            IMover mover = new CharacterControllerMover(_player.CharacterController);
            IRotator rotator = new Rotator(_player.transform);

            PlayerStateMachineFactory stateMachineFactory = new(inputService, animator, _player, _playerCamera, mover, rotator);
            StateMachine stateMachine = stateMachineFactory.Create();

            _player.Initialize(stateMachine);
            _playerCamera.Initialize(inputService);
        }

        private void InitializeCompanion()
        {
            ICompanionAnimator animator = new CompanionAnimator(_companionAnimator);
            IMover mover = new RigidbodyMover(_companion.Rigidbody);
            IRotator rotator = new Rotator(_companion.transform);

            CompanionStateMachineFactory companionStateMachineFactory = new(animator, _companion, mover, rotator, _player);
            StateMachine stateMachine = companionStateMachineFactory.Create();

            _companion.Initialize(stateMachine);
        }
    }
}
