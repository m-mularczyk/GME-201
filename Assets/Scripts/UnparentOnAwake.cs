using UnityEngine;

public class UnparentOnAwake : MonoBehaviour
{

    private void Awake()
    {
        gameObject.transform.parent = null;
    }
}
