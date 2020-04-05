using System;
using System.ComponentModel;
using Xamarin.Forms;
using Entity;
using BusinessLogic;
using System.Collections.ObjectModel;

namespace MainApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<CovidStat> itemList;

        public bool IsWorking { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private async void RefreshServiceCall(string country)
        {
            if (!IsWorking)
            {
                StartService();
                Statistics statistics = await StatisticsService.Instance.GetUpdatedCasesAsync(country);
                if(statistics != null)
                {
                    StopService();
                    itemList = new ObservableCollection<CovidStat>();
                    if(statistics.Data != null)
                        foreach (CovidStat data in statistics.Data.CovidStats)
                            itemList.Add(data);

                    listViewCases.ItemsSource = itemList;
            }
            else StopService();
            }
        }

        private void StartService()
        {
            IsWorking = true;
            serviceIndicator.IsEnabled = true;
            serviceIndicator.IsVisible = true;
            serviceIndicator.IsRunning = true;
        }
        private void StopService()
        {
            IsWorking = false;
            serviceIndicator.IsEnabled = false;
            serviceIndicator.IsVisible = false;
            serviceIndicator.IsRunning = false;
        }

        private void OnCountrySearchPressed(object sender, EventArgs e) =>
            RefreshServiceCall(countrySearchBar.Text);
    }
}
