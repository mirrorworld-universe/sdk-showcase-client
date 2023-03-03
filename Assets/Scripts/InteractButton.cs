using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    public FollowingUI followingUI;
    public RectTransform bgTrans;
    public GameObject labelGO;

    private Action clickAction;
    // Start is called before the first frame update
    public void Init(Canvas canvas,GameObject target,float bgWidth,float textWidth,string text,Action clickAction)
    {
        followingUI.Init(canvas,target);
        bgTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, bgWidth);
        RectTransform labelTrans = labelGO.GetComponent<RectTransform>();
        labelTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, textWidth);
        TextMeshProUGUI textMesh = labelGO.GetComponent<TextMeshProUGUI>();
        textMesh.text = text;
        this.clickAction = clickAction;
    }

    public void OnButtonClicked()
    {
        HideButton();
        clickAction();
    }

    public void ShowButton()
    {

    }

    public void HideButton()
    {
        Debug.Log("Button hide play.");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
