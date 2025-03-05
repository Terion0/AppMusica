using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMusica.PageModels
{
    public partial class AboutPageModel : ObservableObject
    {

        [RelayCommand]
        private async Task ToVideo()
        {
            var url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"; // Cambia este enlace con el enlace correcto del video
                                                                     // Esto lo ha hecho chat, el poder de la IA
            await Launcher.OpenAsync(url);
        }


    }
}
