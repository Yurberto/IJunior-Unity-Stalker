using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSetting", menuName = "ScriptableObject/PlayerSetting")]
public class PlayerSetting : ScriptableObject, IPlayerSetting
{
    [field: SerializeField] public float MoveSpeed { get; private set; } = 150;
    [field: SerializeField] public float RotateSpeed { get; private set; } = 7;
}
