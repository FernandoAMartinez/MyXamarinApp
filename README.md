# MyXamarinApp

The following App developed in Xamarin with Xamarin.Forms retrieve de current cases for a requested Country.
It consumes the following API published in RapidAPI (Requires Register).

KishCom's COVID-19 API: https://rapidapi.com/KishCom/api/covid-19-coronavirus-statistics

Inside you'll find three projects:
- ## Entity Project
  - It contains all the objects that will be mapped by the `JsonSerializer` based on the response of the API.

- ## Business Logic Project
  - It contains the API consumer `StatisticsService` and the interface `ICustomSerializable` that will be inherited by the `JsonSerializer`.
  
  - In `StatisticsService` you'll find two constants that refer to the Host and Key provided by RapidAPI. 
  ```C#
  private const string HostHeader = "Your-Host-HeaderInfo";
  private const string KeyHeader = "Your-Key-HeaderInfo";
  ```
  
- ## MainApp & MainApp.Android
  - It contains the design and implementation of `Xamarin.Forms` for rhe App.
  - It starts with the `MainPage` XAML form.
  
### Thanks to:
- KishCom for the COVID-19's API
- Team of RapidAPI for the platform to test the APIs
