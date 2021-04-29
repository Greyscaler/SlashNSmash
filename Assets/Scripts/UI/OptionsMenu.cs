using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class OptionsMenu : MonoBehaviour
{
    public Button backButton;
    public Button selectedButton;
    public GameObject previousMenu;
    private Transform optionsMenu;
    private bool isButtonInitialized = false;
    private InputMaster controls;

    private void Awake()
    {
        controls = new InputMaster();
        controls.UI.Cancel.performed += ctx => OnClick();
    }
    private void Start()
    {
        optionsMenu = GetComponent<Transform>();
        backButton.onClick.AddListener(OnClick);
        
    }
    
    public void OnEnable()
    {
        controls.Enable();
        EventSystem.current.SetSelectedGameObject(selectedButton.gameObject);
        if (isButtonInitialized)
        {
            selectedButton.onClick.Invoke();
        }
        else
        {
            ButtonBehaviour btn = selectedButton.GetComponent<ButtonBehaviour>();
           // btn.onStart.AddListener(buttonInitialised);
        }
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void OnDestroy()
    {
        controls.UI.Cancel.performed -= ctx => OnClick();
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
