using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Self_Button : Button
{

    public Action OnSelectCallback;

    public override void OnSelect(BaseEventData evenData)
    {
        base.OnSelect(evenData);
        if (OnSelectCallback != null)
            OnSelectCallback();
    }


    public Action OnPointClickCallback;
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        if (OnPointClickCallback != null)
            OnPointClickCallback();
    }

    protected override void Awake()
    {
        base.Awake();
        //OnSelectCallback += onSelectEvent;
        OnPointClickCallback += onSelectEvent;
    }

    private void onSelectEvent()
    {
        AddClickSound.Instance.ButtonAddSound();
    }
}
