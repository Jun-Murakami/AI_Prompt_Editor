﻿using AI_Prompt_Editor.ViewModels;

namespace AI_Prompt_Editor
{
    internal class VMLocator
    {
        private static MainWindowViewModel _mainWindowViewModel;
        public static MainWindowViewModel MainWindowViewModel
        {
            get => _mainWindowViewModel ??= new MainWindowViewModel();
            set => _mainWindowViewModel = value;
        }

        private static MainViewModel _mainViewModel;
        public static MainViewModel MainViewModel
        {
            get => _mainViewModel ??= new MainViewModel();
            set => _mainViewModel = value;
        }

        private static ChatViewModel _chatViewModel;
        public static ChatViewModel ChatViewModel
        {
            get => _chatViewModel ??= new ChatViewModel();
            set => _chatViewModel = value;
        }

        private static WebChatViewModel _webChatViewModel;
        public static WebChatViewModel WebChatViewModel
        {
            get => _webChatViewModel ??= new WebChatViewModel();
            set => _webChatViewModel = value;
        }

        private static WebChatBardViewModel _webChatBardViewModel;
        public static WebChatBardViewModel WebChatBardViewModel
        {
            get => _webChatBardViewModel ??= new WebChatBardViewModel();
            set => _webChatBardViewModel = value;
        }

        private static DataGridViewModel _dataGridViewModel;
        public static DataGridViewModel DataGridViewModel
        {
            get => _dataGridViewModel ??= new DataGridViewModel();
            set => _dataGridViewModel = value;
        }

        private static EditorViewModel _editorViewModel;
        public static EditorViewModel EditorViewModel
        {
            get => _editorViewModel ??= new EditorViewModel();
            set => _editorViewModel = value;
        }

        private static PhrasePresetsViewModel _phrasePresetsViewModel;
        public static PhrasePresetsViewModel PhrasePresetsViewModel
        {
            get => _phrasePresetsViewModel ??= new PhrasePresetsViewModel();
            set => _phrasePresetsViewModel = value;
        }

        private static DatabaseSettingsViewModel _databaseSettingsViewModel;
        public static DatabaseSettingsViewModel DatabaseSettingsViewModel
        {
            get => _databaseSettingsViewModel ??= new DatabaseSettingsViewModel();
            set => _databaseSettingsViewModel = value;
        }
    }
}
