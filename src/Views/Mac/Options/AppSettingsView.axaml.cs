using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AI_Prompt_Editor.ViewModels;

namespace AI_Prompt_Editor.Views
{
    public partial class AppSettingsView : UserControl
    {
        public AppSettingsViewModel AppSettingsViewModel { get; } = new AppSettingsViewModel();

        public AppSettingsView()
        {
            InitializeComponent();

            DataContext = AppSettingsViewModel;
            VMLocator.AppSettingsViewModel = AppSettingsViewModel;

            this.AttachedToVisualTree += AppSettingsView_AttachedToVisualTree;
        }

        private void AppSettingsView_AttachedToVisualTree(object? sender, Avalonia.VisualTreeAttachmentEventArgs e)
        {
            AppSettingsViewModel.SelectedLanguage = AppSettings.Instance.Language;
            AppSettingsViewModel.EditorCommonFontSize = AppSettings.Instance.EditorFontSize;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
