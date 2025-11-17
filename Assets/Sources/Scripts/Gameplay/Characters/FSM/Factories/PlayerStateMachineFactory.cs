using System.Collections.Generic;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.State;
using Assets.Sources.Scripts.Gameplay.Characters.Player.Input;
using Assets.Sources.Scripts.Gameplay.Characters.Player.States;
using Assets.Sources.Scripts.Gameplay.Characters.Services.Interfaces;
using Assets.Sources.Scripts.Gameplay.Characters.Player;
using Assets.Sources.Scripts.Gameplay.Camera.Interfaces;
using Assets.Sources.Scripts.Gameplay.Characters.Player.Animator;

namespace Assets.Sources.Scripts.Gameplay.Characters.FSM.Factories
{
    public class PlayerStateMachineFactory
    {
        private readonly IInputService _inputService;

        private readonly IPlayerAnimator _playerAnimator;

        private readonly IPlayerView _playerView;
        private readonly ICameraView _cameraView;

        private readonly IMover _mover;
        private readonly IRotator _rotator;

        public PlayerStateMachineFactory
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

        public StateMachine Create()
        {
            List<IState> states = new List<IState>()
            {
                new PlayerIdleState(_inputService, _playerAnimator),
                new PlayerMoveState(_inputService, _playerAnimator, _playerView, _cameraView, _mover, _rotator)
            };

            StateMachine stateMachine = new StateMachine(states);

            for (int i = 0; i < states.Count; i++)
                states[i].SetStateChanger(stateMachine);

            stateMachine.ChangeState<PlayerIdleState>();

            return stateMachine;
        }
    }
}
