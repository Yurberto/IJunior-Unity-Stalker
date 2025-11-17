using Assets.Sources.Scripts.Gameplay.Characters.Companion.Animator;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.Interfaces;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.State;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.State.Updating;
using Assets.Sources.Scripts.Gameplay.Characters.Services.Interfaces;
using UnityEngine;

namespace Assets.Sources.Scripts.Gameplay.Characters.Companion.States
{
    public class CompanionFollowState : IEnterableState, IExitableState, IFixedUpdatableState
    {
        private readonly ICompanionAnimator _companionAnimator;
        private readonly ICompanionView _companionView;
        private readonly IMover _mover;
        private readonly IRotator _rotator;

        private IStateChanger _stateChanger;

        private Transform _target;

        public CompanionFollowState
            (
            ICompanionAnimator companionAnimator,
            ICompanionView companionView,
            IMover mover,
            IRotator rotator,
            Transform target
            )
        {
            _companionAnimator = companionAnimator;
            _companionView = companionView;
            _mover = mover;
            _rotator = rotator;
            _target = target;
        }

        public void SetStateChanger(IStateChanger stateChanger) =>
            _stateChanger = stateChanger;

        public void Enter() =>
            _companionAnimator.OnFollow();

        public void Exit() =>
            _mover.Stop();

        public void FixedUpdate()
        {
            Vector3 direction = _target.position - _companionView.Transform.position;

            if (direction.sqrMagnitude < _companionView.Setting.FollowDistance.Squared())
                ChangeToIdle();

            direction.Normalize();

            _mover.Move(direction, _companionView.Setting.MoveSpeed * Time.fixedDeltaTime);
            _rotator.Rotate(direction, _companionView.Setting.RotateSpeed * Time.fixedDeltaTime);
        }

        private void ChangeToIdle() =>
            _stateChanger.ChangeState<CompanionIdleState>();
    }
}
