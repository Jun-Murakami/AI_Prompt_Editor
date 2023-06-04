using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AI_Prompt_Editor.ViewModels;

namespace AI_Prompt_Editor.Views
{
    public partial class Editor2TextBoxView : UserControl
    {
        private TextBox _editor2;
        public Editor2TextBoxViewModel Editor2TextBoxViewModel { get; } = new Editor2TextBoxViewModel();
        public Editor2TextBoxView()
        {
            InitializeComponent();
            DataContext = Editor2TextBoxViewModel;
            VMLocator.Editor2TextBoxViewModel = Editor2TextBoxViewModel;

            _editor2 = this.FindControl<TextBox>("Editor2TextBox");

            _editor2.Text = string.Empty;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
