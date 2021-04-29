using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    private MenuSwitch menuSwitch;
    
    private void Awake()
    {
        menuSwitch = GetComponent<MenuSwitch>();
    }

    private void DeselectEverything()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void PlayGame()
    {
        DeselectEverything();
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
