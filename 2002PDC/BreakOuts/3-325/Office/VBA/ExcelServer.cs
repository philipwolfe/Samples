using System;

public class ExcelServer {
	private int count = 5; // Number of cells in a row we are going to send to the Client (Excel)
	public int Count {
		get {
			return count;
		} set {
			count = value;
		}
	}
	
	public int[] GetArray() {
		int[] array = new int [count];
		for (int i=0; i < array.GetLength(0); i++) {
			array[i] = i+1;
		}
		return array;
	}
	
	public int[,] GetTwoDimArray() {
		int[,] array = new int [2, count];
		for (int i=0; i < array.GetLength(0); i++) {
			for (int j=0; j < array.GetLength(1); j++) {
				array[i, j] = i*10 + j;
			}
		}
		return array;
	}
}
