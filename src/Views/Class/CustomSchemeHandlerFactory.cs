using Xilium.CefGlue;

namespace AI_Prompt_Editor
{
    class CustomSchemeHandler : CefSchemeHandlerFactory
    {
        protected override CefResourceHandler Create(CefBrowser browser, CefFrame frame, string schemeName, CefRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}