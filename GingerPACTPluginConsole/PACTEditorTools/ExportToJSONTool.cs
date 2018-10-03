using Amdocs.Ginger.Plugin.Core;
using GingerPACTPluginUI;
using PactNet.Mocks.MockHttpService.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Ginger_PACT_Plugin.PACTEditorTools
{
    class ExportToJSONTool : ITextEditorToolBarItem
    {      
        public string ToolText { get { return "Export to JSON"; } }

        public string ToolTip { get { return "Generate JSON with PACT interactions"; } }

        public void Execute(ITextEditor textEditor)
        {
            PACTEditor2 editor = (PACTEditor2)textEditor;
            editor.Compile();

            //TODO: FIXME hard coded!
            string SaveToPath = @"c:\temp\pact.json";
            //string SaveToPath = string.Empty;
            //if (!OpenFolderDialog("Select folder for saving the created Json file", ref SaveToPath))
            //{
            //    Args.ErrorMessage = "Export To Json Aborted";
            //    return;
            //}

            List<ProviderServiceInteraction> PSIList = editor.ParsePACT(editor.TextHandler.Text);
            string ServiceConsumer = editor.ParseProperty(editor.TextHandler.Text, "Consumer");
            string HasPactWith = editor.ParseProperty(editor.TextHandler.Text, "Provider");
            ServiceVirtualization SV = new ServiceVirtualization(0, SaveToPath, ServiceConsumer, HasPactWith);
            try
            {
                // TODO: use simple json save obj to file - might be faster - but will be good to comapre with below PACT lib
                //TODO: reuse the same code port is dummy, need to create SV constructor for creating json
                foreach (ProviderServiceInteraction PSI in PSIList)
                {
                    SV.AddInteraction(PSI);
                }
                SV.PactBuilder.Build();  // will save it in C:\temp\pacts - TODO: config
                SV.MockProviderService.Stop();
                // Args.SuccessMessage = "Json File Exported Successfully";
                Process.Start(SaveToPath);
            }
            catch (Exception ex)
            {
                // editor.ShowMEssage( Args.ErrorMessage = "Json File Export Failed" + Environment.NewLine + ex.Message;
                SV.MockProviderService.Stop();
            }
        }
    }


}
