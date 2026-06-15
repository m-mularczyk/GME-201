using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField]
    private CinemachineCamera[] _virtualCameras;
    [SerializeField]
    private int _nextCameraIndex = 1;

    [SerializeField]
    private GameObject[] _collectionsForCameras;

    [SerializeField]
    private CinemachineSequencerCamera _cutsceneSequencerCamera;

    [SerializeField]
    private GameObject _instructionsTextObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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

            //Turn off R key input instructions
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

        // Obni¿ priorytet wszystkich kamer wirtualnych
        ResetAllVirtualCamerasPriority();

        //Ustaw kamerê sekwencyjn¹ Cutscen'ki na najwy¿szy
        _cutsceneSequencerCamera.Priority = 15;

        // W³¹cz lub wy³¹cz odpowiednie kolekcje obiektów
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
