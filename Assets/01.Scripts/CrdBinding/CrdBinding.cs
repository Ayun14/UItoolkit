using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System.Threading.Tasks;
using System;

public class CrdBinding : MonoBehaviour
{
    private UIDocument _uIDocument;
    private VisualElement _contentBox;

    private TextField _txtNme;
    private TextField _txtDesc;

    public List<ChrcterSO> _chrList;


    private List<Crd> _crdList = new List<Crd>();
    private Chrcter _currentChrcter = null;
    [SerializeField] private Sprite _deflteSprite;
    [SerializeField] private VisualTreeAsset _crdTemplte;
    private void Awake()
    {
        _uIDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        var root = _uIDocument.rootVisualElement;

        _contentBox = root.Q<VisualElement>("content");
        root.Q<Button>("btn-dd-crd").RegisterCallback<ClickEvent>(HndLeddCrdClick);
        root.Q<Button>("btn-show-ll").RegisterCallback<ClickEvent>(ShowCrdClick);

        _txtNme = root.Q<TextField>("txt-nme");
        _txtDesc = root.Q<TextField>("txt-desc");

        _txtNme.RegisterCallback<ChangeEvent<string>>(OnNmeChnged);
        _txtDesc.RegisterCallback<ChangeEvent<string>>(OnDescChnged);
    }

    private async void ShowCrdClick(ClickEvent evt) // 숙제 so안에 있는 카드들 시간차로 내려오기
    {
        var templte = _crdTemplte.Instantiate().Q<VisualElement>("crd-border");

        foreach (var item in _chrList)
        {
            _contentBox.Add(templte);
            await Task.Delay(100);
            templte.AddToClassList("on");
        }

        templte.RegisterCallback<ClickEvent>(e =>
        {

        });
    }

    private void OnNmeChnged(ChangeEvent<string> evt)
    {
        if (_currentChrcter == null) return;
        _currentChrcter.Name = evt.newValue;
    }

    private void OnDescChnged(ChangeEvent<string> evt)
    {
        if (_currentChrcter == null) return;
        _currentChrcter.Description = evt.newValue;
    }

    private async void HndLeddCrdClick(ClickEvent evt)
    {
        var templte = _crdTemplte.Instantiate().Q<VisualElement>("crd-border");

        string nme = _txtNme.value;
        string desc = _txtDesc.value;

        Chrcter chrcter = new Chrcter(nme, desc, _deflteSprite);
        Crd crd = new Crd(templte, chrcter);

        _crdList.Add(crd);

        templte.RegisterCallback<ClickEvent>(e =>
        {
            _currentChrcter = chrcter;

            _txtNme.SetValueWithoutNotify(chrcter.Name);
            _txtDesc.SetValueWithoutNotify(chrcter.Description);
        });
        _contentBox.Add(templte);
        await Task.Delay(100);
        templte.AddToClassList("on");
    }
}
