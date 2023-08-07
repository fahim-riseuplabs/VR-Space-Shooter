using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private InputDeviceCharacteristics _controllerType;

    private InputDevice _controller;
    private bool _isControllerDetected = false;
    private List<InputDevice> _controllerDevices = new List<InputDevice>();

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        _animator = GetComponent<Animator>();
    }

    private void Initialize()
    {
        InputDevices.GetDevicesWithCharacteristics(_controllerType, _controllerDevices);

        if (_controllerDevices.Count.Equals(0))
        {
            Debug.Log("No controller device found");
        }
        else
        {
            _controller = _controllerDevices[0];
            _isControllerDetected = true;
            Debug.Log(_controller.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isControllerDetected)
        {
            Initialize();
        }
        else
        {
            if (_controller.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
            {
                Debug.Log("trigger:" + triggerValue);
                _animator.SetFloat("Trigger", triggerValue);
            }
            else
            {
                _animator.SetFloat("Trigger", 0f);
            }
            if (_controller.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f)
            {
                Debug.Log("grip:" + gripValue);
                _animator.SetFloat("Grip", gripValue);
            }
            else
            {
                _animator.SetFloat("Grip", 0f);
            }
        }
    }
}