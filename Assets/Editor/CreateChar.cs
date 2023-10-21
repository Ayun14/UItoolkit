using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateChar : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    private TextField _txtName;
    private TextField _txtDesc;
    private ObjectField _objectSprite;

    [MenuItem("GGM/CreteChr")]
    public static void ShowWindow()
    {
        CreateChar wnd = GetWindow<CreateChar>();
        wnd.titleContent = new GUIContent("캐릭터 SO 생성기");
    }

    [OnOpenAsset]
    public static bool OnOpenAsset(int instnceID, int line)
    {
        if (Selection.activeObject is CharacterSO)
        {
            ShowWindow();
            return true;
        }
        return false;
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        VisualElement continer = m_VisualTreeAsset.Instantiate();
        continer.style.flexGrow = 1;
        root.Add(continer);

        _txtName = continer.Q<TextField>("txt-nme");
        _txtDesc = continer.Q<TextField>("txt-desc");
        _objectSprite = continer.Q<ObjectField>("object-sprite");

        continer.Q<Button>("btn-crete").RegisterCallback<ClickEvent>(CreteSO);

        OnSelectionChnge();
    }

    private void CreteSO(ClickEvent evt)
    {
        string chrnme = _txtName.value;
        string filenme = $"Assets/08.SO/ChcterSO/{chrnme}.asset";
        CharacterSO sset = AssetDatabase.LoadAssetAtPath<CharacterSO>(filenme);

        if (sset != null)
        {
            sset.charname = _txtName.value;
            sset.description = _txtDesc.value;
            sset.sprite = _objectSprite.value as Sprite;

            EditorUtility.SetDirty(sset);
            AssetDatabase.SaveAssets();
        }
        else
        {
            sset = ScriptableObject.CreateInstance<CharacterSO>();

            sset.charname = _txtName.value;
            sset.description = _txtDesc.value;
            sset.sprite = _objectSprite.value as Sprite;

            string filename = AssetDatabase.GenerateUniqueAssetPath($"Assets/08.SO/ChcterSO/{sset.charname}.asset");
            AssetDatabase.CreateAsset(sset, filename);
        }
        AssetDatabase.Refresh(); // 에디터 리프레시
    }

    private void OnSelectionChnge()
    {
        var so = Selection.activeObject as CharacterSO;
        if (so != null)
        {
            _txtName.value = so.charname;
            _txtDesc.value = so.description;
            _objectSprite.value = so.sprite;
        }
    }
}
