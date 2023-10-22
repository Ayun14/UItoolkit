using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Dragger : MouseManipulator
{
    private bool _isDragging = false;
    private Vector2 _startPos;
    private Action<Vector2, Vector2> DropCallBback;
    private Vector2 _origin;

    public Dragger(Action<Vector2, Vector2> DropCallback = null)
    {
        _isDragging = false;
        activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
        this.DropCallBback = DropCallback;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseDownEvent>(OnMouseDown);
        target.RegisterCallback<MouseMoveEvent>(OnMouseMove);
        target.RegisterCallback<MouseUpEvent>(OnMouseUp);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<MouseDownEvent>(OnMouseDown);
        target.UnregisterCallback<MouseMoveEvent>(OnMouseMove);
        target.UnregisterCallback<MouseUpEvent>(OnMouseUp);
    }


    protected void OnMouseDown(MouseDownEvent evt)
    {
        if (CanStartManipulation(evt))
        {
            _isDragging = true;
            _origin = new Vector2(target.layout.x, target.layout.y); // 절대적 위치
            _startPos = evt.localMousePosition; // 현재 좌표시스템에서의 마우스 좌표를 반환
            evt.StopPropagation(); // 전파 멈춰서 마우스 클릭 이벤트가 발생하지 않게

            target.CaptureMouse(); // 해당 타겟이 마우스를 잡고 안놔주는거
        }
    }

    protected void OnMouseMove(MouseMoveEvent evt)
    {
        if (_isDragging && target.HasMouseCapture())
        {
            Vector2 diff = evt.localMousePosition - _startPos; // 움직인 값을 알아냄

            target.style.top = new Length(target.layout.y + diff.y, LengthUnit.Pixel);
            target.style.left = new Length(target.layout.x + diff.x, LengthUnit.Pixel);
        }
    }

    protected void OnMouseUp(MouseUpEvent evt)
    {
        if (!_isDragging || !target.HasMouseCapture()) return;

        _isDragging = false;
        target.ReleaseMouse();

        DropCallBback?.Invoke(_origin, evt.mousePosition);
    }
}
