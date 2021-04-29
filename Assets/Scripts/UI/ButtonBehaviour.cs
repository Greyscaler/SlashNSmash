using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, IPointerClickHandler, ISubmitHandler
{
    private Button button;
    int isHoverHash,isSelectedHash;
    public bool autoClick;
    public bool autoSelect;
    public bool selectWhenHover;
    
    void Awake()
    {
        button = GetComponent<Button>();
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
                Submit();
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
        if(!selectWhenHover)
        {
            button.animator.SetBool(isHoverHash, false);
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        if(selectWhenHover)
        {
            button.animator.SetBool(isSelectedHash, true);
        }
        else
        {
            button.animator.SetBool(isHoverHash, true);
        }
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if(selectWhenHover)
        {
            button.animator.SetBool(isSelectedHash, false);
        }
        else
        {
            button.animator.SetBool(isHoverHash, false);
        }
    }
    public void OnSubmit(BaseEventData eventData)
    {
        Submit(); 
    }
    private void Submit()
    {
        button = GetComponent<Button>();

        button.animator.SetBool(isSelectedHash, true);

        foreach (Transform btn in button.gameObject.transform.parent)               //Deselect all other buttons except selected
        {
            if (btn.gameObject != button.gameObject)
            {
                Animator animator = btn.gameObject.GetComponent<Animator>();
                animator.SetBool(isSelectedHash, false);
            }
        }
    }
    
}   
