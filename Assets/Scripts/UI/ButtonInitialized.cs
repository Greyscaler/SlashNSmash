using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class ButtonInitialized : MonoBehaviour

{
    public UnityEvent onStart;
    private void Awake()
    {
        if (onStart == null)
        {
            onStart = new UnityEvent();
        }
    }
    void OnEnable()
    {
        onStart.Invoke();
    }
    

}
