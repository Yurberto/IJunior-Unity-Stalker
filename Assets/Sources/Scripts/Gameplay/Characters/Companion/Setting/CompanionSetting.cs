using UnityEngine;

namespace Assets.Sources.Scripts.Gameplay.Characters.Companion.Setting
{
    [CreateAssetMenu(fileName = nameof(CompanionSetting), menuName = nameof(ScriptableObject) + "/" + nameof(CompanionSetting))]
    public class CompanionSetting : ScriptableObject, ICompanionSetting
    {
        [field: SerializeField, Min(0.0f)] public float MoveSpeed { get; private set; } = 1.5f;
        [field: SerializeField, Min(0.0f)] public float RotateSpeed { get; private set; } = 5.0f;
        [field: SerializeField, Min(0.0f)] public float FollowDistance { get; private set; } = 2.3f;
    }
}
