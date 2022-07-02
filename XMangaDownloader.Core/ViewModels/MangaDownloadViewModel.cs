using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMangaDownloader.Core.Services;

namespace XMangaDownloader.Core.ViewModels
{
    public class MangaDownloadViewModel: ObservableObject
    {
        public string? PDFSavePath { get; set; }

        private bool _canFetchChapter;
        public bool CanFetchChapter
        {
            get => _canFetchChapter;
            set => SetProperty(ref _canFetchChapter, value);
        }
        private readonly MangaService _mangaService;


        public MangaDownloadViewModel()
        {
            _mangaService = Ioc.Default.GetRequiredService<MangaService>();
        }

        public async Task GetMangasAsync(string chapterUrl)
        {
            await _mangaService.GetMangaFromURL(chapterUrl, PDFSavePath);
        }
    }
}
