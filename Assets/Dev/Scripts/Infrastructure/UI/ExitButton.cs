using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitButton : MonoBehaviour
{
    private readonly Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(() => Application.Quit());
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(() => Application.Quit());
    }
}
