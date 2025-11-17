using UnityEngine;
using Assets.Sources.Scripts.Gameplay.Characters.Companion.Animator;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.Interfaces;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.State;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.State.Updating;

namespace Assets.Sources.Scripts.Gameplay.Characters.Companion.States
{
    public class CompanionIdleState : IEnterableState, IUpdatableState
    {
        private readonly ICompanionAnimator _compamionAnimator;
        private readonly ICompanionView _companionView;

        private IStateChanger _stateChanger;

        private Transform _target;

        public CompanionIdleState(ICompanionAnimator compamionAnimator, ICompanionView companionView, Transform target)
        {
            _compamionAnimator = compamionAnimator;
            _companionView = companionView;
            _target = target;
        }

        public void SetStateChanger(IStateChanger stateChanger) =>
            _stateChanger = stateChanger;

        public void Enter() =>
            _compamionAnimator.OnIdle();

        public void Update()
        {
            Vector3 direction = _target.position - _companionView.Transform.position;

            if (direction.sqrMagnitude > _companionView.Setting.FollowDistance.Squared())
                ChangeToFollow();
        }

        private void ChangeToFollow() =>
            _stateChanger.ChangeState<CompanionFollowState>();
    }
}
