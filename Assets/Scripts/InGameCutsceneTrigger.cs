using UnityEngine;
using UnityEngine.Playables;

public class InGameCutsceneTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _inGameCutsceneTimeline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("In-game cutscene Trigger activated");
            _inGameCutsceneTimeline.Play();
        }
    }
}
