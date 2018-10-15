using System;
using System.Linq;
using Amdocs.Ginger.Plugin.Core;
using GingerPACTPlugIn.PACTTextEditorLib;
using GingerTestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GingerPACTPluginUITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            PACTTextEditor editor = new PACTTextEditor();
            editor.TextHandler = new TextHandler();
            string fileName = TestResources.GetTestResourcesFile("Pact1.pact");
            editor.TextHandler.Text = System.IO.File.ReadAllText(fileName);            
            ITextEditorToolBarItem v = (from x in ((ITextEditor)editor).Tools where x.ToolText == "Export to JSON" select x).SingleOrDefault();

            //Act
            v.Execute(editor);


            //Assert
            //TODO: check output
        }
    }
}
