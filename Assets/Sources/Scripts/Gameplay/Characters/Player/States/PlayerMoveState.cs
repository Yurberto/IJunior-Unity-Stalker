using UnityEngine;
using Assets.Sources.Scripts.Gameplay.Characters.Services.Interfaces;
using Assets.Sources.Scripts.Gameplay.Characters.Player.Input;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.State.Updating;
using Assets.Sources.Scripts.Gameplay.Camera.Interfaces;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.Interfaces;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.State;
using Assets.Sources.Scripts.Gameplay.Characters.Player.Animator;

namespace Assets.Sources.Scripts.Gameplay.Characters.Player.States
{
    public class PlayerMoveState : IEnterableState, IExitableState, IFixedUpdatableState
    {
        private readonly IInputService _inputService;

        private readonly IPlayerAnimator _playerAnimator;

        private readonly IPlayerView _playerView;
        private readonly ICameraView _cameraView;

        private readonly IMover _mover;
        private readonly IRotator _rotator;

        private IStateChanger _stateChanger;

        public PlayerMoveState
            (
            IInputService inputService,
            IPlayerAnimator playerAnimator,
            IPlayerView playerView,
            ICameraView cameraView, 
            IMover mover,
            IRotator rotator
            )
        {
            _inputService = inputService;
            _playerAnimator = playerAnimator;
            _playerView = playerView;
            _cameraView = cameraView;
            _mover = mover;
            _rotator = rotator;
        }

        public void SetStateChanger(IStateChanger stateChanger)
        {
            _stateChanger = stateChanger;
        }

        public void Enter()
        {
            _playerAnimator.OnMove();
            _inputService.MoveButtonReleased += ChangeToIdle;
        }

        public void Exit()
        {
            _inputService.MoveButtonReleased -= ChangeToIdle;

            _mover.Stop();
        }

        public void FixedUpdate()
        {
            Vector3 direction = CalculateCurrentDirection();

            _mover.Move(direction, _playerView.Setting.MoveSpeed * Time.fixedDeltaTime);
            _rotator.Rotate(direction, _playerView.Setting.RotateSpeed * Time.fixedDeltaTime);
        }

        private Vector3 CalculateCurrentDirection()
        {
            Vector3 cameraForward = _cameraView.Transform.forward;
            Vector3 cameraRight = _cameraView.Transform.right;

            return _inputService.MoveDirection.x * cameraRight + _inputService.MoveDirection.z * cameraForward;
        }

        private void ChangeToIdle() =>
            _stateChanger.ChangeState<PlayerIdleState>();
    }
}