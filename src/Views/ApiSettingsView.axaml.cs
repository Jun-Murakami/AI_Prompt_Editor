using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AI_Prompt_Editor.ViewModels;

namespace AI_Prompt_Editor.Views
{
    public partial class ApiSettingsView : UserControl
    {
        public ApiSettingsView()
        {
            InitializeComponent();
            //DataContext = new ApiSettingsViewModel();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
