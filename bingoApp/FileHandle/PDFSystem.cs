using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel.Visitors;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using System.Drawing;
using PdfSharp.Pdf;


namespace bingoApp.FileHandle
{
    public class PDFSystem
    {
        private Document _pdfDocument;
        public Document PDFDocument => _pdfDocument;

        /// <summary>
        /// One document, mutiple bingos
        /// </summary>
        /// <param name="s">An <see cref="string[][,]"/> array of all of the bingo boards</param>
        /// <param name="path">Path to save the PDF at</param>
        public PDFSystem(string[][,] s, string path)
        {
            _pdfDocument = new Document();
            _pdfDocument.ImagePath = @"Model\";





            for (int i = 0; i < s.GetLength(0); i = i + 2)
            {
                Section section = _pdfDocument.AddSection();

                CreatePDF(s[i], section);
                if (s.GetLength(0) > i + 1) // Two things on one page
                {
                    CreatePDF(s[i + 1], section); 
                    if (i % 2 == 1)
                }
                //GlobalFontSettings.FontResolver = new FileFontResolver();
                // Style style = _pdfDocument.Styles[StyleNames.Normal];
                //style.Font.Name = "Century";



                PdfDocumentRenderer renderer = new PdfDocumentRenderer();
                renderer.Document = _pdfDocument;
                renderer.RenderDocument();
                renderer.Save(path);
            }
        }


        /// <summary>
        /// Creates the title and grid of the bingo-board
        /// </summary>
        /// <param name="s">The string to put into the table</param>
        /// <param name="section">The section to be added to</param>
        /// <param name="loc">Location of image top or bottom</param>
        private void CreatePDF(string[,] s, Section section)
        {
            _pdfDocument.Info.Title = "Bingo";

            section.PageSetup.TopMargin = 1;
            section.PageSetup.BottomMargin = 1;

            string imagePath = @"Model\LiterificQuiz.jpg";

            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException("Image not found", imagePath);
            }

            Image image = section.AddImage(imagePath);
            image.ScaleWidth = 0.25;
            image.ScaleHeight = 0.25;
            image.Left = ShapePosition.Left;
            image.RelativeHorizontal = RelativeHorizontal.Page;
            image.RelativeVertical = RelativeVertical.Paragraph;
            image.WrapFormat.Style = WrapStyle.Through;
            image.Top = ShapePosition.Top;



            Paragraph text = section.AddParagraph();
            text.AddText("The Literific");
            


            text.Format.Alignment = ParagraphAlignment.Center;
            text.Format.Font.Size = 16;
            text.Format.Font.Bold = true;

            Table table = section.AddTable();
            table.AddColumn("25mm");
            table.AddColumn("25mm");
            table.AddColumn("25mm");
            table.AddColumn("25mm");
            table.AddColumn("25mm");
            table.Borders.Width = 0.1;

            string[][] ss = new string[s.GetLength(0)][];

            for (int i = 0; i < s.GetLength(0); i++)
            {
                ss[i] = new string[5] { s[i, 0], s[i, 1], s[i, 2], s[i, 3], s[i, 4]};
            }

            for (int i = 0; i < ss.Length; i++)
            {
                CreateRow(table, ss[i]);
            }

            // Aligns table to the center
            table.Rows.Alignment = RowAlignment.Center;
            table.Rows.Height = "25mm";
        }




        /// <summary>
        /// Creates row in the centre of the table
        /// </summary>
        /// <param name="table">The table to add the row to</param>
        /// <param name="s">The value to add in each respective cell</param>
        /// <returns></returns>
        private Table CreateRow(Table table, string[] s)
        {
            Row row = table.AddRow();
            for (int i = 0; i < s.Length; i++)
            {
                row.Cells[i].AddParagraph(s[i]);
                row.Cells[i].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[i].Format.Alignment = ParagraphAlignment.Center;
                //row.Format.Font.Name = "Century Gothic";
            }

            return table;
        }

    }
}
