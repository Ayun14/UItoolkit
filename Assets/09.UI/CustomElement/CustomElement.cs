using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomElement : MonoBehaviour
{
    private UIDocument _uiDocument;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        var root = _uiDocument.rootVisualElement;

        VisualElement buttonRow = root.Q<VisualElement>(className: "button-row");

        buttonRow.RegisterCallback<ClickEvent>(evt =>
        {
            // evt.StopPropagation(); 부모로가는 전파 멈추기
            var dve = evt.target as DataVisualElement;
            if (dve != null)
            {
                Debug.Log($"{dve.buttonIndex} 번 버튼 이름 : {dve.buttonName} ");
            }
        });

        //List<VisualElement> buttons =  root.Query<VisualElement>(className: "button").ToList(); // button인 애들 다 가지고옴

        //for (int i = 0; i < buttons.Count; ++i)
        //{
        //    int idx = i;
        //    buttons[i].RegisterCallback<ClickEvent>(evt =>
        //    {
        //        Debug.Log($"{idx} 번 버튼이 클리");
        //    });
        //}
    }
}
