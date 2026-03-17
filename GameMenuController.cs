using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    public GameObject menuUI;      // Assign your MainMenu or Background object
    public bool isOpen = false;

    void Start()
    {
        menuUI.SetActive(false); // Hide initially
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        isOpen = !isOpen;
        menuUI.SetActive(isOpen);

        // Optional: pause/unpause time
        Time.timeScale = isOpen ? 0f : 1f;
    }
}
