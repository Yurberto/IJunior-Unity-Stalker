using Assets.Sources.Scripts.Gameplay.Characters.FSM.Interfaces;

namespace Assets.Sources.Scripts.Gameplay.Characters.FSM.State
{
    public interface IState 
    {
        public void SetStateChanger(IStateChanger stateChanger);
    }
}
