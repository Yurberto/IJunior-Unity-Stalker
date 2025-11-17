using System;
using System.Linq;
using System.Collections.Generic;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.State;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.State.Updating;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.Interfaces;

public class StateMachine : IStateChanger, IStateUpdater
{
    private Dictionary<Type, IState> _states;

    private IState _current;

    public StateMachine(List<IState> states) =>
        _states = states.ToDictionary(type => type.GetType(), value => value);

    public void ChangeState<T>() where T : IState
    {
        if (_states.TryGetValue(typeof(T), out IState newState))
            ChangeCurrent(newState);
        else
            throw new Exception($"States has not {typeof(T)} state");
    }

    public void FixedUpdateState()
    {
        if (_current is IFixedUpdatableState fixedUpdatableState)
            fixedUpdatableState.FixedUpdate();
    }

    public void UpdateState()
    {
        if (_current is IUpdatableState UpdatableState)
            UpdatableState.Update();
    }

    public void LateUpdateState()
    {
        if (_current is ILateUpdatableState lateUpdatableState)
            lateUpdatableState.LateUpdate();
    }

    private void ChangeCurrent(IState newState)
    {
        if (_current == newState)
            return;

        if (newState is IExitableState exitableState)
            exitableState.Exit();

        _current = newState;

        if (_current is IEnterableState enterableState)
            enterableState.Enter();
    }
}
