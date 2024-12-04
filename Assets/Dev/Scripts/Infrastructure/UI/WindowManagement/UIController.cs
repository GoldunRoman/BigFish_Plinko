using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour, IUIController
{
    private readonly Dictionary<WindowType, UIWindow> _windows = new();

    public void Initialize()
    {
        UIWindow[] uiWindows = FindObjectsOfType<UIWindow>(true);

        foreach (var window in uiWindows)
        {
            _windows[window.WindowType] = window;
        }

        HideAll();
    }

    public void ShowWindow(WindowType windowType)
    {
        foreach (var window in _windows.Values)
        {
            window.Hide();
        }

        if (_windows.TryGetValue(windowType, out var windowToShow))
        {
            windowToShow.Show();
        }
        else
        {
            Debug.LogError($"Window of type {windowType} not found!");
        }
    }

    private void HideAll()
    {
        foreach (var window in _windows.Values)
        {
            window.Hide();
        }
    }
}
