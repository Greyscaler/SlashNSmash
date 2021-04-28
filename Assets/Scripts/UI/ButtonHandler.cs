using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class ButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject menu;
    public UnityEvent onStart; //Event when button initialised
    private Button button;
    int isHoverHash,isSelectedHash;

    void Awake()
    {
        if (onStart == null)
        {
            onStart = new UnityEvent();
        }
    }
    void Start()
    {
        isSelectedHash = Animator.StringToHash("isSelected");
        isHoverHash = Animator.StringToHash("isHover");
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        onStart.Invoke();
    }
    
    
    public void OnClick()
    {
        SelectMenu();
        button = GetComponent<Button>();
        bool isSelected = button.animator.GetBool(isSelectedHash);
        if (isSelected == false)
        {
            button.animator.SetBool(isSelectedHash, true);
            foreach (Transform btn in button.gameObject.transform.parent)
            {
                if (btn.gameObject != button.gameObject)
                {
                    Animator animator = btn.gameObject.GetComponent<Animator>();
                    animator.SetBool(isSelectedHash, false);
                }
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        button.animator.SetBool(isSelectedHash, true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        button.animator.SetBool(isHoverHash, false);
    }
    public void OnSelected()
    {
        button.animator.SetBool(isHoverHash, true);
    }
    public void OnDeselected()
    {
        button.animator.SetBool(isHoverHash, false);
    }
    private void SelectMenu()
    {   
        foreach (Transform panel in menu.transform.parent)
        {
            panel.gameObject.SetActive(false);
        }
        menu.SetActive(true);
    }
    
}   
