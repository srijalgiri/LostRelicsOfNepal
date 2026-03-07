using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject levelMenuUI;    // The Canvas or panel that contains the level menu
    public Button[] levelButtons;     // Assign Level_1, Level_2, etc. in order

    private int unlockedLevel;

    void Start()
    {
        // Start with menu hidden
        levelMenuUI.SetActive(false);

        // Load the unlocked level from saved data
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Enable only buttons up to the unlocked level
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = (i < unlockedLevel);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        bool isActive = !levelMenuUI.activeSelf;
        levelMenuUI.SetActive(isActive);

        // Optional: pause game while menu is open
        Time.timeScale = isActive ? 0f : 1f;
    }

    public void LoadLevel(int levelIndex)
    {
        // Resume game time in case it was paused
        Time.timeScale = 1f;

        // Load the scene by index
        SceneManager.LoadScene(levelIndex);
    }

    public void UnlockNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentScene + 1;

        // Only update if the next level is farther than current unlocked
        if (nextLevel > PlayerPrefs.GetInt("UnlockedLevel", 1))
        {
            PlayerPrefs.SetInt("UnlockedLevel", nextLevel);
            PlayerPrefs.Save();
        }
    }
}
