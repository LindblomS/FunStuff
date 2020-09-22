using System;
using System.Windows;

namespace Restaurant.Models
{
    public static class WindowManager
    {
        public static void CloseWindow(Guid id)
        {
            foreach (Window window in Application.Current.Windows)
            {
                var context = window.DataContext as IRequireViewIdentification;
                if (context?.ViewId == id)
                {
                    window.Close();
                }
            }
        }
    }
}
