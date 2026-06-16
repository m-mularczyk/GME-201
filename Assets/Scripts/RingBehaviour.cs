using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RingBehaviour : MonoBehaviour
{
    [SerializeField] private AudioClip _collectionSound;
    [SerializeField] private GameObject _nextRing;
    private GameManager _gameManager;
    private AudioManager _audioManager;

    void Start()
    {

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if( _gameManager == null)
        {
            Debug.LogError("Game Manager is NULL");
        }
        _audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        if ( _audioManager == null)
        {
            Debug.LogError("Audio Manager is NULL");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameManager.NewRingCollected();

            _audioManager.PlayCollectionSound();
            SpawnNextRing();

            Destroy(gameObject);
        }
    }

    private void SpawnNextRing()
    {
        if (_nextRing != null)
        {
            _nextRing.SetActive(true);
        }
        else
        {
            _gameManager.LastRingCollected();
        }
    }
}
