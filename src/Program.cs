﻿using Avalonia;
using System;
using System.Diagnostics;
using System.Runtime;
using Xilium.CefGlue;
using Xilium.CefGlue.Common;
using Xilium.CefGlue.Common.Shared;
using System.Threading.Tasks;

namespace AI_Prompt_Editor
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            // Other initialization code
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

            // Add the unhandled exception handler
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .With(new Win32PlatformOptions
                {
                     // off in Avalonia11
                })
                .AfterSetup(_ => CefRuntimeLoader.Initialize(new CefSettings()
                {
                    CachePath = AppSettings.Instance.AppDataPath,
                    //RemoteDebuggingPort = 9222,
                    LogSeverity = CefLogSeverity.Error,
                    LogFile = AppSettings.Instance.AppDataPath + "\\cef_" + ".log",
                    UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36 /CefSharp Browser"" + Cef.CefSharpVersion;",
                    //BackgroundColor = new CefColor(255, 52, 53, 65),
#if WINDOWLESS
                    WindowlessRenderingEnabled = true
#else
                    WindowlessRenderingEnabled = false
#endif
                },
                customSchemes: new[] {
                new CustomScheme()
                {
                    SchemeName = "AI_Prompt_EditorScheme",
                    SchemeHandlerFactory = new CustomSchemeHandler(),
                    DomainName = "AI_Prompt_Editor",
                    IsStandard = true
                }
                }));

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Handle the unhandled exception here
            Debug.WriteLine("Unhandled exception occurred: " + e.ExceptionObject);
        }


    }
}