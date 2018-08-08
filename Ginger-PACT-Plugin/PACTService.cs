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
            GA.ExInfo = "PACT Mock Server Started on port: " + port + " " + SV.MockProviderServiceBaseUri; ;
        }
    }
}
