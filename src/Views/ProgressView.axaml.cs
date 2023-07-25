using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AI_Prompt_Editor.ViewModels;

namespace AI_Prompt_Editor.Views
{
    public partial class ProgressView : UserControl
    {
        public ProgressViewModel ProgressViewModel { get; } = new ProgressViewModel();
        public ProgressView()
        {
            InitializeComponent();

            DataContext = ProgressViewModel;
            VMLocator.ProgressViewModel = ProgressViewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
