using UnityEngine;
using UnityEngine.Playables;

public class OutroCutsceneTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector _outroCutsceneTimeline;

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
            Debug.Log("Outro cutscene Trigger activated");
            _outroCutsceneTimeline.Play();
        }
    }
}
