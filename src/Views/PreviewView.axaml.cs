using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AI_Prompt_Editor.ViewModels;

namespace AI_Prompt_Editor.Views
{
    public partial class PreviewView: UserControl
    {
        public PreviewView()
        {
            InitializeComponent();
            var editorViewModel = VMLocator.EditorViewModel;

            var previewTextBox = this.FindControl<TextBox>("PreviewTextBox");

            this.AttachedToVisualTree += (sender, e) =>
            {
                if (previewTextBox == null || VMLocator.EditorViewModel == null || VMLocator.EditorViewModel.GetRecentText() == null) return;
                previewTextBox.Text = VMLocator.EditorViewModel.GetRecentText();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }

}
