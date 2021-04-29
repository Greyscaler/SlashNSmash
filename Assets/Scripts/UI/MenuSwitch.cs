using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSwitch : MonoBehaviour
{
    public GameObject nextMenu;
    public bool DeselectAll;
    public void MenuToggle()
    {

        Debug.Log("Clicked");
        if (DeselectAll)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
        foreach (Transform menu in nextMenu.transform.parent)
        {
            if (menu.gameObject != nextMenu.gameObject)
            {
                menu.gameObject.SetActive(false);
            }
        }
        nextMenu.SetActive(true);
    }
}
