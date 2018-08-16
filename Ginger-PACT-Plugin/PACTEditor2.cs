using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GingerPACTPluginUI
{
    public class PACTEditor2 : ITextEditor
    {
        
    //    public override List<string> Extensions
    //    {
    //        get
    //        {
    //            return new List<string>() { "PACT" };
    //        }
    //    }

    //    public override byte[] HighlightingDefinition
    //    { get {
    //            //string img = "pack://application:,,,/Ginger-PACT-Plugin;component/Images/@Variable_32x32.png";
    //            //return  Properties.Resources.PACTHighlighting;
    //            return null;
    //        } 
    //}

    //    public override List<TextEditorToolBarItem> Tools => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public IFoldingStrategy FoldingStrategy => throw new NotImplementedException();

        public List<string> Extensions => throw new NotImplementedException();

        public byte[] HighlightingDefinition => throw new NotImplementedException();

        List<ITextEditorToolBarItem> ITextEditor.Tools => throw new NotImplementedException();
    }
}
