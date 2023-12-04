using System;
using SampleWebViewPDFDemoApp.Controls;
using Microsoft.Maui.Handlers;

namespace SampleWebViewPDFDemoApp.Controls
{
	public class PDFViewForUrlHandler :  WebViewHandler
	{
		public PDFViewForUrlHandler()
		{
            Mapper.AppendToMapping(nameof(PDFViewForUrlHandler), (handler, view) =>
            {
#if ANDROID
                if (view is PDFViewForUrl)
                {
                    handler.PlatformView.Settings.JavaScriptEnabled = true;
                    handler.PlatformView.Settings.AllowFileAccess = true;
                    handler.PlatformView.Settings.AllowFileAccessFromFileURLs = true;
                    handler.PlatformView.Settings.AllowUniversalAccessFromFileURLs = true;
                    handler.PlatformView.Settings.BuiltInZoomControls = true;
                    handler.PlatformView.Settings.AllowContentAccess = true;
                    string res = "";
                    if (view != null)
                    {
                        WebView webView = view as WebView;
                        if (webView.Source.GetType().Equals(typeof(UrlWebViewSource)))
                        {
                            UrlWebViewSource uriwebviewSource = webView.Source as UrlWebViewSource;
                            if (uriwebviewSource.Url.ToString().ToLower().StartsWith("https://") || uriwebviewSource.Url.ToString().ToLower().StartsWith("http://"))
                                res = string.Format("https://drive.google.com/viewerng/viewer?url={0}", uriwebviewSource.Url.ToString());
                            else
                                res = $"file:///android_asset/pdfjs/web/viewer.html?file=file:///android_asset/{uriwebviewSource.Url.ToString()}";
                        }
                    }
                    handler.PlatformView.LoadUrl(res);
                }
#endif
            });
        }
	}
}

