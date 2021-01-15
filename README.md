# FarmApp
 
## Project description

The purpose of the application is to be a means to consult which pharmacies have a product in your proximity.<br />
With this app you can look for any medicament you need and on the map it will display you the nearest pharmacies based on your location. <br /> And based on the pharmacy you can consult: 
- Pharmacy info
- Pharmacy inventory list
- Link of the pharmacy location on google maps

To test the project you need to put your own [Google Maps API Key](https://developers.google.com/maps/documentation/android-sdk/get-api-key) (with Google Maps SDK enabled) in `Constants.cs` and `AndroidManifest.xml`.

* [Project's Mockup]()
* [Trello Board](https://trello.com/b/ryUF3os9/farmapp-development)

## Project Screenshots

## Group members

Member| ID
------| ------
**Ariel Angeles**| 1088157
**Alberto Osorio**| 1085998
**Harold Rodriguez**| 1088464


## Libraries used

Library| Version
-------| -------
**For all projects**
Acr.UserDialogs| 7.1.0.470
[Prism.Unity.Forms](https://github.com/PrismLibrary/Prism)| 8.0.0.1909
Syncfusion.Xamarin.Core| 18.4.0.34
Syncfusion.Xamarin.SfAutoComplete| 18.4.0.34
Xamarin.Essentials| 1.5.3.2
Xamarin.Essentials.Interfaces| 1.5.3.2
Xamarin.Forms| 4.8.0.1821
[Xamarin.Forms.GoogleMaps](https://github.com/amay077/Xamarin.Forms.GoogleMaps)| 3.3.0
**Shared project**|
NETStandard.Library| 2.03
Newtonsoft.Json| 12.0.3
PropertyChanged.Fody| 3.3.1
[Refit](https://github.com/reactiveui/refit)| 5.2.4
Xamarin.Forms.BehaviorsPack| 2.2.0
**Android project**|
Xamarin.Android.Support.v7.AppCompat| 28.0.0.3
Xamarin.GooglePlayServices.Maps| 71.1610.4
**IOS project**|
Xamarin.Google.iOS.Maps| 3.9.0

## APIs Used
**Google Maps API**: Used for google maps integration
- API base link: <https://maps.googleapis.com/maps/>

**FarmApp Api**: In house made API to handle project
- API base link: <https://farmappapi.azurewebsites.net/> (you can try this one adding `/api/pharmacies` for e.g.)
