namespace Assets.Sources.Scripts.Gameplay.Characters.FSM.State.Updating
{
    public interface ILateUpdatableState : IState
    {
        public void LateUpdate();
    }
}
