using GingerPlugInsNET.ActionsLib;
using GingerPlugInsNET.PlugInsLib;
using GingerPlugInsNET.ServicesLib;
using System;

namespace Ginger_PACT_Plugin
{
    public class PACTService : PluginServiceBase, IStandAloneAction
    {
        public override string Name { get { return "PACTService"; } }


        ServiceVirtualization SV;

        [GingerAction("StartPACTServer", "Start PACT Server")]
        public void StartPACTServer(ref GingerAction GA, int port)
        {
            // check input params and add errors if invalid
            if (port == 0)
            {
                GA.AddError("StartPACTServer", "Port cannot be 0");
                return;
            }

            // Act
            SV = new ServiceVirtualization(port);

            //ExInfo
            GA.ExInfo = "PACT Mock Server Started on port: " + port + " " + SV.MockProviderServiceBaseUri;
        }


        [GingerAction("StartPACTServer", "Start PACT Server")]
        public void StopPACTServer(ref GingerAction GA)
        {

            // Act
            SV.MockProviderService.Stop();
            SV = null;
            //ExInfo
            GA.ExInfo = "PACT Mock Server Stopped";
        }

        [GingerAction("LoadInteractionsFile", "Load Interactions File")]
        public void LoadInteractionsFile(ref GingerAction GA, string fileName)
        {
            if (SV == null)
            {
                GA.AddError("LoadInteractionsFile","Error: Service Virtualization not started yet");
                return;
            }
            
            //if (s.StartsWith("~"))
            //    s = Path.GetFullPath(s.Replace("~", act.SolutionFolder));
            //if (File.Exists(s))
            //{
            //    int count = SV.LoadInteractions(s);
            //    act.ExInfo += "Interaction file loaded: '" + s + "', " + count + " Interactions loaded";
            //    act.AddOutput("Interaction Loaded", count + "");
            //}
            //else
            //{
            //    act.Error += "Interaction file not found - " + s;
            //}

            // Act

            //ExInfo
            GA.ExInfo = "not implemented yet";
        }


        [GingerAction("ClearInteractions", "Clear Interactions")]
        public void ClearInteractions(ref GingerAction GA)
        {
            if (SV == null)
            {
                GA.AddError("LoadInteractionsFile", "Error: Service Virtualization not started yet");
                return;
            }

            //if (s.StartsWith("~"))
            //    s = Path.GetFullPath(s.Replace("~", act.SolutionFolder));
            //if (File.Exists(s))
            //{
            //    int count = SV.LoadInteractions(s);
            //    act.ExInfo += "Interaction file loaded: '" + s + "', " + count + " Interactions loaded";
            //    act.AddOutput("Interaction Loaded", count + "");
            //}
            //else
            //{
            //    act.Error += "Interaction file not found - " + s;
            //}

            // Act
            SV.ClearInteractions();
            
            //ExInfo
            GA.ExInfo = "Interactions cleared";
        }

        // TODO: LoadInteractionsFolder

        //case cAddInteraction:
        //    if (SV == null)
        //    {
        //        act.Error += "Error: Service Virtualization not started yet";
        //        return;
        //    }

        //    //TODO: get it from the edit page
        //    ProviderServiceInteraction PSI = new ProviderServiceInteraction();
        //    PSI.ProviderState = act.GetOrCreateParam("ProviderState").GetValueAsString();
        //    PSI.Description = act.GetOrCreateParam("Description").GetValueAsString();
        //    PSI.Request = new ProviderServiceRequest();


        //    string HTTPType = act.GetOrCreateParam("RequestType").GetValueAsString();
        //    switch (HTTPType)
        //    {
        //        case "Get":
        //            PSI.Request.Method = HttpVerb.Get;
        //            break;
        //        case "Post":
        //            PSI.Request.Method = HttpVerb.Post;
        //            break;
        //                case "PUT":
        //            PSI.Request.Method = HttpVerb.Put;
        //            break;

        //            //TODO: add all the rest and include default for err
        //    }

        //    PSI.Request.Path = act.GetOrCreateParam("Path").GetValueAsString();
        //    Dictionary<string, string> d = new Dictionary<string, string>();
        //    d.Add("Accept", "application/json");  //TODO: fixme
        //    PSI.Request.Headers = d;
        //    PSI.Response = new ProviderServiceResponse();
        //    PSI.Response.Status = 200;  //TODO: fixme
        //    Dictionary<string, string> r = new Dictionary<string, string>();
        //    r.Add("Content-Type", "application/json; charset=utf-8");   //TODO: fixme
        //    PSI.Response.Headers = r;
        //    PSI.Response.Body = act.GetOrCreateParam("ResposneBody").GetValueAsString();

        //    SV.AddInteraction(PSI);

        //    act.ExInfo += "Interaction added";

        //    break;
        //case cSaveInteractions:
        //    SV.SaveInteractions();
        //    act.ExInfo += "Interactions saved to file";
        //    // TODO: add file name to ex info
        //    break;


    }
}
