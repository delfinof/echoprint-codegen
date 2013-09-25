using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace test.codege.w81
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        codegent_w81.Class1 c = null;

        public MainPage()
        {
            this.InitializeComponent();
            Load();
        }

        public async void Load()
        {
            var openPicker = new FileOpenPicker();
            openPicker.FileTypeFilter.Add(".pcm");
            StorageFile file = await openPicker.PickSingleFileAsync();
            var bytes = await ReadFile(file);

            c = new codegent_w81.Class1(bytes, 0);
            var s = c.getCodeString();
            System.Diagnostics.Debug.WriteLine(s);
            int i = s.Length;
            i = i + 1;
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
    }
}
