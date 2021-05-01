using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, IPointerClickHandler, ISubmitHandler
{
    private Button button;
    int isHoverHash,isSelectedHash,isSubmitedHash;
    public bool autoClick;
    public bool autoSelect;
    public bool selectWhenHover;
    public bool deselectOtherButtons;

    void Awake()
    {
        button = GetComponent<Button>();
        isSubmitedHash = Animator.StringToHash("isSubmited");
        isSelectedHash = Animator.StringToHash("isSelected");
        isHoverHash = Animator.StringToHash("isHover");
       
        
    }
    private void OnEnable()
    {
        if (this.gameObject.activeInHierarchy)
        {
            if (autoClick)
            {
                button.Select();
                Submit();
                button.onClick.Invoke();
            }
            else if (autoSelect)
            {
                button.Select();
            }
            
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnSubmit(eventData);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (selectWhenHover)
        {
            button.Select();
        }
        else
        {
            button.animator.SetBool(isHoverHash, true);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!selectWhenHover)
        {
            button.animator.SetBool(isHoverHash, false);
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        button.animator.SetBool(isSelectedHash, true);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        button.animator.SetBool(isSelectedHash, false);
    }
    public void OnSubmit(BaseEventData eventData)
    {
        Submit(); 
    }
    public void Submit()
    {
        button = GetComponent<Button>();
        button.animator.SetBool(isSubmitedHash, true);
        if (deselectOtherButtons)
        {
            foreach (Transform btn in button.gameObject.transform.parent)               //Deselect all other buttons except selected
            {
                if (btn.gameObject != button.gameObject)
                {
                    Animator animator = btn.gameObject.GetComponent<Animator>();
                    animator.SetBool(isSubmitedHash, false);
                }
            }
        }
        
    }
    
}   
