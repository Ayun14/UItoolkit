using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DataVisualElement : VisualElement
{
    public string buttonName { get; set; } // ī�� ���̽�
    public int buttonIndex { get; set; }
    public float um { get; set; }

    public new class UxmlFactory : UxmlFactory<DataVisualElement, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlStringAttributeDescription m_buttonName = new UxmlStringAttributeDescription
        {
            name = "button-name", // ������ũ ���̽�
            defaultValue = ""
        };

        UxmlIntAttributeDescription m_buttonIndex = new UxmlIntAttributeDescription
        {
            name = "button-index",
            defaultValue = 0
        };

        UxmlAttributeDescription m_um = new UxmlFloatAttributeDescription
        {
            name = "um",
            defaultValue = 0.1f
        }; // ��ü �ʱ�ȭ �������ϰ� �ʱ�ȭ �� �� ����

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);

            var dve = ve as DataVisualElement;

            dve.buttonName = m_buttonName.GetValueFromBag(bag, cc);
            dve.buttonIndex = m_buttonIndex.GetValueFromBag(bag, cc);
            //dve.um = m_um.GetValueFromBag(bag, cc);
        }
    }
}
