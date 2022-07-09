using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace bingoApp.FileHandle
{
    public class PDFSystem
    {
        private Document _pdfDocument;
        public Document PDFDocument => _pdfDocument;



        /// <summary>
        /// One document, mutiple bingos
        /// </summary>
        /// <param name="s"></param>
        /// <param name="path"></param>
        public PDFSystem(string[][,] s, string path)
        {
            _pdfDocument = new Document();
            
            for (int i = 0; i < s.GetLength(0); i=i+2)
            {
                Section section = _pdfDocument.AddSection();
                CreatePDF(s[i], section);
                if (s.GetLength(0) > i + 1) // Two things on one page
                {
                    CreatePDF(s[i + 1], section);
                }
            }
            PdfDocumentRenderer renderer = new PdfDocumentRenderer();
            renderer.Document = _pdfDocument;
            renderer.RenderDocument();
            renderer.Save(path);
        }


        /// <summary>
        /// Constructor for one Bingo per PDF
        /// </summary>
        /// <param name="s"></param>
        /// <param name="path"></param>
        
        public PDFSystem(string[,] s, string path)
        {
            _pdfDocument = new Document();
            CreatePDF(s);
            PdfDocumentRenderer renderer = new PdfDocumentRenderer();
            renderer.Document = _pdfDocument;
            renderer.RenderDocument();
            renderer.Save(path);
        }

        private void CreatePDF(string[,] s, Section section)
        {
            _pdfDocument.Info.Title = "Bingo";
            
            Paragraph text = section.AddParagraph();
            text.AddText("Awards Bingo");
            text.Format.Font.Name = "Century Gothic";
            text.Format.Alignment = ParagraphAlignment.Center;
            text.Format.Font.Size = 16;
            text.Format._spaceBefore.Centimeter = 1;
            text.Format._spaceAfter.Centimeter = 0.25;
            text.Format.Font.Bold = true;

            Table table = section.AddTable();
            table.AddColumn("50mm");
            table.AddColumn("50mm");
            table.AddColumn("50mm");
            table.Borders.Width = 0.25;

            string[][] ss = new string[s.GetLength(0)][];

            for (int i = 0; i < s.GetLength(0); i++)
            {
                ss[i] = new string[3] { s[i, 0], s[i, 1], s[i, 2], };
            }

            for (int i = 0; i < ss.Length; i++)
            {
                CreateRow(table, ss[i]);
            }

            // Aligns table to the center
            table.Rows.Alignment = RowAlignment.Center;
            table.Rows.Height = "30mm";
        }

        private void CreatePDF(string[,] s)
        {
            _pdfDocument.Info.Title = "Bingo";
            
            Section section = _pdfDocument.AddSection();
            Paragraph text = section.AddParagraph();
            text.AddText("Awards Bingo");
            text.Format.Font.Name = "Century Gothic";
            text.Format.Alignment = ParagraphAlignment.Center;
            text.Format._spaceAfter.Centimeter = 1;
            text.Format.Font.Size = 16;
            text.Format.Font.Bold = true;


            Table table = section.AddTable();
            table.AddColumn("50mm");
            table.AddColumn("50mm");
            table.AddColumn("50mm");
            table.Borders.Width = 0.25;

            string[][] ss = new string[s.GetLength(0)][];

            for (int i = 0; i < s.GetLength(0); i++)
            {
                ss[i] = new string[3] { s[i,0], s[i,1], s[i,2], };
            }
           
            for (int i =0; i < ss.Length; i++)
            {
                CreateRow(table, ss[i]);
            }

            // Aligns table to the center
            table.Rows.Alignment = RowAlignment.Center;
            table.Rows.Height = "30mm";
        }

        /// <summary>
        /// Creates row in the centere of the table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        private Table CreateRow(Table table, string[] s)
        {
            Row row = table.AddRow();
            for (int i = 0; i < s.Length; i++)
            {
                row.Cells[i].AddParagraph(s[i]);
                row.Cells[i].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[i].Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Name = "Century Gothic";
            }

            return table;
        }

    }
}
