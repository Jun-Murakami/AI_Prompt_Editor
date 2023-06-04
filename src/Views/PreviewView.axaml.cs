using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AI_Prompt_Editor.ViewModels;

namespace AI_Prompt_Editor.Views
{
    public partial class PreviewView: UserControl
    {
        public PreviewViewModel PreviewViewModel { get; } = new PreviewViewModel();
        public PreviewView()
        {
            InitializeComponent();
            var editorViewModel = VMLocator.EditorViewModel;
            PreviewViewModel.EditorViewModel = editorViewModel;
            DataContext = PreviewViewModel;
            VMLocator.PreviewViewModel = PreviewViewModel;
        }
            private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }

}
