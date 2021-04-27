using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour
{
    public Button backButton;
    public Button selectedButton;
    public GameObject previousMenu;
    private Transform optionsMenu;
    private bool isButtonInitialized = false;
 
    private void Start()
    {
        optionsMenu = GetComponent<Transform>();
        backButton.onClick.AddListener(OnClick);
        
    }
    
    private void OnEnable()
    {
        if (isButtonInitialized)
        {
            selectedButton.onClick.Invoke();
        }
        else
        {
            ButtonHandler btn = selectedButton.GetComponent<ButtonHandler>();
            btn.onStart.AddListener(buttonInitialised);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClick();
        }
    }
    public void OnClick()
    {
        optionsMenu.gameObject.SetActive(false);
        previousMenu.gameObject.SetActive(true);
    }

    private void buttonInitialised()
    {
        isButtonInitialized = true;
        selectedButton.onClick.Invoke();
    }

}