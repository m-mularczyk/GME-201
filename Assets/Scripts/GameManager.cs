using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _ringsCollected = 0;
    [SerializeField] private PlayableDirector _outroTimeline;
    [SerializeField] private GameObject _firstRingToCollect;
    [SerializeField] private ShipControls _shipControls;

    void Start()
    {
        _firstRingToCollect.SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowFirstRingToCollect()
    {
        _firstRingToCollect.SetActive(true);
    }

    public void NewRingCollected()
    {
        _ringsCollected++;
        //Debug.Log("New ring collected");
    }

    public void LastRingCollected()
    {
        // Launching Outro cutscene
        _outroTimeline.Play();
    }

    public void TurnOffShipControls()
    {
        _shipControls.enabled = false;
    }

    public void TurnOnShipControls()
    {
        _shipControls.enabled = true;
    }
}
