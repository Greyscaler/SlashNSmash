using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class ButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject menu;
    public UnityEvent onStart; //Event when button initialised
    private Button button;

    void Start()
    {
        if (onStart == null)
        {
            onStart = new UnityEvent();
        }
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        onStart.Invoke();
    }
    
    
    public void OnClick()
    {
        SelectMenu();
        button = GetComponent<Button>();
        bool isSelected = button.animator.GetBool("isSelected");
        if (isSelected == false)
        {
            button.animator.SetBool("isSelected", true);
            foreach (Transform btn in button.gameObject.transform.parent)
            {
                if (btn.gameObject != button.gameObject)
                {
                    Animator animator = btn.gameObject.GetComponent<Animator>();
                    animator.SetBool("isSelected", false);
                }
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        button.animator.SetBool("isHover", true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        button.animator.SetBool("isHover", false);
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
