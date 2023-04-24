using UnityEngine;

namespace TD.UI.Window
{
    /// <summary>
    /// The gameobject that inherits from this interface will be a window
    /// </summary>
    /// <remarks>
    /// These methods should only be used by <typeparamref name="WindowManager"/> 
    /// </remarks>
    public interface IWindow
    {
        GameObject FirstGameObject { get; }
        public void OpenWindow();
        public void CloseWindow();
    }
}