using Fresnel.MenuItems;
using Fresnel.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fresnel
{

    public partial class MainPage : MasterDetailPage
    {

        public List<MasterPageItem> menuList { get; set; }

        public MainPage()
        {
            InitializeComponent();
            menuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Home - CSS System Status", Icon = "itemIcon1.png", TargetType = typeof(Page1) };
            var page2 = new MasterPageItem() { Title = "Total Open Incidents", Icon = "itemIcon2.png", TargetType = typeof(Page2) };
            var page3 = new MasterPageItem() { Title = "Operations", Icon = "itemIcon3.png", TargetType = typeof(Page3) };
            var page4 = new MasterPageItem() { Title = "SPDR Heat Map", Icon = "itemIcon4.png", TargetType = typeof(Page4) };
            var page5 = new MasterPageItem() { Title = "Email Statistics", Icon = "itemIcon5.png", TargetType = typeof(Page5) };
            var page6 = new MasterPageItem() { Title = "Current Foreign Travel", Icon = "itemIcon6.png", TargetType = typeof(Page6) };
            var page7 = new MasterPageItem() { Title = "Azure Data", Icon = "itemIcon7.png", TargetType = typeof(Page7) };


            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);
            menuList.Add(page6);
            menuList.Add(page7);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Page7)));
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
