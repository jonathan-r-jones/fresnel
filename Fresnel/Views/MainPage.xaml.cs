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
            var page1 = new MasterPageItem() { Title = "Home", Icon = "itemIcon1.png", TargetType = typeof(Page1) };
            var page2 = new MasterPageItem() { Title = "Open Incidents", Icon = "itemIcon2.png", TargetType = typeof(Page2) };
            var page3 = new MasterPageItem() { Title = "Operations", Icon = "itemIcon3.png", TargetType = typeof(Page3) };
            var page4 = new MasterPageItem() { Title = "SPDR Heat Map", Icon = "itemIcon4.png", TargetType = typeof(Page4) };
            var page5 = new MasterPageItem() { Title = "Email Statistics", Icon = "itemIcon5.png", TargetType = typeof(Page5) };
            var page6 = new MasterPageItem() { Title = "Current Foreign Travel", Icon = "itemIcon6.png", TargetType = typeof(Page6) };
            var azureDataPage = new MasterPageItem() { Title = "Azure Data", Icon = "itemIcon7.png", TargetType = typeof(AzureDataPage) };
            var page8 = new MasterPageItem() { Title = "Splunk Connector", Icon = "itemIcon8.png", TargetType = typeof(Page8) };
            var page9 = new MasterPageItem() { Title = "Books Online", Icon = "itemIcon9.png", TargetType = typeof(Page9) };
            var AboutPage = new MasterPageItem() { Title = "About", Icon = "itemIcon10.png", TargetType = typeof(AboutPage) };
            var tripLogPage = new MasterPageItem() { Title = "Test - GPS", Icon = "red_top_hat_diamond.png", TargetType = typeof(TripLogPage) };
            var page7 = new MasterPageItem() { Title = "Test - Word Wrapping", Icon = "blue_pink_diamond.png", TargetType = typeof(Page7) };
            var openIncidentsPage = new MasterPageItem() { Title = "Test - JSON Data", Icon = "m_purple_diamond.png", TargetType = typeof(OpenIncidentsPage) };
            var swPage = new MasterPageItem() { Title = "Test - SolarWinds Orion SDK", Icon = "bright_green_diamond.png", TargetType = typeof(SwPage) };


            // Adding menu items to menuList (!page, !menu)
            MenuList.Add(page1);
            MenuList.Add(page2);
            MenuList.Add(page3);
            MenuList.Add(page4);
            MenuList.Add(page5);
            MenuList.Add(page6);
            MenuList.Add(azureDataPage);
            MenuList.Add(page8);
            MenuList.Add(page9);
            MenuList.Add(AboutPage);
            MenuList.Add(tripLogPage);
            MenuList.Add(page7);
            MenuList.Add(openIncidentsPage);
            MenuList.Add(swPage);

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
