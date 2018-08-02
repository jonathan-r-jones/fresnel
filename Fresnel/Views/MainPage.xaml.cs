using Fresnel.MenuItems;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Fresnel.Views
{

    public partial class MainPage : MasterDetailPage
    {

        public List<MasterPageItem> MenuList { get; set; }

        public MainPage()
        {
            InitializeComponent();
            MenuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Home - CSS System Status", Icon = "itemIcon1.png", TargetType = typeof(Page1) };
            var page2 = new MasterPageItem() { Title = "Open Incidents - Hardcoded Version", Icon = "itemIcon2.png", TargetType = typeof(Page2) };
            var page3 = new MasterPageItem() { Title = "Operations", Icon = "itemIcon3.png", TargetType = typeof(Page3) };
            var page4 = new MasterPageItem() { Title = "SPDR Heat Map", Icon = "itemIcon4.png", TargetType = typeof(Page4) };
            var page5 = new MasterPageItem() { Title = "Email Statistics", Icon = "itemIcon5.png", TargetType = typeof(Page5) };
            var page6 = new MasterPageItem() { Title = "Current Foreign Travel", Icon = "itemIcon6.png", TargetType = typeof(Page6) };
            var azureDataPage = new MasterPageItem() { Title = "Custom Azure Data", Icon = "itemIcon9.png", TargetType = typeof(AzureDataPage) };
            var page8 = new MasterPageItem() { Title = "Splunk Connector", Icon = "itemIcon8.png", TargetType = typeof(Page8) };
            var booksOnlinePage = new MasterPageItem() { Title = "Test - Xamarin University Books Online", Icon = "gray_gold_diamond.png", TargetType = typeof(Page9) };
            var aboutPage = new MasterPageItem() { Title = "About", Icon = "itemIcon10.png", TargetType = typeof(AboutPage) };
            var gpsPage = new MasterPageItem() { Title = "Test - GPS", Icon = "red_top_hat_diamond.png", TargetType = typeof(TripLogPage) };
            var page7 = new MasterPageItem() { Title = "Test - Word Wrapping", Icon = "blue_pink_diamond.png", TargetType = typeof(Page7) };
            //var openIncidentsPage = new MasterPageItem() { Title = "Test - JSON Data", Icon = "bullseye.png", TargetType = typeof(OpenIncidentsPage) };
            var solarWindsPage = new MasterPageItem() { Title = "Test - SolarWinds Orion SDK", Icon = "bright_green_diamond.png", TargetType = typeof(SwPage) };
            //var airWatchPage = new MasterPageItem() { Title = "Test - AirWatch SDK", Icon = "red_orange_diamond.png", TargetType = typeof(AirWatchPage) };
            var monkeyListPage = new MasterPageItem() { Title = "Test - Images Online", Icon = "goldenrod_1_diamond.png", TargetType = typeof(MonkeyListPage) };
            var jsonPlaceholderUsersPage = new MasterPageItem() { Title = "Test - JSON Users Online", Icon = "mixed_purple_diamond.png", TargetType = typeof(JSONPlaceholderUsersPage) };
            var bikeSearchPage = new MasterPageItem() { Title = "Test - Craig's List Bike Search", Icon = "goldenrod_1_diamond.png", TargetType = typeof(BikeSearchPage) };
            //var craigsListBikesPage = new MasterPageItem() { Title = "Test - Craig's List Bikes Search", Icon = "bullseye.png", TargetType = typeof(CraigsListBikesPage) };
            //var jsonIncidentsPage = new MasterPageItem() { Title = "Test - Custom JSON Data", Icon = "tiel_diamond.png", TargetType = typeof(JSONIncidentsPage) };

            MenuList.Add(page1);
            MenuList.Add(page2);
            MenuList.Add(page3);
            MenuList.Add(page5);
            MenuList.Add(page6);
            MenuList.Add(page4);
            MenuList.Add(page8);
            MenuList.Add(azureDataPage);
            MenuList.Add(aboutPage);
            // Adding menu items to menuList (!page, !main, !menu)
            MenuList.Add(jsonPlaceholderUsersPage);
            MenuList.Add(jsonIncidentsPage);
            MenuList.Add(monkeyListPage);
            MenuList.Add(booksOnlinePage);
            MenuList.Add(gpsPage);
            //MenuList.Add(airWatchPage);
            MenuList.Add(solarWindsPage);
            MenuList.Add(page7);
            //MenuList.Add(openIncidentsPage);

            //MenuList.Add(bikeSearchPage);
            //MenuList.Add(craigsListBikesPage);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = MenuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(AboutPage)));
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
