using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelected : MonoBehaviour
{
    UnityEvent initialize;
    public bool Click;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
       // initialize = new UnityEvent();
    }

    private void Start()
    {
        if (this.gameObject.activeInHierarchy)
        {
            SelectButton();   
        }
        else
        {
            //initialize.AddListener(SelectButton);
        }
    }
    private void Update()
    {
        //initialize.Invoke();
        SelectButton();
    }
    void SelectButton()
    {
        if (EventSystem.current != null && this.gameObject != null)
        {
           EventSystem.current.SetSelectedGameObject(this.gameObject);
            if (Click)
            {
               // button.;
            }
        }
    }
    

}
