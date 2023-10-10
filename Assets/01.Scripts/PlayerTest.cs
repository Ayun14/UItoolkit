using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private void Update()
    {
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            var control = _inputReader.GetControl();
            control.Player.Disable(); // Ű���� �ϴ°�
            // Ű ����ÿ��� �ݵ�� �ش� ��ǲ���� disable

            Debug.Log("������ ���ϴ� Ű�� �Է��ϼ���");
            control.Player.Jump.PerformInteractiveRebinding()
                .WithControlsExcluding("Mouse")
                .WithCancelingThrough("<keyboard>/escape") // ESCŰ�� ���
                .OnComplete(op =>
                {
                    Debug.Log("����Ǿ����ϴ�.");
                    control.Player.Enable();
                })
                .OnCancel(op =>
                {
                    Debug.Log("��ҵǾ����ϴ�");
                    op.Dispose();
                    control.Player.Enable();
                }).Start();
        }

        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            var json = _inputReader.GetControl().SaveBindingOverridesAsJson(); // string������ ����
            Debug.Log(json);

            _inputReader.GetControl().LoadBindingOverridesFromJson(json);
        }
    }
}
