﻿using AppEje2_4.Controllers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEje2_4
{
    public partial class App : Application
    {
        static FirmasDB database;

        public static FirmasDB BaseDatos
        {
            get
            {
                if (database == null)
                {
                    database = new FirmasDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FirmasDB.db3"));
                }
                return database;

            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vistas.PageFirma());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
