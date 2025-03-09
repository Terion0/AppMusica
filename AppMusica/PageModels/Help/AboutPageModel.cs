using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMusica.PageModels.Help
{
    public partial class AboutPageModel : ObservableObject
    {

        [RelayCommand]
        private async Task ToVideo()
        {
            var url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";   // Rickrolleado ;)

            await Launcher.OpenAsync(url);
        }


    }
}
