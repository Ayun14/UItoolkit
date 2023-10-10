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
            control.Player.Disable(); // 키변경 하는거
            // 키 변경시에는 반드시 해당 인풋맵을 disable

            Debug.Log("변경을 원하는 키를 입력하세요");
            control.Player.Jump.PerformInteractiveRebinding()
                .WithControlsExcluding("Mouse")
                .WithCancelingThrough("<keyboard>/escape") // ESC키로 취소
                .OnComplete(op =>
                {
                    Debug.Log("변경되었습니다.");
                    control.Player.Enable();
                })
                .OnCancel(op =>
                {
                    Debug.Log("취소되었습니다");
                    op.Dispose();
                    control.Player.Enable();
                }).Start();
        }

        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            var json = _inputReader.GetControl().SaveBindingOverridesAsJson(); // string형으로 뱉음
            Debug.Log(json);

            _inputReader.GetControl().LoadBindingOverridesFromJson(json);
        }
    }
}
