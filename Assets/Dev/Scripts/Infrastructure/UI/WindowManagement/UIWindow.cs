using UnityEngine;

public class UIWindow : MonoBehaviour
{
    [SerializeField] private WindowType _windowType;

    public WindowType WindowType => _windowType;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
