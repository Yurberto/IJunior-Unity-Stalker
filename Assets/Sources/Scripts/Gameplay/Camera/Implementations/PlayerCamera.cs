using UnityEngine;
using Assets.Sources.Scripts.Gameplay.Camera.Interfaces;
using Assets.Sources.Scripts.Gameplay.Camera.Services;
using Assets.Sources.Scripts.Gameplay.Characters.Player.Input;

public class PlayerCamera : MonoBehaviour, ICameraView
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _target;
    [SerializeField] private PlayerCameraSetting _cameraSetting;

    private ThirdPersonCamera _cameraService;

    public ICameraSetting Setting => _cameraSetting;

    public void Initialize(IInputService inputService)
    {
        _cameraService = new ThirdPersonCamera(inputService, this, _target);
        _cameraService.Enable();
    }

    private void OnDisable()
    {
        _cameraService.Disable();
    }

    private void LateUpdate()=>
        _cameraService.UpdateCamera();
}
