using UnityEngine;
using UnityEngine.Events;

namespace TD.UI.Window
{
    /// <summary>
    /// Generic and basic implementation
    /// </summary>
    public class SimpleWindow : MonoBehaviour, IWindow
    {
        [Header("Simple Window")]
        [SerializeField] private GameObject firstBtn;
        [Space]
        [SerializeField] private UnityEvent onOpen;
        [SerializeField] private UnityEvent onClose;

        public GameObject FirstGameObject => firstBtn;

        public virtual void OpenWindow()
        {
            gameObject.SetActive(true);
            onOpen.Invoke();
        }

        public virtual void CloseWindow()
        {
            gameObject.SetActive(false);
            onClose.Invoke();
        }

        public void OnRequestToOpen() => this.RequestOpenWindow();

        public void OnRequestToClose() => this.TryCloseWindow();

        public void OnRequestToCloseAll() => WindowManager.CloseAllWindows();
    }
}