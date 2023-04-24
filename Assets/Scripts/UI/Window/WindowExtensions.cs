namespace BG.UI.Window
{
    /// <summary>
    /// Extensions to make interfaces easier to use <see cref="IWindow"/>
    /// </summary>
    public static class WindowExtensions
    {
        public static void RequestOpenWindow(this IWindow window)
        {
            WindowManager.RequestOpenWindow(window);
        }

        public static bool TryCloseWindow(this IWindow window)
        {
            if (window.IsCurrentOpen())
            {
                WindowManager.CloseCurrentWindow();
                return true;
            }
            return false;
        }

        public static bool IsCurrentOpen(this IWindow window)
        {
            return WindowManager.CheckCurrentWindow(window);
        }
    }
}