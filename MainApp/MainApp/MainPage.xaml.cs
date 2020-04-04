using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MainApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public int Counter { get; set; }

        SensorSpeed Speed = SensorSpeed.UI;
        public MainPage()
        {
            InitializeComponent();
            Counter = 0;
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            ToggleAccelerometer();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Counter += 1;
            counterLabel.FontSize = Counter;
            counterLabel.Text = Counter.ToString();
        }

        //Inicio Modificación - FernandoAMartinez - dd/MM/yyyy
        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            acelerometerInfoX.Text = $"Reading: X: {data.Acceleration.X}";
            acelerometerInfoY.Text = $"Reading: Y: {data.Acceleration.Y}";
            acelerometerInfoZ.Text = $"Reading: Z: {data.Acceleration.Z}";
            // Process Acceleration X, Y, and Z
        }
        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(Speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TabbedPage1());
        }
        //Fin Modificación - FernandoAMartinez - dd/MM/yyyy
    }
}
