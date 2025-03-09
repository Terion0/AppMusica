using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMusica.PageModels.Help
{
    public partial class SettingsPageModel : ObservableObject
    {
      
        private bool isDarkMode;

      
        [ObservableProperty]
        private CultureInfo selectedLeng;


        [ObservableProperty]
        ObservableCollection<CultureInfo> idiomas;

        public bool IsDarkMode
        {
            get => isDarkMode;
            set
            {
                if (isDarkMode != value)
                {
                    isDarkMode = value;
                    changeColor();  //A mi me están estafando ¿Por qué no va con Observable property!!!!!
                }
            }
        }

        public SettingsPageModel()
        {
            IsDarkMode = Application.Current.UserAppTheme == AppTheme.Dark;
          //  CulturaActiva = Thread.CurrentThread.CurrentCulture;
            GetCulturas();
            ChangeCulture();
            
          
            
           
        }

        public void GetCulturas()
        {
            Idiomas = new();
            Idiomas.Add(new CultureInfo("es-ES"));
            Idiomas.Add(new CultureInfo("en-US"));
          
        }

        public void changeColor() {
            if (IsDarkMode)
            {
                Application.Current.UserAppTheme = AppTheme.Light;
            }
            else { Application.Current.UserAppTheme = AppTheme.Dark; }
         
        }

        private void ChangeCulture()
        {

          
            

                CultureInfo.DefaultThreadCurrentCulture = SelectedLeng;
                CultureInfo.DefaultThreadCurrentUICulture = SelectedLeng;
                Application.Current.MainPage?.InvalidateMeasure();
            
        }



    }
}
