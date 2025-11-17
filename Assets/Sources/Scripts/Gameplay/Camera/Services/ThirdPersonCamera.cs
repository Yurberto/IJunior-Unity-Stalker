using Assets.Sources.Scripts.Gameplay.Camera.Interfaces;
using Assets.Sources.Scripts.Gameplay.Characters.Player.Input;
using System;
using UnityEngine;

namespace Assets.Sources.Scripts.Gameplay.Camera.Services
{
    public class ThirdPersonCamera
    {
        private IInputService _inputService;
        private ICameraView _camera;
        private Transform _target;

        private float _mouseX = 0.0f;
        private float _mouseY = 0.0f;

        public ThirdPersonCamera(IInputService inputService, ICameraView camera, Transform target)
        {
            _inputService = inputService;
            _camera = camera;
            _target = target;
        }

        public void Enable()
        {
            _inputService.MouseDeltaChanged += UpdateLook;
        }

        public void Disable()
        {
            _inputService.MouseDeltaChanged -= UpdateLook;
        }

        public void UpdateCamera()
        {
            _mouseY = Mathf.Clamp(_mouseY, _camera.Setting.MinYAngle, _camera.Setting.MaxYAngle);

            Quaternion rotation = Quaternion.Euler(-1 * _mouseY, _mouseX, 0.0f);

            Vector3 distance = rotation * new Vector3(0.0f, 0.0f, -1 * _camera.Setting.Distance);
            Vector3 offsetX = _camera.Setting.OffsetX * _camera.transform.right;
            Vector3 hight = _camera.Setting.Height * Vector3.up;

            _camera.transform.position = _target.position + distance + hight + offsetX;
            _camera.transform.LookAt(_target.position + hight + offsetX);
        }

        private void UpdateLook()
        {
            _mouseX += _inputService.MouseDelta.x * _camera.Setting.Sensitivity * Time.deltaTime;
            _mouseY += _inputService.MouseDelta.y * _camera.Setting.Sensitivity * Time.deltaTime;
        }
    }
}
