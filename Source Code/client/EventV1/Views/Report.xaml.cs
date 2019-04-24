using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventV1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Report : ContentPage
	{
		public Report()
		{
			InitializeComponent();
		}

		private void PdfButton_Clicked(object sender, EventArgs e)
		{
          /*  string fileName = "Report.xaml";

            //Convert XAML file to XPS file.
            Stream xpsFile = GetXPSDocument(fileName);
            if (xpsFile != null)
            {
                xpsFile.Position = 0;

                //Initialize XPSToPdfConverter.
                Syncfusion.XPS.XPSToPdfConverter converter = new Syncfusion.XPS.XPSToPdfConverter();

                //Convert XPS document into PDF document.
                PdfDocument document = converter.Convert(xpsFile);

                //Save the Pdf document.
                document.Save("output.pdf");

                //Open the Pdf document
                System.Diagnostics.Process.Start("output.pdf");

                //Close the Pdf document.
                document.Close(true);
            }*/

        }
    

        /// <summary>
        /// Convert the XAML flow document into XPS file
        /// </summary>
       // /// <param name="fileName">Input (XAML) document path</param>
       /* private MemoryStream GetXPSDocument(string fileName)
        {
            //Create visual UIElement.
            UIElement visual = System.Windows.Markup.XamlReader.Load(System.Xml.XmlReader.Create(fileName)) as System.Windows.UIElement;
            FixedDocument doc = new System.Windows.Documents.FixedDocument();
            PageContent pageContent = new System.Windows.Documents.PageContent();
            FixedPage fixedPage = new System.Windows.Documents.FixedPage();

            //Create first page of document
            fixedPage.Children.Add(visual);
            ((System.Windows.Markup.IAddChild)pageContent).AddChild(fixedPage);

            //Adding page content to pages.
            doc.Pages.Add(pageContent);

            //Create the stream.
            MemoryStream stream = new MemoryStream();

            XpsDocument xpsdocument = new XpsDocument(System.IO.Packaging.Package.Open(stream, FileMode.Create));
            XpsDocumentWriter xpswriter = XpsDocument.CreateXpsDocumentWriter(xpsdocument);

            //Write the XPS document.
            xpswriter.Write(doc);

            //Close the XPS document.
            xpsdocument.Close();

            return stream;
        }*/

    }
}