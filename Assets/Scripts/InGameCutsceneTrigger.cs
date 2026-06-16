using UnityEngine;
using UnityEngine.Playables;

public class InGameCutsceneTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector _inGameCutsceneTimeline;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("In-game cutscene Trigger activated");
            _inGameCutsceneTimeline.Play();
        }
    }
}
