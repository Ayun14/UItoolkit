using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DragAndDrop : MonoBehaviour
{
    private UIDocument _uiDocument;

    private bool _isDragging = false;
    private Vector2 _drageStartPos;
    private VisualElement _potion;
    private Label _nameLabel;
    [SerializeField] private Transform _followTarget;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        var root = _uiDocument.rootVisualElement;
        _potion = root.Q<VisualElement>("potion");

        _potion.AddManipulator(new Dragger(PotionDrop));

        _nameLabel = root.Q<Label>("name-label");
    }

    private void LateUpdate()
    {
        Vector3 UIPos = RuntimePanelUtils.CameraTransformWorldToPanel(
            _uiDocument.rootVisualElement.panel,
            _followTarget.position, Camera.main); // panel ¡¬«•∑Œ ∫Ø»Ø«ÿ¡‹

        float half = _nameLabel.layout.width * 0.5f;

        _nameLabel.style.left = UIPos.x - half;
        _nameLabel.style.top = UIPos.y + 100;
    }

    private void PotionDrop(Vector2 origin, Vector2 endPos)
    {
        Vector2 endScreenPos = new Vector2(endPos.x, Screen.height - endPos.y);

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(endScreenPos);
        //OverlapCircle

        //Collider2D[] cols = new Collider2D[1];
        //Physics2D.OverlapCircleNonAlloc(worldPos, 1.2f, cols); »¸ø° «“¥Á æ»µ«∞Ì «— π¯∏∏ æ≤¿”

        int playerLayer = LayerMask.NameToLayer("Player");
        Collider2D col = Physics2D.OverlapCircle(worldPos, 1.2f, 1 << playerLayer);

        if (col != null)
        {
            if (col.TryGetComponent<Health>(out Health hp))
            {
                _potion.RemoveFromHierarchy(); // ∫Ò¡ÍæÛ ø§∑π∏‡∆Æ∏¶ ªË¡¶
                hp.IncreaseHealth(20);
            }
        }
        else
        {
            _potion.style.left = origin.x;
            _potion.style.top = origin.y;
        }
    }
}
