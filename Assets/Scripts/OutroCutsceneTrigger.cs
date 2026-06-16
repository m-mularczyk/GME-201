using UnityEngine;
using UnityEngine.Playables;

public class OutroCutsceneTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector _outroCutsceneTimeline;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Outro cutscene Trigger activated");
            _outroCutsceneTimeline.Play();
        }
    }
}
