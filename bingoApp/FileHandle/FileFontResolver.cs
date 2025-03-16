using PdfSharp.Fonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bingoApp.FileHandle
{
    public class FileFontResolver : IFontResolver // FontResolverBase
    {
        public string DefaultFontName => throw new NotImplementedException();

        public byte[] GetFont(string faceName)
        {
            using (var ms = new MemoryStream())
            {
                using (var fs = File.Open(faceName, FileMode.Open))
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    return ms.ToArray();
                }
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            if (familyName.Equals("Century", StringComparison.CurrentCultureIgnoreCase))
            {
                if (isBold && isItalic)
                {
                    return new FontResolverInfo("Fonts/Century-BoldItalic.ttf");
                }
                else if (isBold)
                {
                    return new FontResolverInfo("Fonts/Century-Bold.ttf");
                }
                else if (isItalic)
                {
                    return new FontResolverInfo("Fonts/Century-Italic.ttf");
                }
                else
                {
                    return new FontResolverInfo("Fonts/Century.ttf");
                }
            }
            return null;
        }
    }

}
