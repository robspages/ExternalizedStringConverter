using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExternalizedStringConverter
{
    public class XLIFFNode
    {
        public String ID = String.Empty;
        public String Reformat = String.Empty;
        public Boolean Approved = false;
        public XLIFFUnit Source = new XLIFFUnit();
        public XLIFFUnit Target = new XLIFFUnit();

        private String NodeTitle = "trans-unit";

        public XLIFFNode(String id, Boolean isApproved, XLIFFUnit nSource, XLIFFUnit nTarget)
        {
            setup(id, isApproved, nSource, nTarget);
        }

        public XLIFFNode(String id, Boolean isApproved, String sourceLocale, String sourceText, String targetLocale, String targetText)
        {
            setup(id, isApproved, new XLIFFUnit(sourceLocale, sourceText), new XLIFFUnit(targetLocale, targetText));
        }

        private void setup(String id, Boolean isApproved, XLIFFUnit nSource, XLIFFUnit nTarget)
        {
            this.ID = id;
            this.Approved = isApproved;
            this.Source = nSource;
            this.Target = nTarget;
        }

        private string yesNo(Boolean value)
        {
            return value ? "yes" : "no";
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<{0} datatype=\"xml\" reformat=\"{1}\" approved=\"{2}\" id=\"{3}\">", NodeTitle, Reformat, yesNo(Approved), ID);
            sb.AppendFormat("<source xml:lang=\"{0}\">{1}</source>", Source.Locale, Source.Text);
            sb.AppendFormat("<target xml:lang=\"{0}\" state=\"final\">{1}</target>", Target.Locale, Target.Text);
            sb.AppendFormat("</{0}>", NodeTitle);
            return sb.ToString();
        }

    }
}