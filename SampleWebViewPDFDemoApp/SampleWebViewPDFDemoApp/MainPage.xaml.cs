#if ANDROID
using Android.OS;
using Java.Net;
#endif
using System.Net;
using Microsoft.Maui.Controls;
using SampleWebViewPDFDemoApp.Controls;
using Microsoft.Maui;

namespace SampleWebViewPDFDemoApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        string pdfName = "https://s29.q4cdn.com/175625835/files/doc_downloads/test.pdf";// "Test.pdf";
        web_view.Source = pdfName;
    }
}


