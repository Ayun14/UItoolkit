using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    private float _moveSpeed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _inputReader.JumpEvent += JumpHandle;
        _inputReader.MovementEvent += MovementHandle;
    }

    private void OnDestroy()
    {
        _inputReader.JumpEvent -= JumpHandle;
        _inputReader.MovementEvent -= MovementHandle;
    }

    public void JumpHandle(bool value)
    {
        Debug.Log($"점프 핸들 {value}");
    }

    public void MovementHandle(Vector2 movement)
    {
        Debug.Log(movement);
        _rigidbody.velocity = movement * _moveSpeed;
    }
}
