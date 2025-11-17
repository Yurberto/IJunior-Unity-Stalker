using UnityEngine;


namespace Assets.Sources.Scripts.Gameplay.Characters.Services.Interfaces
{
    public interface IMover
    {
        public void Move(Vector3 direction, float speed);
        public void Stop();
    }
}
