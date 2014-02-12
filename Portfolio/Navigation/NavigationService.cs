using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App2.Navigation
{
    public class NavigationService
    {
        private Frame RootFrame
        {
            get { return Window.Current.Content as Frame; }
        }

        public virtual bool CanGoBack
        {
            get { return RootFrame.CanGoBack; }
        }

        public virtual bool CanGoForward
        {
            get { return RootFrame.CanGoForward; }
        }

        public virtual bool Navigate(Type destination, object parameter = null)
        {
            try
            {
                RootFrame.Navigate(destination, parameter);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual void GoBack()
        {
            if (RootFrame.CanGoBack)
            {
                RootFrame.GoBack();
            }
        }

        public virtual void GoForward()
        {
            if (RootFrame.CanGoForward)
                RootFrame.GoForward();
        }
    }
}