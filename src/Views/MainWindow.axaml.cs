using Avalonia;
using Avalonia.Controls;
using System.Text.Json;
using System.IO;
using System;
using AI_Prompt_Editor.ViewModels;
using FluentAvalonia.UI.Controls;
using Avalonia.Threading;
using System.Threading.Tasks;
using AI_Prompt_Editor.Models;
using Avalonia.Interactivity;
using System.Globalization;
using Avalonia.Markup.Xaml.Styling;
using System.Linq;
using Avalonia.Markup.Xaml;
using System.Diagnostics;
using Avalonia.Input;

namespace AI_Prompt_Editor.Views
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel MainWindowViewModel { get; } = new MainWindowViewModel();
        DatabaseProcess _dbProcess = new DatabaseProcess();

        public MainWindow()
        {
            InitializeComponent();

            this.Closing += (sender, e) => SaveWindowSizeAndPosition();

            this.Loaded += MainWindow_Loaded;

            DataContext = MainWindowViewModel;
            VMLocator.MainWindowViewModel = MainWindowViewModel;

            // キーイベントハンドラ
            this.KeyDown += MainWindow_KeyDown;
            this.KeyUp += MainWindow_KeyUp;


            // Get the current culture info
            var cultureInfo = CultureInfo.CurrentCulture;
            if(cultureInfo.Name == "ja-JP")
            {
                Translate("ja-JP");
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftAlt || e.Key == Key.RightAlt)
            {
                VMLocator.PhrasePresetsViewModel.AltKeyIsDown = true;
            }
            else if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                VMLocator.PhrasePresetsViewModel.CtrlKeyIsDown = true;
            }
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftAlt || e.Key == Key.RightAlt)
            {
                VMLocator.PhrasePresetsViewModel.AltKeyIsDown = false;
            }
            else if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                VMLocator.PhrasePresetsViewModel.CtrlKeyIsDown = false;
            }
        }

        private double _previousWidth;

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var settings = await LoadAppSettingsAsync();

            if (File.Exists(Path.Combine(settings.AppDataPath, "settings.json")))
            {
                this.Width = settings.Width - 1;
                this.Position = new PixelPoint(settings.X, settings.Y);
                this.Height = settings.Height;
                this.Width = settings.Width;
                this.WindowState = settings.IsMaximized ? WindowState.Maximized : WindowState.Normal;
            }
            else
            {
                var screen = Screens.Primary;
                var workingArea = screen.WorkingArea;

                double dpiScaling = screen.PixelDensity;
                this.Width = 1300 * dpiScaling;
                this.Height = 840 * dpiScaling;

                this.Position = new PixelPoint(5, 0);
            }

            VMLocator.DatabaseSettingsViewModel.DatabasePath = settings.DbPath;

            if (!File.Exists(settings.DbPath))
            {
                _dbProcess.CreateDatabase();
            }

            await _dbProcess.DbLoadToMemoryAsync();
            await VMLocator.MainViewModel.LoadPhraseItemsAsync();

            VMLocator.MainViewModel.SelectedPhraseItem = settings.PhrasePreset;

            VMLocator.MainViewModel.SelectedLogPain = "Chat Log";

            VMLocator.MainViewModel.PhraseExpanderIsOpened = settings.PhraseExpanderMode;

            await _dbProcess.GetEditorLogDatabaseAsync();
            await _dbProcess.GetTemplateItemsAsync();

            VMLocator.EditorViewModel.EditorCommonFontSize = settings.EditorFontSize > 0 ? settings.EditorFontSize : 1;
            VMLocator.MainViewModel.SelectedPhraseItem = settings.PhrasePreset;
            VMLocator.EditorViewModel.EditorModeIsChecked = true;
            
            VMLocator.MainWindowViewModel.ApiMaxTokens = settings.ApiMaxTokens;
            VMLocator.MainWindowViewModel.ApiTemperature = settings.ApiTemperature;
            VMLocator.MainWindowViewModel.ApiTopP = settings.ApiTopP;
            VMLocator.MainWindowViewModel.ApiN = settings.ApiN;
            VMLocator.MainWindowViewModel.ApiLogprobs = settings.ApiLogprobs;
            VMLocator.MainWindowViewModel.ApiPresencePenalty = settings.ApiPresencePenalty;
            VMLocator.MainWindowViewModel.ApiFrequencyPenalty = settings.ApiFrequencyPenalty;
            VMLocator.MainWindowViewModel.ApiBestOf = settings.ApiBestOf;
            VMLocator.MainWindowViewModel.ApiStop = settings.ApiStop;
            VMLocator.MainWindowViewModel.ApiLogitBias = settings.ApiLogitBias;
            VMLocator.MainWindowViewModel.ApiModel = settings.ApiModel;
            VMLocator.MainWindowViewModel.ApiUrl = settings.ApiUrl;
            VMLocator.MainWindowViewModel.ApiKey = settings.ApiKey;
            VMLocator.MainWindowViewModel.MaxContentLength = settings.MaxContentLength;

            VMLocator.MainWindowViewModel.ApiMaxTokensIsEnable = settings.ApiMaxTokensIsEnable;
            VMLocator.MainWindowViewModel.ApiTemperatureIsEnable = settings.ApiTemperatureIsEnable;
            VMLocator.MainWindowViewModel.ApiTopPIsEnable = settings.ApiTopPIsEnable;
            VMLocator.MainWindowViewModel.ApiNIsEnable = settings.ApiNIsEnable;
            VMLocator.MainWindowViewModel.ApiLogprobIsEnable = settings.ApiLogprobIsEnable;
            VMLocator.MainWindowViewModel.ApiPresencePenaltyIsEnable = settings.ApiPresencePenaltyIsEnable;
            VMLocator.MainWindowViewModel.ApiFrequencyPenaltyIsEnable = settings.ApiFrequencyPenaltyIsEnable;
            VMLocator.MainWindowViewModel.ApiBestOfIsEnable = settings.ApiBestOfIsEnable;
            VMLocator.MainWindowViewModel.ApiStopIsEnable = settings.ApiStopIsEnable;
            VMLocator.MainWindowViewModel.ApiLogitBiasIsEnable = settings.ApiLogitBiasIsEnable;
            VMLocator.MainWindowViewModel.MaxContentLengthIsEnable = settings.MaxContentLengthIsEnable;

            VMLocator.EditorViewModel.EditorHeight1 = settings.EditorHeight1;
            VMLocator.EditorViewModel.EditorHeight2 = settings.EditorHeight2;
            VMLocator.EditorViewModel.EditorHeight3 = settings.EditorHeight3;
            VMLocator.EditorViewModel.EditorHeight4 = settings.EditorHeight4;
            VMLocator.EditorViewModel.EditorHeight5 = settings.EditorHeight5;

            await Dispatcher.UIThread.InvokeAsync(() => { VMLocator.MainViewModel.LogPainIsOpened = false; });
            if (this.Width > 1295)
            {
                //await Task.Delay(1000);
                await Dispatcher.UIThread.InvokeAsync(() => { VMLocator.MainViewModel.LogPainIsOpened = true; });
            }

            this.GetObservable(ClientSizeProperty).Subscribe(size => OnSizeChanged(size));
            _previousWidth = ClientSize.Width;

            await _dbProcess.UpdateChatLogDatabaseAsync();

            VMLocator.DataGridViewModel.ChatList = await _dbProcess.SearchChatDatabaseAsync();
            VMLocator.DataGridViewModel.SelectedItemIndex = -1;
            VMLocator.EditorViewModel.EditorModeIsChecked = settings.EditorMode;
            VMLocator.EditorViewModel.SelectedLangIndex = settings.SyntaxHighlighting;
            VMLocator.EditorViewModel.EditorSeparateMode = settings.SeparatorMode;

            await _dbProcess.CleanUpEditorLogDatabaseAsync();
            VMLocator.EditorViewModel.SelectedEditorLogIndex = -1;

        }

        private void OnSizeChanged(Size newSize)
        {
            if (_previousWidth != newSize.Width)
            {
                if (newSize.Width <= 1295)
                {
                    VMLocator.MainViewModel.LogPainIsOpened = false;
                    VMLocator.MainViewModel.LogPainButtonIsVisible = false;
                }
                else
                {
                    if (VMLocator.MainViewModel.LogPainButtonIsVisible == false)
                    {
                        VMLocator.MainViewModel.LogPainButtonIsVisible = true;
                    }
                    if (newSize.Width > _previousWidth)
                    {
                        VMLocator.MainViewModel.LogPainIsOpened = true;
                    }
                }
                _previousWidth = newSize.Width;
            }
        }

        private async Task<AppSettings> LoadAppSettingsAsync()
        {
            var settings = AppSettings.Instance;

            settings = new AppSettings();

            if (File.Exists(Path.Combine(settings.AppDataPath, "settings.json")))
            {
                try
                {
                    var options = new JsonSerializerOptions();
                    options.Converters.Add(new GridLengthConverter());

                    var jsonString = File.ReadAllText(Path.Combine(settings.AppDataPath, "settings.json"));
                    settings = JsonSerializer.Deserialize<AppSettings>(jsonString, options);
                }
                catch (Exception)
                {
                    var dialog = new ContentDialog() { Title = $"Invalid setting file. Reset to default values.", PrimaryButtonText = "OK" };
                    await VMLocator.MainViewModel.ContentDialogShowAsync(dialog);
                    File.Delete(Path.Combine(settings.AppDataPath, "settings.json"));
                }
            }

            return settings;
        }

        public void SaveWindowSizeAndPosition()
        {
            var settings = AppSettings.Instance;
            settings.IsMaximized = this.WindowState == WindowState.Maximized;
            this.WindowState = WindowState.Normal;
            settings.Width = this.Width;
            settings.Height = this.Height;
            settings.X = this.Position.X;
            settings.Y = this.Position.Y;

            settings.EditorMode = VMLocator.EditorViewModel.EditorModeIsChecked;
            settings.EditorFontSize = VMLocator.EditorViewModel.EditorCommonFontSize;
            settings.PhrasePreset = VMLocator.MainViewModel.SelectedPhraseItem;
            settings.SyntaxHighlighting = VMLocator.EditorViewModel.SelectedLangIndex;
            settings.PhraseExpanderMode = VMLocator.MainViewModel.PhraseExpanderIsOpened;

            settings.EditorHeight1 = VMLocator.EditorViewModel.EditorHeight1;
            settings.EditorHeight2 = VMLocator.EditorViewModel.EditorHeight2;
            settings.EditorHeight3 = VMLocator.EditorViewModel.EditorHeight3;
            settings.EditorHeight4 = VMLocator.EditorViewModel.EditorHeight4;
            settings.EditorHeight5 = VMLocator.EditorViewModel.EditorHeight5;

            settings.SeparatorMode = VMLocator.EditorViewModel.EditorSeparateMode;

            SaveAppSettings(settings);
        }

        private void SaveAppSettings(AppSettings settings)
        {
            var jsonString = JsonSerializer.Serialize(settings);
            File.WriteAllText(Path.Combine(settings.AppDataPath, "settings.json"), jsonString);
        }

        public void Translate(string targetLanguage)
        {
            var translations = App.Current.Resources.MergedDictionaries.OfType<ResourceInclude>().FirstOrDefault(x => x.Source?.OriginalString?.Contains("/Lang/") ?? false);

            if (translations != null)
                App.Current.Resources.MergedDictionaries.Remove(translations);

            App.Current.Resources.MergedDictionaries.Add(
                (ResourceDictionary)AvaloniaXamlLoader.Load(
                    new Uri($"avares://AI Prompt Editor/Assets/Lang/{targetLanguage}.axaml")
                    )
                );
        }
    }
}