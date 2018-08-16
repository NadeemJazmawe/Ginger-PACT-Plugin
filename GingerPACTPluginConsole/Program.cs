using Amdocs.Ginger.CoreNET.Drivers.CommunicationProtocol;
using Ginger_PACT_Plugin;
using GingerCoreNET.DriversLib;
using System;

namespace GingerPACTPluginConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting PACT Plugin");
            //PACTService s = new PACTService();
            //GingerAction GA = new GingerAction("aa");
            //s.StartPACTServer(ref GA, 4444);
            //Console.WriteLine("Done!");
            
            //GingerNode gingerNode = new GingerNode(new PACTService());
            //gingerNode.StartGingerNode("PACT", SocketHelper.GetLocalHostIP(), 15001);

            //TODO: Wait for?
            
            Console.ReadKey();
        }
    }
}
