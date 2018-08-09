using Ginger_PACT_Plugin;
using GingerPlugInsNET.ActionsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GingerPACTPluginTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StartServer()
        {
            //Arrange
            PACTService service = new PACTService();
            GingerAction GA = new GingerAction("StartService");


            //Act
            service.StartPACTServer(ref GA, 1234);

            //Assert
            Assert.AreEqual("PACT Mock Server Started on port: 1234 http://localhost:1234", GA.ExInfo, "Exinfo message");
            Assert.AreEqual(null, GA.Errors, "No Errors");

        }
    }
}
