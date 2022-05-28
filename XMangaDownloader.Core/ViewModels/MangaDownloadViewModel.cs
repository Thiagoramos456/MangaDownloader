using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMangaDownloader.Core.ViewModels
{
    public class MangaDownloadViewModel: ObservableObject
    {
        public string? MangaURL { get; set; }

    }
}
