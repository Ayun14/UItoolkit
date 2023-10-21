using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Card
{
    private Character _character;
    private VisualElement _cardRoot;

    public VisualElement Root => _cardRoot;

    private Label _nameLbel;
    private Label _descLabel;
    private VisualElement _profileImage;

    public Card(VisualElement crdRoot, Character chrcter)
    {
        _character = chrcter;
        _cardRoot = crdRoot;

        _nameLbel = _cardRoot.Q<Label>("nme-lbel");
        _descLabel = _cardRoot.Q<Label>("info-lbel");
        _profileImage = _cardRoot.Q<VisualElement>("imge");

        _character.OnChanged += UpdteInfo;
        UpdteInfo();
    }

    private void UpdteInfo()
    {
        _nameLbel.text = _character.Name;
        _descLabel.text = _character.Description;
        _profileImage.style.backgroundImage = new StyleBackground(_character.Sprite);
    }
}
