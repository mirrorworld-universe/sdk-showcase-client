using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFactory
{
    public static GameObject GenerateInteractButton(GameObject followTarget,float bgWidth,float textWidth,string text,Action action)
    {
        GameObject model = Resources.Load<GameObject>("Prefabs/InteractButton");
        GameObject buttonGO = GameObject.Instantiate(model);
        InteractButton interactButton = buttonGO.GetComponent<InteractButton>();

        GameObject canvasGO = GameObject.Find("Canvas");
        Canvas canvas = canvasGO.GetComponent<Canvas>();
        interactButton.Init(canvas, followTarget,bgWidth,textWidth,text,action);

        buttonGO.transform.SetParent(canvasGO.transform);
        return buttonGO;
    }
}
