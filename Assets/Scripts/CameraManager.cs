using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private CinemachineCamera[] _virtualCameras;
    [SerializeField] private int _nextCameraIndex = 1;
    [SerializeField] private GameObject[] _collectionsForCameras;
    [SerializeField] private CinemachineSequencerCamera _cutsceneSequencerCamera;
    [SerializeField] private GameObject _instructionsTextObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Debug.Log("R key pressed");
            ResetAllVirtualCamerasPriority();

            for (int i = 0; i < _virtualCameras.Length; i++)
            {
                if (i == _nextCameraIndex)
                {
                    _virtualCameras[i].Priority = 15;
                    //Debug.Log("Current camera: " + _virtualCameras[i].name);

                    foreach (GameObject coll in _collectionsForCameras)
                    {
                        coll.SetActive(false);
                    }
                    _collectionsForCameras[i].SetActive(true);
                }
            }

            _nextCameraIndex++;
            if (_nextCameraIndex >= _virtualCameras.Length)
            {
                _nextCameraIndex = 0;

            }

            //Turn off input instructions after R key is pressed
            _instructionsTextObject.gameObject.SetActive(false);
        }
    }

    private void ResetAllVirtualCamerasPriority()
    {
        foreach (var cam in _virtualCameras)
        {
            cam.Priority = 10;
        }
    }

    public void PlayCutscene()
    {

        // Lower (= reset) all virtual cameras priority
        ResetAllVirtualCamerasPriority();

        // Set highest priority to the sequencer camera
        _cutsceneSequencerCamera.Priority = 15;

        // Enable/Disable given objects collections
        _collectionsForCameras[0].SetActive(true);
        _collectionsForCameras[1].SetActive(false);
    }

    public void EndCutscene()
    {
        _cutsceneSequencerCamera.Priority = 10;
        //_virtualCameras[0].Priority = 15;
        //_nextCameraIndex = 0;
        SwitchTo3rdPersonCamera();
        Debug.Log("Cutscene ended");
    }

    public void SwitchTo3rdPersonCamera()
    {
        ResetAllVirtualCamerasPriority();
        _virtualCameras[0].Priority = 15;
        _nextCameraIndex = 1;
        _collectionsForCameras[0].SetActive(true);
        _collectionsForCameras[0].SetActive(true);
    }
}
