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
            // evt.StopPropagation(); �θ�ΰ��� ���� ���߱�
            var dve = evt.target as DataVisualElement;
            if (dve != null)
            {
                Debug.Log($"{dve.buttonIndex} �� ��ư �̸� : {dve.buttonName} ");
            }
        });

        //List<VisualElement> buttons =  root.Query<VisualElement>(className: "button").ToList(); // button�� �ֵ� �� �������

        //for (int i = 0; i < buttons.Count; ++i)
        //{
        //    int idx = i;
        //    buttons[i].RegisterCallback<ClickEvent>(evt =>
        //    {
        //        Debug.Log($"{idx} �� ��ư�� Ŭ��");
        //    });
        //}
    }
}
