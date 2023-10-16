using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Crd
{
    private Chrcter _chrcter;
    private VisualElement _crdRoot;

    public VisualElement Root => _crdRoot;

    private Label _nmeLbel;
    private Label _descLbel;
    private VisualElement _profileImge;

    public Crd(VisualElement crdRoot, Chrcter chrcter)
    {
        _chrcter = chrcter;
        _crdRoot = crdRoot;

        _nmeLbel = _crdRoot.Q<Label>("nme-lbel");
        _descLbel = _crdRoot.Q<Label>("info-lbel");
        _profileImge = _crdRoot.Q<VisualElement>("imge");

        _chrcter.OnChanged += UpdteInfo;
        UpdteInfo();
    }

    private void UpdteInfo()
    {
        _nmeLbel.text = _chrcter.Name;
        _descLbel.text = _chrcter.Description;
        _profileImge.style.backgroundImage = new StyleBackground(_chrcter.Sprite);
    }
}
