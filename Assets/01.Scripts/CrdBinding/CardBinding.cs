using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System.Threading.Tasks;
using System;

public class CardBinding : MonoBehaviour
{
    private UIDocument _uIDocument;
    private VisualElement _contentBox;

    private TextField _txtName;
    private TextField _txtDesc;

    public List<CharacterSO> _charList;


    private List<Card> _cardList = new List<Card>();
    private Character _currentCharacter = null;
    [SerializeField] private Sprite _defalteSprite;
    [SerializeField] private VisualTreeAsset _cardTemplte;
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

        _txtName = root.Q<TextField>("txt-nme");
        _txtDesc = root.Q<TextField>("txt-desc");

        _txtName.RegisterCallback<ChangeEvent<string>>(OnNmeChnged);
        _txtDesc.RegisterCallback<ChangeEvent<string>>(OnDescChnged);
    }

    private async void ShowCrdClick(ClickEvent evt) // 숙제 so안에 있는 카드들 시간차로 내려오기
    {
        foreach (var item in _charList)
        {
            var templte = _cardTemplte.Instantiate().Q<VisualElement>("crd-border");

            Character character = new Character(item.charname, item.description, item.sprite);
            Card card = new Card(templte, character);

            _cardList.Add(card);

            templte.RegisterCallback<ClickEvent>(e =>
            {
                _currentCharacter = character;

                _txtName.SetValueWithoutNotify(character.Name);
                _txtDesc.SetValueWithoutNotify(character.Description);
            });
            _contentBox.Add(templte);
            await Task.Delay(300);
            templte.AddToClassList("on");
        }
    }

    private void OnNmeChnged(ChangeEvent<string> evt)
    {
        if (_currentCharacter == null) return;
        _currentCharacter.Name = evt.newValue;
    }

    private void OnDescChnged(ChangeEvent<string> evt)
    {
        if (_currentCharacter == null) return;
        _currentCharacter.Description = evt.newValue;
    }

    private async void HndLeddCrdClick(ClickEvent evt)
    {
        var templte = _cardTemplte.Instantiate().Q<VisualElement>("crd-border");

        string nme = _txtName.value;
        string desc = _txtDesc.value;

        Character chrcter = new Character(nme, desc, _defalteSprite);
        Card crd = new Card(templte, chrcter);

        _cardList.Add(crd);

        templte.RegisterCallback<ClickEvent>(e =>
        {
            _currentCharacter = chrcter;

            _txtName.SetValueWithoutNotify(chrcter.Name);
            _txtDesc.SetValueWithoutNotify(chrcter.Description);
        });
        _contentBox.Add(templte);
        await Task.Delay(100);
        templte.AddToClassList("on");
    }
}
