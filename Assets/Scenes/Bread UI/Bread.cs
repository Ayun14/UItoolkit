using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bread : MonoBehaviour
{
    private UIDocument _uiDocument;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        var root = _uiDocument.rootVisualElement;
        var slideBox = root.Q("slide-box");

        root.Q<Label>("Label1").RegisterCallback<ClickEvent>(e => {
            slideBox.style.left = new Length(0, LengthUnit.Percent);
        });
        root.Q<Label>("Label2").RegisterCallback<ClickEvent>(e => {
            slideBox.style.left = new Length(-100, LengthUnit.Percent);
        });
        root.Q<Label>("Label3").RegisterCallback<ClickEvent>(e => {
            slideBox.style.left = new Length(-200, LengthUnit.Percent);
        });
    }
    private void OnClickBtn(ClickEvent evt)
    {
        Debug.Log("Å¬¸¯");
    }
}
