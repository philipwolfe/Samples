using System;
using System.Reflection; // For Missing.Value and BindingFlags
using System.Runtime.InteropServices; // For COMException
using Excel;

class AutoExcel {
	public static int Main() {
	
		Console.WriteLine ("Creating new Excel.Application");
		Application app = new Application();
		if (app == null) {
			Console.WriteLine("ERROR: EXCEL couldn't be started!");
			return 0;
		}
		
		Console.WriteLine ("Making application visible");		
		// The following line is the temporary workaround for the LCID problem
		// Ideally this line should look like app.Visible = true;
		app.set_Visible(0, true); // LCID = 0 here
		
		Console.WriteLine ("Getting the workbooks collection");
		Workbooks workbooks = app.Workbooks;

		Console.WriteLine ("Adding a new workbook");
		
		// The following line is the temporary workaround for the LCID problem
		_Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet, 0); // LCID = 0 here

		Console.WriteLine ("Getting the worksheets collection");
		Sheets sheets = workbook.Worksheets;

		_Worksheet worksheet = (_Worksheet) sheets.get_Item("Sheet1");
		if (worksheet == null) {
			Console.WriteLine ("ERROR: worksheet == null");
		}
		
		Console.WriteLine ("Setting the value for cell");
		
		// This paragraph puts the value 5 to the cell G1
	    Range range1 = worksheet.get_Range("G1", Missing.Value);
		if (range1 == null) {
			Console.WriteLine ("ERROR: range == null");
		}
		const int nCells = 5;
		Object[] args1 = new Object[1];
		args1[0] = nCells;
		range1.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, range1, args1);
		
		// This paragraph sends single dimension array to Excel
	    Range range2 = worksheet.get_Range("A1", "E1");
		int[] array2 = new int [nCells];
		for (int i=0; i < array2.GetLength(0); i++) {
			array2[i] = i+1;
		}
		Object[] args2 = new Object[1];
		args2[0] = array2;
		range2.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, range2, args2);
	    
		// This paragraph sends two dimension array to Excel
	    Range range3 = worksheet.get_Range("A2", "E3");
		int[,] array3 = new int [2, nCells];
		for (int i=0; i < array3.GetLength(0); i++) {
			for (int j=0; j < array3.GetLength(1); j++) {
				array3[i, j] = i*10 + j;
			}
		}
		Object[] args3 = new Object[1];
		args3[0] = array3;
		range3.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, range3, args3);
	    
		// This paragraph reads two dimension array from Excel
	    Range range4 = worksheet.get_Range("A2", "E3");
		Object[,] array4;
		array4 = (Object[,])range4.GetType().InvokeMember("Value", BindingFlags.GetProperty, null, range4, null);
		
		for (int i=array4.GetLowerBound(0); i <= array4.GetUpperBound(0); i++) {
			for (int j=array4.GetLowerBound(1); j <= array4.GetUpperBound(1); j++) {
				if ((double)array4[i, j] != array3[i-1, j-1]) {
					Console.WriteLine ("ERROR: Comparison FAILED!");
					return 0;
				}
			}
		}

		// This paragraph fills two dimension array with points for two curves and sends it to Excel
	    Range range5 = worksheet.get_Range("A5", "J6");
		double[,] array5 = new double[2, 10];
		for (int j=0; j < array5.GetLength(1); j++) {
			double arg = Math.PI/array5.GetLength(1) * j;
			array5[0, j] = Math.Sin(arg);
			array5[1, j] = Math.Cos(arg);
		}
		Object[] args5 = new Object[1];
		args5[0] = array5;
		range5.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, range5, args5);
		
		// The following code draws the chart
		
		// The following line looks so long, instead of just "range5.Select();" ,
		// because Range is dispinterface and supports only late binding
		range5.GetType().InvokeMember("Select", BindingFlags.InvokeMethod, null, range5, null);

		ChartObjects chartobjects = (ChartObjects) worksheet.ChartObjects(Missing.Value, 0);
		
		Object[] args6 = new Object[4];
		args6[0] = 10; // Left
		args6[1] = 100; // Top
		args6[2] = 450; // Width
		args6[3] = 250; // Height
		ChartObject chartobject = (ChartObject) chartobjects.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, chartobjects, args6);
		_Chart chart = (_Chart) chartobject.GetType().InvokeMember("Chart", BindingFlags.GetProperty, null, chartobject, null);
		
		Object[] args7 = new Object[11];
		args7[0] = range5; // Source
		args7[1] = XlChartType.xl3DColumn; // Gallery
		args7[2] = Missing.Value; // Format
		args7[3] = XlRowCol.xlRows; // PlotBy
		args7[4] = 0; // CategoryLabels
		args7[5] = 0; // SeriesLabels
		args7[6] = true; // HasLegend
		args7[7] = "Sample Chart"; // Title
		args7[8] = "Sample Category Type"; // CategoryTitle
		args7[9] = "Sample Value Type"; // ValueTitle
		args7[10] = Missing.Value; // ExtraTitle
		// The last parameter is lcid, but as we use late binding here it should be omited
		//args7[11] = 0; // lcid
		chart.GetType().InvokeMember("ChartWizard", BindingFlags.InvokeMethod, null, chart, args7);
	    
		Console.WriteLine ("Press ENTER to finish the sample:");
		Console.ReadLine();		
		
		try {
			// If user interacted with Excel it will not close when the app object is destroyed, so we close it explicitely
			workbook.set_Saved(0, true); // To be able to close it without being asked to save it // LCID = 0 here
			app.UserControl = false;
			app.Quit();
		} catch (COMException) {
			Console.WriteLine ("User closed Excel manually, so we don't have to do that");
		}
		
		// The following line is the temporary workaround to make sure the app object is released.
		GC.Collect();
		
		Console.WriteLine ("Sample successfully finished!");
		return 100;
	}
}
