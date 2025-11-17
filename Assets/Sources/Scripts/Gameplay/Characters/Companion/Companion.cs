using UnityEngine;
using Assets.Sources.Scripts.Gameplay.Characters.Companion.Setting;
using Assets.Sources.Scripts.Gameplay.Characters.FSM.Interfaces;

namespace Assets.Sources.Scripts.Gameplay.Characters.Companion
{
    public class Companion : MonoBehaviour, ICompanionView
    {
        [SerializeField] private CompanionSetting _setting;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _transform;

        private IStateUpdater _stateUpdater;
            
        public ICompanionSetting Setting => _setting;
        public Rigidbody Rigidbody => _rigidbody;
        public Transform Transform => _transform;

        public void Initialize(IStateUpdater stateUpdater) =>
            _stateUpdater = stateUpdater;

        private void FixedUpdate() =>
            _stateUpdater.FixedUpdateState();

        private void Update() =>
            _stateUpdater.UpdateState();
    }
}
