using FarmApp.Models;
using System;
using System.Collections;
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

        public static readonly BindableProperty CurrentLocationProperty =
          BindableProperty.Create(
             propertyName: nameof(CurrentLocation),
             returnType: typeof(Location),
             declaringType: typeof(CustomMap),
             defaultValue: null,
             defaultBindingMode: BindingMode.TwoWay,
             propertyChanged: CurrentLocationPropertyChanged);

        public static readonly BindableProperty PinsSourceProperty =
            BindableProperty.Create(nameof(PinsSource), typeof(IEnumerable), typeof(CustomMap), null,
                                     BindingMode.TwoWay, null, PinsSourcePropertyChanged);

        public Location CurrentLocation
        {
            get { return (Location)GetValue(CurrentLocationProperty); }
            set { SetValue(CurrentLocationProperty, value); }
        }
        public IEnumerable PinsSource
        {
            get { return (IEnumerable)GetValue(PinsSourceProperty); }
            set { SetValue(PinsSourceProperty, value); }
        }


        public CustomMap()
        {

        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            //if (BindingContext != null)
            //{
            //    GetCurrentLocationCommand = new Command(async () => await GetCurrentLocation());
            //}
        }

        private static void CurrentLocationPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Location location = newValue as Location;
            CustomMap targetControl = (CustomMap)bindable;
            targetControl.Pins.Clear();

            var pin = new Xamarin.Forms.GoogleMaps.Pin
            {
                Type = PinType.Place,
                Position = new Position(location.Latitude, location.Longitude),
                Label = "Current",
                Address = "Location",
                Tag = string.Empty
            };

            targetControl.Pins.Add(pin);
            targetControl.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Xamarin.Forms.GoogleMaps.Distance.FromMiles(0.3)));

        }

        private static void PinsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IEnumerable<Pin> pins = newValue as IEnumerable<Pin>;
            CustomMap targetControl = (CustomMap)bindable;
            Pin CurrentLocationPin = targetControl.Pins[0];

            targetControl.Pins.Clear();

            targetControl.Pins.Add(CurrentLocationPin);
            foreach (Pin p in pins)
            {
                targetControl.Pins.Add(p);
            }
        }
    }
}
