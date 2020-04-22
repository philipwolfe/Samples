Stephen Toub
stoub@microsoft.com
7/17/02

----------------------------
ADAPTIVE HUFFMAN COMPRESSION
----------------------------

C# implementation of adaptive Huffman compression.

Example
-------
// Read in the file and write it out compressed
using (FileStream input = new FileStream(@"C:\test.txt", FileMode.Open)) 
{
	using (FileStream output = new FileStream(@"C:\compressed.ahd", FileMode.Create))
	{
		AdaptiveHuffmanProvider.Compress(input, output);
	}
}

Classes
-------
AdaptiveHuffmanCompression.cs classes
	- AdaptiveHuffmanProvider
		- Static methods to help compress and decompress bytes and streams using adaptive Huffman compression
		- Uses AdaptiveHuffmanStream for compression
	- AdaptiveHuffmanStream
		- Stream implementation using adaptive Huffman compression to compress and decompress written and read bytes.
		- Implements both FGK and Vitter algorithms (currently set to use FGK)

BitStream.cs classes
	- BitStream
		- Stream implementation for reading and writing individual bits from and to the stream.
		- Used by AdaptiveHuffmanStream

Enjoy,
Steve