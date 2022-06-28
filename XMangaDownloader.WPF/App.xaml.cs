using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using XMangaDownloader.Core.Services;

namespace XMangaDownloader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(ConfigureServices(new ServiceCollection()));
        }

        private IServiceProvider ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MangaService>();
            return services.BuildServiceProvider();
        }
    }
}
