using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace DemoLocalDB
{
    [Activity(Label = "DemoLocalDB", Theme = "@style/Theme.DesignDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        #region Menu

        private DrawerLayout drawerLayout;
        private NavigationView navigationView;

        #endregion Menu


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            #region Menu

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.c_drawer_layout);

            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            navigationView = FindViewById<NavigationView>(Resource.Id.c_nav_view);
            SetupDrawerContent(navigationView);

            View header = navigationView.GetHeaderView(0);
            TextView navheader_username = header.FindViewById<TextView>(Resource.Id.navheader_username);
            navheader_username.Text = "Chinthaka Bandara";

            #endregion Menu
        }

        #region Menu

        private void SetupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);

                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                if (e.MenuItem.ItemId == Resource.Id.nav_MGrade)
                {
                    MGradeFragment mg = new MGradeFragment();
                    // The fragment will have the ID of Resource.Id.fragment_container.
                    ft.Replace(Resource.Id.ll, mg);
                }
                else if (e.MenuItem.ItemId == Resource.Id.home)
                {
                    //...
                }
                //...

                // Commit the transaction.
                ft.Commit();
                drawerLayout.CloseDrawers();
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            navigationView.InflateMenu(Resource.Menu.menu_main);
            return true;
        }

        #endregion Menu
    }
}