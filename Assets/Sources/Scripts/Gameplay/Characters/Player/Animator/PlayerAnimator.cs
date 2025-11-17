using Assets.Sources.StaticData.Animator;

namespace Assets.Sources.Scripts.Gameplay.Characters.Player.Animator
{
    public class PlayerAnimator : IPlayerAnimator
    {
        private UnityEngine.Animator _animator;

        public PlayerAnimator(UnityEngine.Animator animator) =>
            _animator = animator;

        public void OnIdle() =>
            _animator.SetTrigger(PlayerAnimatorData.Idle);

        public void OnMove() =>
            _animator.SetTrigger(PlayerAnimatorData.Run);
    }
}

