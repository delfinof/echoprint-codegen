using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using test.codegen.wp8.Resources;
using Windows.Storage;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace test.codegen.wp8
{
    public partial class MainPage : PhoneApplicationPage
    {
        codegen_wp8.Class1 c = null;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
   
            Load();
        }

        public async void Load()
        {
            StorageFile file = await StorageFile.GetFileFromPathAsync("file-11025.pcm");
            var bytes = await ReadFile(file);

            c = new codegen_wp8.Class1(bytes, 0);
            var s = c.getCodeString();
            System.Diagnostics.Debug.WriteLine(s);
            System.Diagnostics.Debug.WriteLine(c.getNumCodes() );
        }


        public async Task<byte[]> ReadFile(StorageFile file)
        {
           byte[] fileBytes = null;
           using (IRandomAccessStreamWithContentType stream = await file.OpenReadAsync())
           {
                fileBytes = new byte[stream.Size];
                using (DataReader reader = new DataReader(stream))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    reader.ReadBytes(fileBytes);
                }
            }
            return fileBytes;
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}