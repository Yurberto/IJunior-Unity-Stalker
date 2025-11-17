namespace Assets.Sources.StaticData.Animator
{
    public static class PlayerAnimatorData
    {
        public static readonly int Run = UnityEngine.Animator.StringToHash(nameof(Run));
        public static readonly int Idle = UnityEngine.Animator.StringToHash(nameof(Idle));
        public static readonly int Jump = UnityEngine.Animator.StringToHash(nameof(Jump));
    }
}
