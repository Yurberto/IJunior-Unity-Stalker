namespace Assets.Sources.Scripts.Gameplay.Camera.Setting
{
    public interface ICameraSetting
    {
        public float Height { get; }
        public float Distance { get; }
        public float OffsetX { get; }
        public float MinYAngle { get; }
        public float MaxYAngle { get; }
        public float Sensitivity { get; }
    }
}
