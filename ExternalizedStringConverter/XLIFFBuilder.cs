using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace ExternalizedStringConverter
{
    public class XLIFFBuilder
    {
        private String Preamble = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><xliff xmlns=\"urn:oasis:names:tc:xliff:document:1.2\" version=\"1.2\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"urn:oasis:names:tc:xliff:document:1.2 xliff-core-1.2-transitional.xsd\">";
        private String Header = "<Header /><body>";
        private String Footer = "</body></file></xliff>";
        public List<XLIFFNode> nodes = new List<XLIFFNode>();

        public String TargetLocale = String.Empty;
        public String SourceLocale = String.Empty;

        public XLIFFBuilder(String sLocale, String tLocale)
        {
            TargetLocale = tLocale;
            SourceLocale = sLocale;
        }

        public void toFile(String path)
        {
            String FileNode = String.Format("<file target-language=\"{0}\" datatype=\"xml\" source-language=\"{1}\" original=\"\">", TargetLocale, SourceLocale);
            StreamWriter writer = new StreamWriter(path);
            using (writer)
            {
                writer.WriteLine(Preamble);
                writer.WriteLine(FileNode);
                writer.WriteLine(Header);
                foreach (XLIFFNode node in nodes)
                {
                    writer.WriteLine(node.ToString());
                }
                writer.WriteLine(Footer);


                writer.Flush();
                writer.Close();
            }


        }

    }
}
