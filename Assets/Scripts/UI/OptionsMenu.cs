using UnityEngine;
using UnityEngine.UI;


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
    
    private void OnEnable()
    {
        controls.Enable();
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
