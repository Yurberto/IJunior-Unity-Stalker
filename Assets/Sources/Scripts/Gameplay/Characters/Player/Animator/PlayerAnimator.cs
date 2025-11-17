using UnityEngine;

public class PlayerAnimator : IPlayerAnimator
{
    private Animator _animator;

    public PlayerAnimator(Animator animator) =>
        _animator = animator;

    public void OnIdle()
    {
        _animator.SetTrigger(AnimatorData.Idle);
    }

    public void OnMove()
    {
        _animator.SetTrigger(AnimatorData.Run);
    }
}
