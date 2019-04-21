using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Controls;

namespace Questions.Utility
{
    public class RichTextUtility
    {
        public string ConvertRichTextBoxToString(RichTextBox rtb)
        {
            var textRange = new TextRange(rtb.Document.ContentStart,

                rtb.Document.ContentEnd);

            return textRange.Text;
        }
    }
}
