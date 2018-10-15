using Amdocs.Ginger.Plugin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GingerPACTPluginUITest
{
    public class TextHandler : ITextHandler
    {

        string mText = "";
        public string Text { get { return mText; } set { mText = value; } }

        public int CaretLocation { get; set; }

        public void AppendText(string text)
        {
            mText += text;
        }

        public void InsertText(string text)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(MessageType messageType, string text)
        {
            throw new NotImplementedException();
        }
    }
}
