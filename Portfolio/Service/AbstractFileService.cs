using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Newtonsoft.Json;

namespace Portfolio.Service
{
    public abstract class AbstractFileService<T>
    {
        private readonly StorageFolder _folder = ApplicationData.Current.LocalFolder;
        protected abstract string GetFileName();

        protected abstract ObservableCollection<T> GetItems();

        protected async Task<ObservableCollection<T>> OpenOrCreateFileAndGetContents()
        {
            var file = await OpenFileAsync();
            var fileContents = string.Empty;
            if (file != null)
            {
                fileContents = await FileIO.ReadTextAsync(file);
            }
            IList<T> parsedContents =
                JsonConvert.DeserializeObject<List<T>>(fileContents)
                ?? new List<T>();
            return new ObservableCollection<T>(parsedContents);
        }

        private IAsyncOperation<StorageFile> OpenFileAsync()
        {
            return _folder.CreateFileAsync(GetFileName(), CreationCollisionOption.OpenIfExists);
        }

        protected Task WriteToFile()
        {
            return Task.Run(async () =>
            {
                var json = JsonConvert.SerializeObject(GetItems());
                var file = await OpenFileAsync();
                await FileIO.WriteTextAsync(file, json);
            });
        }
    }
}