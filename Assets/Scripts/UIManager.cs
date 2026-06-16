using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject _instructionsText;
    [SerializeField] private GameObject _reloadSceneBTN;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void DisplayInstructions()
    {
        Debug.Log("Instructions displayed");
        _instructionsText.SetActive(true);
    }

    public void DisplayReloadButton()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _reloadSceneBTN.SetActive(true);
    }
}
