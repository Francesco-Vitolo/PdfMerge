using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.IO;

namespace PdfSharp_merge
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\test";
            string newFile = $@"{path}\merged.pdf";
            string[] PdfFiles = Directory.GetFiles(path, "*.pdf", SearchOption.TopDirectoryOnly);
            PdfDocument document = new PdfDocument();

            foreach (string pdfFile in PdfFiles)
            {
                PdfDocument inputPDFDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);
                document.Version = inputPDFDocument.Version;
                foreach (PdfPage page in inputPDFDocument.Pages)
                {
                    document.AddPage(page);
                }
            }
            if (File.Exists(newFile))
            {
                File.Delete(newFile);
            }            
            document.Save(newFile);
            Console.WriteLine($"{newFile} wurde erstellt");
            Console.ReadKey();
        }
    }
}
