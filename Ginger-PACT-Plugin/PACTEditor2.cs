using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GingerPACTPluginUI
{
    public class PACTEditor2 : ITextEditor
    {

        //    public override byte[] HighlightingDefinition
        //    { get {
        //            //string img = "pack://application:,,,/Ginger-PACT-Plugin;component/Images/@Variable_32x32.png";
        //            //return  Properties.Resources.PACTHighlighting;
        //            return null;
        //        } 
        //}

        //    public override List<TextEditorToolBarItem> Tools => throw new NotImplementedException();

        string ITextEditor.Name { get { return "PACT Editor"; } }

        public IFoldingStrategy FoldingStrategy { get {
                return null;
            } }

        List<string> ITextEditor.Extensions { get { return new List<string>() { ".pact" }; } }

        public byte[] HighlightingDefinition
        {
            get
            {
                string highlightingDefinitionLocation = "Ginger_PACT_Plugin.PACTHighlighting.xshd";
                Assembly asm = typeof(PACTEditor2).Assembly;
                string[] names = asm.GetManifestResourceNames();

                Stream stream = asm.GetManifestResourceStream(highlightingDefinitionLocation);
                if (stream == null)
                {
                    throw new Exception("Cannot find editor HighlightingDefinition: " + highlightingDefinitionLocation);
                }
                byte[] data = ReadFully(stream);
                return data;
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        List<ITextEditorToolBarItem> ITextEditor.Tools
        {
            get
            {
                return null;
            }
        }
    }
}
