using Assets.Sources.Scripts.Gameplay.Characters.FSM.Interfaces;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.State;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.State.Updating;
using Assets.Sources.Scripts.Gameplay.Characters.Player.Animator;
using Assets.Sources.Scripts.Gameplay.Characters.Player.Input;

namespace Assets.Sources.Scripts.Gameplay.Characters.Player.States
{
    internal class PlayerIdleState : IEnterableState, IExitableState, IUpdatableState
    {
        private readonly IInputService _inputService;
        private readonly IPlayerAnimator _playerAnimator;

        private IStateChanger _stateChanger;

        public PlayerIdleState(IInputService inputService, IPlayerAnimator playerAnimator)
        {
            _inputService = inputService;
            _playerAnimator = playerAnimator;
        }

        public void SetStateChanger(IStateChanger stateChanger)
        {
            _stateChanger = stateChanger;
        }

        public void Enter()
        {
            _playerAnimator.OnIdle();
            _inputService.MoveButtonPressed += ChangeToMove;
        }

        public void Exit()
        {
            _inputService.MoveButtonPressed -= ChangeToMove;
        }

        public void Update()
        {
            if (_inputService.MoveDirection.sqrMagnitude.MoreThenEpsilon())
                ChangeToMove();
        }

        private void ChangeToMove()
        {
            _stateChanger.ChangeState<PlayerMoveState>();
        }
    }
}
