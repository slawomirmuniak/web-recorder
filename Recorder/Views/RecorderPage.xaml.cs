using Microsoft.UI.Xaml.Controls;

using Recorder.ViewModels;
using Windows.UI.WebUI;

namespace Recorder.Views;

public sealed partial class RecorderPage : Page
{
    public RecorderViewModel ViewModel
    {
        get;
    }

    public RecorderPage()
    {
        ViewModel = App.GetService<RecorderViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(web);
        web.CoreWebView2Initialized += Web_CoreWebView2Initialized;
    }

    private void Web_CoreWebView2Initialized(WebView2 sender, CoreWebView2InitializedEventArgs args)
    {
        Console.WriteLine("Works");
        if (sender.CoreWebView2 != null)
        {
            Console.WriteLine("Works x2");
        }
    }
}
