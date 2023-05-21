using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    public Action OnClick = delegate {  };

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }
}
