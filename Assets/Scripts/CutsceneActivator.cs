using System.Collections;
using UnityEngine;

public class CutsceneActivator : MonoBehaviour
{
    [SerializeField]
    private CameraManager _cameraManager;

    [SerializeField] private float _timeWaiting = 5f;
    [SerializeField] private bool _cutsceneIsPlaying = false;
    //[SerializeField] private bool _mouseNotMoving = false;
    //[SerializeField] private bool _timerIsCounting = false;

    private Vector3 _mousePosition;
    private Vector3 _lastMousePosition;

    void Start()
    {
        StartCoroutine("CutsceneActivationRoutine");
        _lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        AnyKeyInputDetection();
        MouseMovementDetection();
    }

    private void AnyKeyInputDetection()
    {
        if (Input.anyKeyDown)
        {
            //Debug.Log("Input key detected");
            //StopCoroutine("CutsceneActivationRoutine");
            StopAllCoroutines();
            StartCoroutine("CutsceneActivationRoutine");

            InterruptCutscene();
        }
    }

    private void InterruptCutscene()
    {
        // Przerwij cutscenkê
        if (_cutsceneIsPlaying)
        {
            _cameraManager.EndCutscene();
            _cutsceneIsPlaying = false;
            Debug.Log("Cutscene stopped as Input was detected");
            //_cameraManager.Setup3rdPersonCamera();
        }
    }

    private void MouseMovementDetection()
    {
        _mousePosition = Input.mousePosition;

        if (_mousePosition == _lastMousePosition)
        {
            // Mouse is not moving
            //_mouseNotMoving = true;
        }
        else
        {
            // Mouse is moving
            //_mouseNotMoving = false;
            _lastMousePosition = _mousePosition;
            StopAllCoroutines();
            StartCoroutine("CutsceneActivationRoutine");

            InterruptCutscene();
        }
    }

    IEnumerator CutsceneActivationRoutine()
    {
        //_timerIsCounting = true;
        yield return new WaitForSeconds(_timeWaiting);
        _cameraManager.PlayCutscene();
        _cutsceneIsPlaying = true;
        Debug.Log("Cutscene activated");
        //_timerIsCounting = false;
    }
}
