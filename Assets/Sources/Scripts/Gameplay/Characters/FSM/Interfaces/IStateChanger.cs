using Assets.Sources.Scripts.Gameplay.Characters.FSM.State;

namespace Assets.Sources.Scripts.Gameplay.Characters.FSM.Interfaces
{
    public interface IStateChanger
    {
        public void ChangeState<T>() where T : IState;
    }
}
