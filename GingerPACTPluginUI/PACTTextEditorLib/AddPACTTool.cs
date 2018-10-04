using Amdocs.Ginger.Plugin.Core;
using GingerPACTPlugIn.PACTTextEditorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GingerPACTPluginUI.PACTTextEditorLib
{
    public class AddPACTTool : ITextEditorToolBarItem
    {
        public string ToolText { get { return "Add PACT"; } }

        public string ToolTip { get { return "Add PACT"; } }

        PACTTextEditor mPACTTextEditorr;

        public AddPACTTool(PACTTextEditor PACTTextEditor)
        {
            mPACTTextEditorr = PACTTextEditor;
        }

        public void Execute(ITextEditor textEditor)
        {
            MessageBox.Show("done");
        }
    }
}
