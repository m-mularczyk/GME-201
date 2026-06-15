using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _instructionsText;

    [SerializeField]
    private GameObject _reloadSceneBTN;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
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
