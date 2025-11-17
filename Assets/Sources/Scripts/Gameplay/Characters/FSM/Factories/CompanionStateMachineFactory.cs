using Assets.Sources.Scripts.Gameplay.Characters.Companion;
using Assets.Sources.Scripts.Gameplay.Characters.Companion.Animator;
using Assets.Sources.Scripts.Gameplay.Characters.Companion.States;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.State;
using Assets.Sources.Scripts.Gameplay.Characters.Player;
using Assets.Sources.Scripts.Gameplay.Characters.Services.Interfaces;
using System.Collections.Generic;

namespace Assets.Sources.Scripts.Gameplay.Characters.FSM.Factories
{
    public class CompanionStateMachineFactory
    {
        private readonly ICompanionAnimator _companionAnimator;
        private readonly ICompanionView _companionView;
        private readonly IMover _mover;
        private readonly IRotator _rotator;

        private readonly IPlayerView _playerView;

        public CompanionStateMachineFactory
            (
            ICompanionAnimator companionAnimator, 
            ICompanionView companionView, 
            IMover mover, 
            IRotator rotator,
            IPlayerView playerView
            )
        {
            _companionAnimator = companionAnimator;
            _companionView = companionView;
            _mover = mover;
            _rotator = rotator;
            _playerView = playerView;
        }

        public StateMachine Create()
        {
            List<IState> states = new List<IState>()
            {
                new CompanionIdleState(_companionAnimator, _companionView, _playerView.Transform),
                new CompanionFollowState(_companionAnimator, _companionView, _mover, _rotator, _playerView.Transform)
            };

            StateMachine stateMachine = new(states);

            for (int i = 0; i < states.Count; i++)
                states[i].SetStateChanger(stateMachine);

            stateMachine.ChangeState<CompanionIdleState>();

            return stateMachine;
        }
    }
}
