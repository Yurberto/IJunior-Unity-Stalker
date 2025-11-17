namespace Assets.Sources.Scripts.Gameplay.Characters.FSM.Interfaces
{
    public interface IStateUpdater
    {
        public void FixedUpdateState();
        public void UpdateState();
        public void LateUpdateState();
    }
}
