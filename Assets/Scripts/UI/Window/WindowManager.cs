using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TD.UI.Window
{
    /// <summary>
    /// Controls which Window are open
    /// </summary>
    public static class WindowManager
    {
        public static bool HasWindowOpen => CurrentWindow != null;

        public static event Action OnOpenFirstWindow;
        public static event Action OnCloseLastWindow;

        private static IWindow CurrentWindow;
        private static readonly Stack<SaveWindow> WindowsHistory = new Stack<SaveWindow>(); // Clear after changing room?

        public static void RequestOpenWindow(IWindow window)
        {
            UniTask.Create(OpenWIndow);

            async UniTask OpenWIndow()
            {
                if (HasWindowOpen)
                {
                    SaveWindow save = new SaveWindow(CurrentWindow);
                    WindowsHistory.Push(save);
                    CurrentWindow.CloseWindow();
                }
                else
                {
                    OnOpenFirstWindow?.Invoke();
                }

                EventSystem.current.SetSelectedGameObject(null);

                CurrentWindow = window;
                CurrentWindow.OpenWindow();

                await UniTask.Delay((int)(Time.unscaledDeltaTime * 1000f), true); // Prevents Event system bugs

                if (CurrentWindow.FirstGameObject)
                {
                    EventSystem.current.SetSelectedGameObject(CurrentWindow.FirstGameObject);
                }
            }
        }

        public static void CloseCurrentWindow()
        {
            CurrentWindow.CloseWindow();

            if (WindowsHistory.TryPop(out SaveWindow last))
            {
                last.ReturnToWindow();
                CurrentWindow = last.Window;
            }
            else
            {
                OnCloseLastWindow?.Invoke();
                CurrentWindow = null;
            }
        }

        /// <summary> Close current window and clean the history </summary>
        /// <remarks> Recommended when switching scenes </remarks>
        public static void CloseAllWindows()
        {
            WindowsHistory.Clear();
            CurrentWindow?.CloseWindow();
            CurrentWindow = null;
        }

        public static bool CheckCurrentWindow(IWindow window)
        {
            return CurrentWindow == window;
        }

        private class SaveWindow
        {
            public IWindow Window { get; }
            public GameObject LastGameObject { get; }

            public SaveWindow(IWindow currentWindow)
            {
                Window = currentWindow;
                LastGameObject = EventSystem.current.currentSelectedGameObject;
            }

            public void ReturnToWindow()
            {
                Window.OpenWindow();

                if (LastGameObject) // Auto select
                    EventSystem.current.SetSelectedGameObject(LastGameObject);
            }
        }
    }
}