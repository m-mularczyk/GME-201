using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioClip _collectionSound;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if( _audioSource == null)
        {
            Debug.LogError("AudioSource is NULL");
        }
    }

    public void PlayCollectionSound()
    {
        _audioSource.PlayOneShot(_collectionSound, 0.3f);
    }
}
