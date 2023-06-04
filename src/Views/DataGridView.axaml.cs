using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AI_Prompt_Editor.ViewModels;

namespace AI_Prompt_Editor.Views
{
    public partial class DataGridView : UserControl
    {
        public DataGridViewModel DataGridViewModel { get; } = new DataGridViewModel();
        public DataGridView()
        {
            InitializeComponent();
            DataContext = DataGridViewModel;
            VMLocator.DataGridViewModel = DataGridViewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
