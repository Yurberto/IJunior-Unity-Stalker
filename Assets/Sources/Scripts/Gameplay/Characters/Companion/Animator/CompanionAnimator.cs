using Assets.Sources.StaticData.Animator;

namespace Assets.Sources.Scripts.Gameplay.Characters.Companion.Animator
{
    public class CompanionAnimator : ICompanionAnimator
    {
        private UnityEngine.Animator _animator;

        public CompanionAnimator(UnityEngine.Animator animator) =>
            _animator = animator;

        public void OnIdle() =>
            _animator.SetTrigger(ComapanionAnimatorData.Idle);

        public void OnFollow() =>
            _animator.SetTrigger(ComapanionAnimatorData.Follow);
    }
}
