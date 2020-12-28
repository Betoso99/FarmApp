using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace FarmApp.Controls
{
    class CustomMap : Xamarin.Forms.GoogleMaps.Map
    {
        public static readonly BindableProperty GetCurrentLocationCommandProperty =
          BindableProperty.Create(nameof(GetCurrentLocationCommand), typeof(ICommand), typeof(CustomMap), null, BindingMode.TwoWay);

        public ICommand GetCurrentLocationCommand
        {
            get { return (ICommand)GetValue(GetCurrentLocationCommandProperty); }
            set { SetValue(GetCurrentLocationCommandProperty, value); }
        }

        public CustomMap()
        {

        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext != null)
            {
                GetCurrentLocationCommand = new Command(async () => await GetCurrentLocation());
            }
        }

        async Task GetCurrentLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    var pin = new Xamarin.Forms.GoogleMaps.Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(location.Latitude, location.Longitude),
                        Label = "Current",
                        Address = "Location",
                        Tag = string.Empty
                    };
                    Pins.Add(pin);

                    InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(location.Latitude, location.Longitude), 15d);

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }


    }
}
