using Microsoft.AspNetCore.Components.WebView.Maui;
using SavuDairy.Server.Application.DependencyInjections;
using SavuDiary.Server.DataLayers;
using SavuDiary.UI;

namespace SavuDiary.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            builder.Services.AddSingleton(typeof(SavuDiary.Client.Components.ToasterServices), typeof(SavuDiary.Client.Components.ToasterServices));
         
            builder.Services.AddDataServices();
            builder.Services.AddDbReporitory();
            builder.Services.AddApplicationServices();
            builder.Services.AddCommonUIServices();
            return builder.Build();
        }
    }
}