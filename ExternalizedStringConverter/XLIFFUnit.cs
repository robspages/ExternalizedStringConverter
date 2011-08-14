using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExternalizedStringConverter
{
    public class XLIFFUnit
    {
        public String Locale = String.Empty;
        public String Text = String.Empty;

        public XLIFFUnit() { }

        public XLIFFUnit(String locale, String text)
        {
            this.Locale = locale;
            this.Text = text;
        }
    }
}
