using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonInitializationHandler : MonoBehaviour
{
    public GameObject firstSelectedButton;
    private ButtonInitialized buttonHandler;
    private Button button;
    bool isButtonInitialized = false;

    private void Awake()
    {
        buttonHandler = firstSelectedButton.GetComponent<ButtonInitialized>();
        
    }
    private void OnEnable()
    {
        if (isButtonInitialized)
        {
            SelectButton();
        }
        else
        {
            buttonHandler.onStart.AddListener(SelectButton);
        }
    }
    
    private void OnDisable()
    {
        buttonHandler.onStart.RemoveListener(SelectButton);
        isButtonInitialized = false;
        EventSystem.current.SetSelectedGameObject(null);
    }
    private void SelectButton()
    {
        Debug.Log("Trying");
        isButtonInitialized = true;
        button = firstSelectedButton.GetComponent<Button>();
        button.Select();
        
        
    }

}
