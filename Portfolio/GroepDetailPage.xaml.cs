﻿// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
using System;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Ioc;
using Portfolio.Common;
using Portfolio.Model;
using Portfolio.ViewModel;

namespace Portfolio
{
    /// <summary>
    ///     A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class GroepDetailPage : Page
    {
        private readonly NavigationHelper _navigationHelper;

        public GroepDetailPage()
        {
            InitializeComponent();
            _navigationHelper = new NavigationHelper(this);
            _navigationHelper.LoadState += navigationHelper_LoadState;
            _navigationHelper.SaveState += navigationHelper_SaveState;
        }


        /// <summary>
        ///     NavigationHelper is used on each page to aid in navigation and
        ///     process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }


        /// <summary>
        ///     Populates the page with content passed during navigation. Any saved state is also
        ///     provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        ///     The source of the event; typically <see cref="NavigationHelper" />
        /// </param>
        /// <param name="e">
        ///     Event data that provides both the navigation parameter passed to
        ///     <see cref="Frame.Navigate(Type, Object)" /> when this page was initially requested and
        ///     a dictionary of state preserved by this page during an earlier
        ///     session. The state will be null the first time a page is visited.
        /// </param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        ///     Preserves state associated with this page in case the application is suspended or the
        ///     page is discarded from the navigation cache.  Values must conform to the serialization
        ///     requirements of <see cref="SuspensionManager.SessionState" />.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper" /></param>
        /// <param name="e">
        ///     Event data that provides an empty dictionary to be populated with
        ///     serializable state.
        /// </param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        private async void NewLeiderImage_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var openPicker = new FileOpenPicker
            {
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                ViewMode = PickerViewMode.Thumbnail
            };

            // Filter to include a sample subset of file types.
            openPicker.FileTypeFilter.Clear();
            openPicker.FileTypeFilter.Add(".bmp");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".jpg");

            // Open the file picker.
            var file = await openPicker.PickSingleFileAsync();

            // file is null if user cancels the file picker.
            if (file == null) return;

            var copied =
                await
                    file.CopyAsync(ApplicationData.Current.LocalFolder, file.Name,
                        NameCollisionOption.GenerateUniqueName);
            SimpleIoc.Default.GetInstance<GroepDetailViewModel>().NewLeiderImageSelected(copied.Path);

            var fileStream = await copied.OpenAsync(FileAccessMode.Read);
            var bitmapImage = new BitmapImage();
            bitmapImage.SetSource(fileStream);
            NewLeiderImage.Source = bitmapImage;
        }

        private void LeiderToevoegen_Click(object sender, RoutedEventArgs e)
        {
            LeiderToevoegenDialog.IsOpen = true;
        }

        private void LeiderToevoegenDialog_OnBackButtonClicked(object sender, RoutedEventArgs e)
        {
            if (BottomAppBar != null) BottomAppBar.IsOpen = false;
            LeiderToevoegenDialog.IsOpen = false;
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the
        /// <see cref="GridCS.Common.NavigationHelper.LoadState" />
        /// and
        /// <see cref="GridCS.Common.NavigationHelper.SaveState" />
        /// .
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void Leiders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LeiderVerwijderenAppBarButton.IsEnabled = (sender as ListView).SelectedItems.Count > 0;
        }

        private void ProgrammaToevoegenDialog_OnBackButtonClicked(object sender, RoutedEventArgs e)
        {
            if (BottomAppBar != null) BottomAppBar.IsOpen = false;
            ProgrammaToevoegenDialog.IsOpen = false;
        }

        private void ProgrammaToevoegen_Click(object sender, RoutedEventArgs e)
        {
            ProgrammaToevoegenDialog.IsOpen = true;
        }

        private void Programmas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProgrammaVerwijderenAppBarButton.IsEnabled = (sender as ListView).SelectedItems.Count > 0;
        }
    }
}