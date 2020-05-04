using System;
using Windows.Forms.Reports.ReportLibrary;
using System.Windows.Forms;
using Windows.Forms.Reports.BarcodePlugin;

namespace Windows.Forms.Reports.Demo
{
	public class Barcode
	{
		public static void BarcodeReport(UserRep Rep,BarcodePlugin.Barcode BC)
		{
			Rep.BeginReport();
			Rep.Title="Barcode Report";
			Rep.ProgressStart(24);
			Rep.Load(Application.StartupPath+@"..\..\..\Templates\Barcode.SD");

			Rep.SetString("Code1","12345");
			Rep.SetString("Code2","54321");
			Rep.AddBands("Header");

			BC.GetBarCodesByName("Barcode1").Text="12345";
			BC.GetBarCodesByName("Barcode2").Text="54321";

			Rep.BeginPara();
			Rep.SetString("Name","CodeEAN128C");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodeEAN128C;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodeEAN128C;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();
			
			Rep.BeginPara();
			Rep.SetString("Name","Code_2_5_interleaved");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.Code_2_5_interleaved;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.Code_2_5_interleaved;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","Code_2_5_industrial");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.Code_2_5_industrial;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.Code_2_5_industrial;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","Code_2_5_matrix");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.Code_2_5_matrix;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.Code_2_5_matrix;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","Code39");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.Code39;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.Code39;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","Code39Extended");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.Code39Extended;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.Code39Extended;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","Code128A");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.Code128A;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.Code128A;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","Code128B");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.Code128B;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.Code128B;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","Code128C");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.Code128C;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.Code128C;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","Code93");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.Code93;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.Code93;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","Code93Extended");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.Code93Extended;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.Code93Extended;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","CodeMSI");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodeMSI;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodeMSI;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","CodePostNet");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodePostNet;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodePostNet;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","CodeCodabar");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodeCodabar;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodeCodabar;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","CodeEAN8");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodeEAN8;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodeEAN8;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","CodeEAN13");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodeEAN13;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodeEAN13;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","CodeUPC_A");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodeUPC_A;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodeUPC_A;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","CodeUPC_E0");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodeUPC_E0;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodeUPC_E0;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","CodeUPC_E1");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodeUPC_E1;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodeUPC_E1;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","CodeUPC_Supp2");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodeUPC_Supp2;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodeUPC_Supp2;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","CodeUPC_Supp5");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodeUPC_Supp5;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodeUPC_Supp5;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","CodeEAN128A");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodeEAN128A;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodeEAN128A;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","CodeEAN128B");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodeEAN128B;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodeEAN128B;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();

			Rep.BeginPara();
			Rep.SetString("Name","CodeEAN128C");
			BC.GetBarCodesByName("Barcode1").Typ=BarcodeType.CodeEAN128C;
			BC.GetBarCodesByName("Barcode2").Typ=BarcodeType.CodeEAN128C;
			Rep.AddBands("Band 1").Height=BC.GetBarCodesByName("Barcode1").Height;
			Rep.AddBands("Band 2").Height=BC.GetBarCodesByName("Barcode2").Height;
			Rep.ProgressStep();
			Rep.ProgressStop();
			Rep.ShowReport();
		}
	}
}
