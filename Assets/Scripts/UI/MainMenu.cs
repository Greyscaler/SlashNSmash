using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject firstSelectedObject;
    public void MainMenuToggle()
    {
        if (!this.gameObject.activeInHierarchy)
        {
            this.gameObject.SetActive(!this.gameObject.activeInHierarchy);
            if (EventSystem.current != null && firstSelectedObject != null)
            {
                EventSystem.current.SetSelectedGameObject(firstSelectedObject);
            }
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
            this.gameObject.SetActive(!this.gameObject.activeInHierarchy);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
