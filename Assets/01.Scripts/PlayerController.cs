using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        Controls control = new Controls();
        control.Player.Enable();
        control.Player.Jump.performed += JumpPerformed;
    }

    private void JumpPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("점프");
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed) // 한 번만 점프 실행
        {
            _rigidbody.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }
    }
}
