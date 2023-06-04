using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AI_Prompt_Editor.Views
{
    public partial class HotKeyDisplayView : UserControl
    {
        public HotKeyDisplayView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}