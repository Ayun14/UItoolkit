using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action<bool> JumpEvent;
    public event Action<Vector2> MovementEvent; // event�� �ۿ��� ������ �����ϰ� �ϴ� ��

    private Controls _controls;
    public Controls GetControl()
    {
        return _controls;
    }

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
            _controls.Player.SetCallbacks(this);
        }

        _controls.Player.Enable(); // �Է� Ȱ��ȭ
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            JumpEvent?.Invoke(true);
        else if (context.canceled)
            JumpEvent?.Invoke(false);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        MovementEvent?.Invoke(value);
    }
}
