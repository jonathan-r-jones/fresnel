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
            var page2 = new MasterPageItem() { Title = "Total Open Incidents", Icon = "itemIcon2.png", TargetType = typeof(Page2) };
            var page3 = new MasterPageItem() { Title = "Operations", Icon = "itemIcon3.png", TargetType = typeof(Page3) };
            var page4 = new MasterPageItem() { Title = "SPDR Heat Map", Icon = "itemIcon4.png", TargetType = typeof(Page4) };
            var page5 = new MasterPageItem() { Title = "Email Statistics", Icon = "itemIcon5.png", TargetType = typeof(Page5) };
            var page6 = new MasterPageItem() { Title = "Current Foreign Travel", Icon = "itemIcon6.png", TargetType = typeof(Page6) };
            var openIncidentsPage = new MasterPageItem() { Title = "Azure Data", Icon = "itemIcon7.png", TargetType = typeof(OpenIncidentsPage) };
            var page8 = new MasterPageItem() { Title = "Splunk Connector", Icon = "itemIcon8.png", TargetType = typeof(Page8) };
            var page9 = new MasterPageItem() { Title = "AirWatch Connector", Icon = "itemIcon9.png", TargetType = typeof(Page9) };
            var page10 = new MasterPageItem() { Title = "About", Icon = "itemIcon10.png", TargetType = typeof(Page10) };
            var tripLogPage = new MasterPageItem() { Title = "Test - GPS", Icon = "", TargetType = typeof(TripLogPage) };
            var page7 = new MasterPageItem() { Title = "Test - Hardcoded Collection Data", Icon = "", TargetType = typeof(Page7) };


            // Adding menu items to menuList
            MenuList.Add(page1);
            MenuList.Add(page2);
            MenuList.Add(page3);
            MenuList.Add(page4);
            MenuList.Add(page5);
            MenuList.Add(page6);
            MenuList.Add(openIncidentsPage);
            MenuList.Add(page8);
            MenuList.Add(page9);
            MenuList.Add(page10);
            MenuList.Add(tripLogPage);
            MenuList.Add(page7);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = MenuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Page10)));
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
