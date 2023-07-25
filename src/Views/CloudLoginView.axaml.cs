using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics;
using AI_Prompt_Editor.ViewModels;

namespace AI_Prompt_Editor.Views
{
    public partial class CloudLoginView : UserControl
    {
        public CloudLoginViewModel CloudLoginViewModel { get; } = new CloudLoginViewModel();
        public CloudLoginView()
        {
            InitializeComponent();

            DataContext = CloudLoginViewModel;
            VMLocator.CloudLoginViewModel = CloudLoginViewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
