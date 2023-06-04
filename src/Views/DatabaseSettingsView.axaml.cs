using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AI_Prompt_Editor.ViewModels;

namespace AI_Prompt_Editor.Views
{
    public partial class DatabaseSettingsView : UserControl
    {
        public DatabaseSettingsViewModel DatabaseSettingsViewModel { get; } = new DatabaseSettingsViewModel();

        public DatabaseSettingsView()
        {
            InitializeComponent();

            DataContext = DatabaseSettingsViewModel;
            VMLocator.DatabaseSettingsViewModel = DatabaseSettingsViewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
