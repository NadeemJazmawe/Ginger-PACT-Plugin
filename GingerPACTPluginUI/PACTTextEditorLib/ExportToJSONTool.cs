using Amdocs.Ginger.Plugin.Core;
using GingerPACTPlugIn.PACTTextEditorLib;
using GingerPACTPluginUI;
using Newtonsoft.Json;
using PactNet.Mocks.MockHttpService.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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

            // mPACTTextEditorr.Compile();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            Thread t = new Thread((ThreadStart)(() =>
            {
                
                saveFileDialog.Filter = "Json files (*.json)|*.json";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            List<ProviderServiceInteraction> PSIList = mPACTTextEditorr.ParsePACT(mPACTTextEditorr.txt);
            //string ServiceConsumer = mPACTTextEditorr.ParseProperty(mPACTTextEditorr.TextHandler.Text, "Consumer");
            //string HasPactWith = mPACTTextEditorr.ParseProperty(mPACTTextEditorr.TextHandler.Text, "Provider");
            //ServiceVirtualization SV = new ServiceVirtualization(0, SaveToPath, ServiceConsumer, HasPactWith);
            try
            {
                // TODO: use simple json save obj to file - might be faster - but will be good to comapre with below PACT lib
                //TODO: reuse the same code port is dummy, need to create SV constructor for creating json
                //foreach (ProviderServiceInteraction PSI in PSIList)
                //{
                //    SV.AddInteraction(PSI);
                //}
                //SV.PactBuilder.Build();  // will save it in C:\temp\pacts - TODO: config
                //SV.MockProviderService.Stop();

                // generate our own JSON
                string txt = JsonConvert.SerializeObject(PSIList, Formatting.Indented);
                string template = "{" + Environment.NewLine;
                template += "\"consumer\": {" + Environment.NewLine;
                template += "\"name\": \"Foo\"" + Environment.NewLine;
                template += "}," + Environment.NewLine;
                template += "\"provider\": {" + Environment.NewLine;
                template += "\"name\": \"Bar\"" + Environment.NewLine;
                template += "}," + Environment.NewLine;
                template += "\"interactions\":" + Environment.NewLine;
                


                string last = ",\"metadata\": {" + Environment.NewLine;
                last += "\"pactSpecification\": {" + Environment.NewLine;
                last += "\"version\": \"2.0.0\"" + Environment.NewLine;
                last += "}" + Environment.NewLine;
                last += "}" + Environment.NewLine;
                last += "}" + Environment.NewLine;
                
                File.WriteAllText(saveFileDialog.FileName, template + txt + last);

                // SuccessMessage = "Json File Exported Successfully";
                //Process.Start(Path.GetDirectoryName(saveFileDialog.FileName));
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() { FileName = Path.GetDirectoryName(saveFileDialog.FileName), UseShellExecute = true });
            }
            catch (Exception ex)
            {
                // editor.ShowMEssage( ErrorMessage = "Json File Export Failed" + Environment.NewLine + ex.Message;
                throw new Exception("Error: " + ex.Message);
                // SV.MockProviderService.Stop();
            }
        }

        
        
    }


}
