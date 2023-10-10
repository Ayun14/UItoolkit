using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainScreen : MonoBehaviour
{
    private UIDocument _uiDocument;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();

        var root = _uiDocument.rootVisualElement;
        var slideBox = root.Q("slide-box");

        root.Q<Label>("home-label").RegisterCallback<ClickEvent>(e => {
            Debug.Log("label1");
            slideBox.style.left = new Length(0, LengthUnit.Percent);
        });
        root.Q<Label>("inven-label").RegisterCallback<ClickEvent>(e => {
            Debug.Log("label2");
            slideBox.style.left = new Length(-100, LengthUnit.Percent);
        });
        root.Q<Label>("equip-label").RegisterCallback<ClickEvent>(e => {
            Debug.Log("label3");
            slideBox.style.left = new Length(-200, LengthUnit.Percent);
        });
        root.Q<Label>("friend-label").RegisterCallback<ClickEvent>(e => {
            Debug.Log("label4");
            slideBox.style.left = new Length(-300, LengthUnit.Percent);
        });
    }

    private void OnClickBtn(ClickEvent evt)
    {
        Debug.Log("Å¬¸¯");
    }
}
