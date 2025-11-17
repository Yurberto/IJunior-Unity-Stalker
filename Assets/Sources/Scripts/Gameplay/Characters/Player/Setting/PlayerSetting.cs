using UnityEngine;

namespace Assets.Sources.Scripts.Gameplay.Characters.Player.Setting
{
    [CreateAssetMenu(fileName = nameof(PlayerSetting), menuName = nameof(ScriptableObject) + "/" + nameof(PlayerSetting))]
    public class PlayerSetting : ScriptableObject, IPlayerSetting
    {
        [field: SerializeField] public float MoveSpeed { get; private set; } = 150;
        [field: SerializeField] public float RotateSpeed { get; private set; } = 7;
    }
}