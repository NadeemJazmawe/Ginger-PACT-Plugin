using Amdocs.Ginger.Plugin.Core;
using GingerPACTPlugIn.PACTTextEditorLib;
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

        PACTTextEditor mPACTTextEditorr;
        public ExportToJSONTool(PACTTextEditor PACTTextEditor)
        {
            mPACTTextEditorr = PACTTextEditor;
        }

        public void Execute(ITextEditor textEditor)
        {

            mPACTTextEditorr.Compile();

            //TODO: FIXME hard coded!
            string SaveToPath = @"c:\temp\pact.json";
            //string SaveToPath = string.Empty;
            //if (!OpenFolderDialog("Select folder for saving the created Json file", ref SaveToPath))
            //{
            //    ErrorMessage = "Export To Json Aborted";
            //    return;
            //}

            List<ProviderServiceInteraction> PSIList = mPACTTextEditorr.ParsePACT(mPACTTextEditorr.txt);
            string ServiceConsumer = mPACTTextEditorr.ParseProperty(mPACTTextEditorr.TextHandler.Text, "Consumer");
            string HasPactWith = mPACTTextEditorr.ParseProperty(mPACTTextEditorr.TextHandler.Text, "Provider");
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
                // SuccessMessage = "Json File Exported Successfully";
                Process.Start(SaveToPath);
            }
            catch (Exception ex)
            {
                // editor.ShowMEssage( ErrorMessage = "Json File Export Failed" + Environment.NewLine + ex.Message;
                SV.MockProviderService.Stop();
            }
        }

        
        
    }


}
