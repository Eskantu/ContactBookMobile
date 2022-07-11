using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactBookMobile.ViewModels
{
   public class UploadFileViewModel:BaseViewModel
    {
        private ObservableCollection<FileInfo> files;

        public ObservableCollection<FileInfo> Files
        {
            get { return files; }
            set {SetProperty(ref files , value); }
        }

        public ICommand PickFileCommand { get; set; }
        public UploadFileViewModel()
        {
            Files = new ObservableCollection<FileInfo>();
            PickFileCommand = new Command(async () => await OnPickFile());
        }

        private async Task OnPickFile()
        {
            var result = (await FilePicker.PickMultipleAsync()).ToList();
            result.ForEach(r =>
            {
                Files.Add(new FileInfo($"{r.FullPath}"));
            });
        }
    }
}
