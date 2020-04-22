// Stephen Toub
// stoub@microsoft.com
//
// AdaptiveHuffmanCoding.cs
// Classes for performing Adaptive Huffman Coding (both FGK and modified Vitter algorithm).
//		- AdaptiveHuffmanProvider: Static methods used to compress and decompress
//		- AdaptiveHuffmanStream: Stream-based compression and decompression
//
// NOTE:
// Requires BitStream stream class, located in BitStream.cs.
//
// v1.0.0
// July 17th, 2002

#region Namespaces
using System;
using System.IO;
using System.Collections;
using Toub.IO;
#endregion

namespace Toub.Compression
{
	/// <summary>Provides Adaptive Huffman compression and decompression.</summary>
	public class AdaptiveHuffmanProvider
	{
		#region Constants
		/// <summary>Size of the memory buffer to use when reading and writing data.</summary>
		private const int _bufferSize = 2048;
		#endregion

		#region Construction
		/// <summary>Prevent external instantiation.</summary>
		private AdaptiveHuffmanProvider() {}
		#endregion

		#region Public Functions
		#region Compression
		/// <summary>Compress a stream of input data to an output stream.</summary>
		/// <param name="from">The stream containing the data to be compressed.</param>
		/// <param name="to">The stream to which the compressed data should be written.</param>
		/// <remarks>
		/// Reading and writing begins at the current position in both streams.
		/// Reading and writing ends at the end of each stream.
		/// </remarks>
		public static void Compress(Stream from, Stream to)
		{
			// Create a new Huffman stream around the outpt stream and
			// write the bytes to it, reading them portions at a time
			// from the input stream.
			using (AdaptiveHuffmanStream huffman = 
					   new AdaptiveHuffmanStream(to, StreamDirection.Write)) 
			{
				int read;
				byte [] buffer = new byte[_bufferSize];
				while((read = from.Read(buffer, 0, _bufferSize)) > 0) 
				{
					// Write the buffer (what was actually read) to the output stream
					huffman.Write(buffer, 0, read);
				}
			}
		}

		/// <summary>Compress a stream of data to an output stream.</summary>
		/// <param name="s">The input stream to be compressed.</param>
		/// <returns>A stream of compressed data.</returns>
		/// <remarks>
		/// Compression begins at the current position in the input stream.
		/// The resulting stream's position is at the end of the current data.
		/// </remarks>
		public static MemoryStream Compress(Stream s)
		{
			// Create a new memory stream to hold the compressed data
			MemoryStream ms = new MemoryStream();

			// Compress from s to ms
			Compress(s, ms);

			// Return the compressed stream after resetting its position to the beginning
			return ms;
		}

		/// <summary>Compress an array of bytes using adaptive Huffman compression.</summary>
		/// <param name="bytes">The bytes to be compressed.</param>
		/// <returns>The compressed bytes.</returns>
		public static byte [] Compress(byte [] bytes)
		{
			// Create a new memory stream to hold the input uncompressed bytes
			// and one to hold the output compressed bytes
			MemoryStream from = new MemoryStream(bytes);
			MemoryStream to = new MemoryStream();

			// Compress from input to output
			Compress(from, to);

			// Get the compressed bytes and return them
			return to.ToArray();
		}
		#endregion

		#region Decompression
		/// <summary>Decompress a stream of input data to an output stream.</summary>
		/// <param name="from">The stream containing the data to be decompressed.</param>
		/// <param name="to">The stream to which the decompressed data should be written.</param>
		/// <remarks>
		/// Reading and writing begins at the current position in both streams.
		/// Reading and writing ends at the end of each stream.
		/// </remarks>
		public static void Decompress(Stream from, Stream to)
		{
			// Create a new Huffman stream around the compressed stream and
			// read the bytes from it portions at a time from the given stream,
			// writing the decompressed data to the output decompressed stream.
			using (AdaptiveHuffmanStream huffman = 
					   new AdaptiveHuffmanStream(from, StreamDirection.Read)) 
			{
				int read;
				byte [] buffer = new byte[_bufferSize];
				while((read = huffman.Read(buffer, 0, _bufferSize)) > 0) 
				{
					// Write the buffer (what was actually read) to the output stream
					to.Write(buffer, 0, read);
				}
			}
		}

		/// <summary>Decompress a stream of data to an output stream.</summary>
		/// <param name="s">The input stream to be decompressed.</param>
		/// <returns>A stream of decompressed data.</returns>
		/// <remarks>
		/// Decompression begins at the current position in the input stream.
		/// The resulting stream's position is at the end of the current data.
		/// </remarks>
		public static MemoryStream Decompress(Stream compressedStream)
		{
			// Create a new memory stream to hold the decompressed data
			MemoryStream ms = new MemoryStream();

			// Decompress the stream to the memory stream
			Decompress(compressedStream, ms);

			// Return the decompressed stream
			return ms;
		}

		/// <summary>Decompress an array of bytes using adaptive Huffman compression.</summary>
		/// <param name="compressedBytes">The bytes to be decompressed.</param>
		/// <returns>The decompressed bytes.</returns>
		public static byte [] Decompress(byte [] compressedBytes)
		{
			// Create a new memory stream to hold the input compressed bytes
			// and one to hold the output uncompressed bytes
			MemoryStream ms = new MemoryStream(compressedBytes);
			MemoryStream output = new MemoryStream();

			// Create a new Huffman stream around the memory stream and
			// read the bytes from it.
			Decompress(ms, output);

			// Get the compressed bytes and return them
			return output.ToArray();
		}
		#endregion
		#endregion
	}

	/// <summary>Stream that uses adaptive Huffman coding to compress and decompress a stream of bytes.</summary>
	public class AdaptiveHuffmanStream : Stream, IDisposable
	{
		#region Member Variables
		/// <summary>The direction in which this stream is processing bits.</summary>
		private StreamDirection _direction;
		/// <summary>The underlying stream for the bit stream (i.e. a FileStream).</summary>
		private BitStream _bitStream;
		/// <summary>Huffman tree to use for compression and decompression.</summary>
		private AdaptiveHuffmanTree _tree;
		/// <summary>Whether the stream is open.  Used primarily when closing the stream.</summary>
		private bool _open;
		/// <summary>Whether we're at the end of the readable Huffman stream.</summary>
		private bool _eos;
		#endregion

		#region Construction
		/// <summary>Initialize the BitStream.</summary>
		/// <param name="baseStream">The underlying stream for the bit stream.</param>
		/// <param name="direction">The direction of the stream.</param>
		public AdaptiveHuffmanStream(Stream baseStream, StreamDirection direction)
		{
			// Store the direction and create a new bitstream.  We want to make sure that
			// the base stream is not closed when we are (even though the bitstream will be).
			_direction = direction;
			_bitStream = new BitStream(baseStream, direction);
			_bitStream.CloseBaseStream = false;

			// Make sure we can process the underlying stream in the requested direction
			if (direction == StreamDirection.Read && !baseStream.CanRead) 
			{
				throw new ArgumentException("Can't read from the underlying stream.");
			} 
			else if (direction == StreamDirection.Write && !baseStream.CanWrite) 
			{
				throw new ArgumentException("Can't write to the underlying stream.");
			}

			// Setup stream
			_open = true;
			_eos = false;

			// Setup Huffman tree
			_tree = new AdaptiveHuffmanTree();
		}
		#endregion

		#region Properties
		/// <summary>Gets whether we can read bits from this stream.</summary>
		public override bool CanRead { get { return _open && _direction == StreamDirection.Read; } }
        
		/// <summary>Gets whether we can seek on this stream.  Always returns false.</summary>
		public override bool CanSeek { get { return false; } }
        
		/// <summary>Gets whether we can write bits to this stream.</summary>
		public override bool CanWrite { get { return _open && _direction == StreamDirection.Write; } }

		/// <summary>Gets the number of compressd bits processed by the stream (either read or written).</summary>
		public override long Position
		{
			get { return _bitStream.Position; }
			set { throw new NotSupportedException("Can't seek on a compression stream."); }
		}

		/// <summary>Gets whether we're at the end of the Huffman stream.</summary>
		public bool EndOfStream { get { return _eos; } }

		/// <summary>Gets or sets whether to close the base stream when this stream is closed.</summary>
		public bool CloseBaseStream 
		{
			get { return _bitStream.CloseBaseStream; } 
			set { _bitStream.CloseBaseStream = value; } 
		}
		#endregion
        
		#region Writing
		/// <summary>Compresses a byte and writes it to the output stream.</summary>
		/// <param name='value'>The byte to be written.</param>
		public override void WriteByte(byte value)
		{
			// Get the node for the value (or NYT if the value doesn't exist)
			AdaptiveHuffmanTreeNode node = _tree.GetValueNode(value);
			if (node == null) node = _tree.GetNYTNode();

			// Get the encoding for the node and write out all of the bits
			int [] bits = _tree.GetBitEncoding(node);
			_bitStream.Write(bits, 0, bits.Length);

			// If we have an NYT node, then we also need to write out the byte value
			// of the character as it is the first time we're seeing it.
			if (node.Type == AdaptiveHuffmanTreeNodeType.NYT) _bitStream.WriteByte(value);

			// Update the tree to reflect the value
			_tree.UpdateTree(value);
		}
        
		/// <summary>Compresses and writes a buffer's worth of bytes to the output stream.</summary>
		/// <param name='buffer'>The bytes to be written.</param>
		/// <param name='offset'>The position in the array of bytes at which to begin writing.</param>
		/// <param name='count'>The number of bytes to write.</param>
		public override void Write(byte [] buffer, int offset, int count)
		{
			// Write each byte to the output stream.
			for(int i=offset; i<offset+count; i++) WriteByte(buffer[i]);
		}
		#endregion
        
		#region Reading
		/// <summary>Read and decompress a byte from the input stream.</summary>
		/// <returns>The byte read from the input stream; -1 if at the end of the Huffman stream.</returns>
		public override int ReadByte()
		{
			// If we're at the end of the stream, return EOS (-1).
			if (_eos) return -1;

			// Get the root node of the tree
			AdaptiveHuffmanTreeNode node = _tree.RootNode;
			if (node == null) throw new ApplicationException("The tree cannot be empty.");

			// Follow the tree till we reach a leaf
			while(node.LeftChild != null) 
			{
				// Get a bit from the stream
				int bit = _bitStream.ReadBit();
				if (bit < 0)
				{
					// For some reason we hit the end of the stream, so we're done.
					_eos = true;
					return -1;
				}

				// Move along the tree appropriately
				if (bit == 0) node = node.LeftChild;
				else if (bit == 1) node = node.RightChild;
				else throw new ApplicationException("Invalid bit in the stream.");
			}

			// We're at the leaf... if we are at an EOS node, we're done.  Set and return EOS.
			if (node.Type == AdaptiveHuffmanTreeNodeType.EndOfStream) 
			{
				_eos = true;
				return -1;
			}

			// We're at a leaf, so get the byte value for the node.  If the node is an 
			// NYT node, read the next byte as that is the byte to return.  Otherwise, 
			// return the byte represented by this node.  Make sure to update the tree 
			// before doing so.
			int readValue = (node.Type == AdaptiveHuffmanTreeNodeType.NYT) ?
				_bitStream.ReadByte() : node.Value;
			if (readValue < 0) 
			{
				// Something went wrong... set and return EOS.
				_eos = true;
				return readValue;
			}

			// Update the tree with the value
			_tree.UpdateTree((byte)readValue);

			return readValue;
		}
        
		/// <summary>Read and decompress an array of bytes from the input stream.</summary>
		/// <param name='buffer'>The destination buffer for the read bytes.</param>
		/// <param name='offset'>The position in the buffer at which to begin storing the read bytes.</param>
		/// <param name='count'>The number of bytes to read.</param>
		/// <returns>The number of bytes actually read.</returns>
		public override int Read(byte [] buffer, int offset, int count)
		{
			// Read each byte.  If it is valid, store it to the buffer.
			// Otherwise return how many bytes we've already read.  If we read
			// all required bytes, return the requested number.
			for(int i=offset; i<offset+count; i++) 
			{
				int readByte = ReadByte();
				if (readByte >= 0) buffer[i] = (byte)readByte;
				else return i-offset;
			}

			// Return the number of read bytes
			return count;
		}
		#endregion

		#region Other Stream Operations
		/// <summary>Flushes the stream underlying the BitStream.</summary>
		public override void Flush() 
		{ 
			// Just flush the base stream as we don't store any of the bytes
			// in this stream; flushing the base stream is sufficient.
			_bitStream.Flush();
		}
        
		/// <summary>Flushes the underlying stream and closes it.</summary>
		public override void Close() 
		{
			// Only do work if we're still open
			if (_open)
			{
				// If we're writing, add an end of stream marker to denote that we're done.
				if (_direction == StreamDirection.Write) 
				{
					int [] bits = _tree.GetBitEncoding(_tree.GetEOSNode());
					_bitStream.Write(bits, 0, bits.Length);
				}

				// Close the stream and reset the buffers for idealogical reasons.
				// We always want to close the bit stream here; the CloseBaseStream
				// applies to the bit stream's base.
				_bitStream.Close();
				_bitStream = null;
				_open = false;
				_eos = true;
			}
		}
		#endregion

		#region IDisposable and Finalization
		/// <summary>Clean up after the Huffman stream.</summary>
		void IDisposable.Dispose()
		{
			// Close the stream and suppress finalization
			Close();
			GC.SuppressFinalize(this);
		}

		/// <summary>Clean up after the Huffman stream.</summary>
		~AdaptiveHuffmanStream()
		{
			Close();
		}
		#endregion
        
		#region Not Supported Stream Operations
		/// <summary>Not Supported.</summary>
		public override long Length { get { throw new NotSupportedException("Can't seek on a compression stream."); } }
        
		/// <summary>Not Supported.</summary>
		public override void SetLength(long value) 
		{ 
			throw new NotSupportedException("Can't set the length of a compression stream."); 
		}
        
		/// <summary>Not Supported.</summary>
		public override long Seek(long offset, System.IO.SeekOrigin origin)
		{
			throw new NotSupportedException("Can't seek on a compression stream.");
		}
        
		/// <summary>Not Supported.</summary>
		public override void EndWrite(System.IAsyncResult asyncResult)
		{
			throw new NotSupportedException("Can't asynchronously access a compression stream.");
		}
        
		/// <summary>Not Supported.</summary>
		public override System.IAsyncResult BeginWrite(System.Byte[] buffer, int offset, int count, System.AsyncCallback callback, object state)
		{
			throw new NotSupportedException("Can't asynchronously access a compression stream.");
		}
        
		/// <summary>Not Supported.</summary>
		public override int EndRead(System.IAsyncResult asyncResult)
		{
			throw new NotSupportedException("Can't asynchronously access a compression stream.");
		}
        
		/// <summary>Not Supported.</summary>
		public override System.IAsyncResult BeginRead(System.Byte[] buffer, int offset, int count, System.AsyncCallback callback, object state)
		{
			throw new NotSupportedException("Can't asynchronously access a compression stream.");
		}
		#endregion
	}

	/// <summary>Represents a tree for use with adaptive Huffman coding.</summary>
	internal class AdaptiveHuffmanTree
	{
		#region Constants
		/// <summary>The maximum number of leaf nodes we can have (the size of the alphabet we can represent).</summary>
		private const int _alphabetSize = 258; // 256 byte values + EOS + NYT
		/// <summary>The maximum number of possible nodes in the tree.</summary>
		private const int _maxNodes = _alphabetSize * 2;
		/// <summary>The hashtable key for the NYT node.</summary>
		private const string _nytKey = "NYT";
		/// <summary>The hashtable key for the End Of Stream node.</summary>
		private const string _eosKey = "EOS";
		#endregion

		#region Member Variables
		/// <summary>The root node of the adaptive Huffman tree.</summary>
		private AdaptiveHuffmanTreeNode _root;
		/// <summary>A lookup table of all the leaf nodes in the tree for quick access.</summary>
		private Hashtable _nodeTable;
		#endregion

		#region Construction
		/// <summary>Initialize the adaptive Huffman tree.</summary>
		public AdaptiveHuffmanTree()
		{
			// Create the root internal node, the NYT node, and the EOS node.
			_root = new AdaptiveHuffmanTreeNode(AdaptiveHuffmanTreeNodeType.Internal, 0, 1, _maxNodes);
			_root.LeftChild = new AdaptiveHuffmanTreeNode(AdaptiveHuffmanTreeNodeType.NYT, 0, 0, _maxNodes - 2);
			_root.RightChild = new AdaptiveHuffmanTreeNode(AdaptiveHuffmanTreeNodeType.EndOfStream, 0, 1, _maxNodes - 1);

			// Link new nodes back to their parents (the root)
			_root.LeftChild.Parent = _root;
			_root.RightChild.Parent = _root;

			// Initialize the node lookup table
			_nodeTable = new Hashtable(_alphabetSize * 2, .5f);

			// Add the NYT and EOS nodes to the lookup table
			_nodeTable[_nytKey] = _root.LeftChild;
			_nodeTable[_eosKey] = _root.RightChild;
		}
		#endregion

		#region Public Functions
		/// <summary>Updates the tree to reflect a new byte value.</summary>
		/// <param name="value">The byte value with which to update the tree.</param>
		public void UpdateTree(byte value)
		{
			// Find the node that represents the byte value.  
			// If it doesn't exist, add it.
			AdaptiveHuffmanTreeNode current = GetValueNode(value);
			if (current == null) current = AddValueNode(value, 0); // we'll increment the value to 1 later

			// Now work our way up the tree.
			do
			{
				// Get the node in the tree with the highest number and with the same count
				// as the current node.  If that node is different from the current node
				// and is not an ancestor, swap 'em.
				AdaptiveHuffmanTreeNode highest = HighestWithSameCountFGK(current);
				if (current != highest && 
					current.Parent != highest) SwapNodes(current, highest);

				// Increment the count on this node and move up to the parent
				current.Count++;
				current = current.Parent;

			} while(current != null);
		}

		/// <summary>Returns an array of 0's and 1's, the encoding for a node.</summary>
		/// <param name="node">The node for which we want the bit encoding.</param>
		/// <returns>The encoding for a character in the tree.</returns>
		public int [] GetBitEncoding(AdaptiveHuffmanTreeNode node)
		{
			// Create a list to store the bits
			ArrayList list = new ArrayList();

			// Get the bits that make the path up the tree.
			while(node.Parent != null)
			{
				// Get the parent node and determine whether we were a 0 or a 1.
				// Move up the tree.
				list.Add(node.Parent.LeftChild == node ? 0 : 1);
				node = node.Parent;
			}

			// Return the bit array (we need to reverse it first as we inserted them 
			// in the incorrect order).
			list.Reverse();
			return (int[])list.ToArray(typeof(int));
		}

		/// <summary>Gets the node in the tree that represents the given byte.</summary>
		/// <param name="value">The value node for which to search.</param>
		/// <returns>The node if found; null, otherwise.</returns>
		public AdaptiveHuffmanTreeNode GetValueNode(byte value)
		{
			// Lookup the node in the table and return it if found, otherwise null.
			return (AdaptiveHuffmanTreeNode)_nodeTable[value];
		}

		/// <summary>Gets the NYT node in the tree.</summary>
		/// <returns>The NYT node in the tree.</returns>
		public AdaptiveHuffmanTreeNode GetNYTNode()
		{
			// Return the NYT node
			return (AdaptiveHuffmanTreeNode)_nodeTable[_nytKey];
		}

		/// <summary>Gets the End Of Stream node in the tree.</summary>
		/// <returns>The EOS node in the tree.</returns>
		public AdaptiveHuffmanTreeNode GetEOSNode()
		{
			// Return the EOS node
			return (AdaptiveHuffmanTreeNode)_nodeTable[_eosKey];
		}
		#endregion

		#region Tree Manipulation
		/// <summary>Swap two nodes in the tree by fixing references and node numbers.</summary>
		/// <param name="node1">The first node to swap.</param>
		/// <param name="node2">The second node to swap.</param>
		private void SwapNodes(AdaptiveHuffmanTreeNode node1, AdaptiveHuffmanTreeNode node2)
		{
			// Make sure we're not dealing with the root node
			if (node1.Parent == null || node2.Parent == null) throw new ApplicationException("Can't swap root nodes.");
		
			// Swap their node numbers
			int num = node1.Number;
			node1.Number = node2.Number;
			node2.Number = num;

			// We don't need to swap any children, but we do need to swap their parents'
			// references to them.  Note that we have to be careful if both nodes happen
			// to be siblings.
			AdaptiveHuffmanTreeNode oldLeft1 = node1.Parent.LeftChild, oldLeft2 = node2.Parent.LeftChild;
			if (oldLeft1 == node1) node1.Parent.LeftChild = node2;
			else node1.Parent.RightChild = node2;
			if (oldLeft2 == node2) node2.Parent.LeftChild = node1;
			else node2.Parent.RightChild = node1;

			// We also need to swap the references to the parents
			AdaptiveHuffmanTreeNode parent = node1.Parent;
			node1.Parent = node2.Parent;
			node2.Parent = parent;
		}

		/// <summary>Adds a new node to the tree to represent a new byte value.</summary>
		/// <param name="value">The value to add to the tree.</param>
		/// <param name="initialCount">The initial frequency count to store in the node.</param>
		/// <returns>The new value node.</returns>
		private AdaptiveHuffmanTreeNode AddValueNode(byte value, int initialCount)
		{
			// Get the old NYT node
			AdaptiveHuffmanTreeNode oldNYT = GetNYTNode();
	
			// Modify it to be an internal node
			oldNYT.Type = AdaptiveHuffmanTreeNodeType.Internal;
			
			// Create the new NYT node; make sure to link it up correctly to the parent.
			// This node has a number two less than the original.
			oldNYT.LeftChild = 
				new AdaptiveHuffmanTreeNode(AdaptiveHuffmanTreeNodeType.NYT, 0, 0, oldNYT.Number - 2);
			oldNYT.LeftChild.Parent = oldNYT;

			// Create the new byte value node; make sure to link it up correctly to the parent.
			// This node has a number one less than the original.
			oldNYT.RightChild = 
				new AdaptiveHuffmanTreeNode(AdaptiveHuffmanTreeNodeType.Value, value, initialCount, oldNYT.Number - 1);
			oldNYT.RightChild.Parent = oldNYT;

			// Fix up the node table to include both new nodes and the old NYT node
			// as a normal internal node.
			_nodeTable[_nytKey] = oldNYT.LeftChild;
			_nodeTable[value] = oldNYT.RightChild;

			// Return the new value node.
			return oldNYT.RightChild;
		}

		/// <summary>Find the highest-numbered node with the given count. (FGK algorithm)</summary>
		/// <param name="current">The starting node.</param>
		/// <returns>The current node if no higher nodes were found; the higher node, otherwise.</returns>
		/// <remarks>
		/// Use this HighestWithSameCount function to use the FGK algorithm for adaptive
		/// huffman compression method.  The FGK algorithm is often much faster than Vitter's
		/// variation and often produces results just as good; however, in some cases
		/// Vitter's method can produce better compression.
		/// </remarks>
		private AdaptiveHuffmanTreeNode HighestWithSameCountFGK(AdaptiveHuffmanTreeNode current)
		{
			// We'll start by saying that we're the highest
			AdaptiveHuffmanTreeNode highest = current;

			// Now we'll check our sibling to see if he's bigger.  He's the highest
			// if he's to our right and has the same count.
			if (current.Parent != null) 
			{
				// Does our right sibling have the same count?  If yes, he's the highest thus far.
				AdaptiveHuffmanTreeNode parent = current.Parent;
				if (parent.LeftChild == current &&
					parent.RightChild.Count == current.Count) highest = parent.RightChild;
				
				// Now we'll check our parent's siblings.  If his sibling has a higher
				// count, then he's the highest.
				if (parent.Parent != null) 
				{
					AdaptiveHuffmanTreeNode grandparent = parent.Parent;

					// If our parent is the right child, then check the left child's count.
					// If our parent is the left child, then check the right child's count. etc.
					// If one of these siblings has the same count as us, woo hoo!  Movin' on up.
					if (grandparent.LeftChild == parent &&
						grandparent.RightChild.Count == current.Count) highest = grandparent.RightChild;
					else if (grandparent.RightChild == parent &&
						grandparent.LeftChild.Count == current.Count) highest = grandparent.LeftChild;
				}
			}

			// Return the highest one we found
			return highest;
		}

		/// <summary>Find the highest-numbered node with the given count. (Vitter algorithm)</summary>
		/// <param name="current">The node whose count we want to find in the tree.</param>
		/// <returns>The node if found; null if no nodes have the given count.</returns>
		/// <remarks>
		/// Use this HighestWithSameCount function to use Vitter's variation of the adaptive
		/// huffman compression method.  Vitter's variation can produce better compression
		/// than the FGK algorithm, however it is much slower as it can require a full
		/// tree walk on every update to the tree.
		/// </remarks>
		private AdaptiveHuffmanTreeNode HighestWithSameCountVitter(AdaptiveHuffmanTreeNode current)
		{
			// Get the count
			long count = current.Count;

			// Create a queue to hold the nodes and add the root node as the starting node
			Queue levelQueue = new Queue();
			levelQueue.Enqueue(_root);

			// While there are more nodes to look at...
			while(levelQueue.Count > 0) 
			{
				// Get the next node from the queue.  If it is the correct count, return it,
				// as we're processing the nodes in order from highest to lowest number.
				AdaptiveHuffmanTreeNode node = (AdaptiveHuffmanTreeNode)levelQueue.Dequeue();
				if (node.Count == count) return node;

				// Add the right and then the left child; we add the right first as it has
				// a higher number.  And since a node must have two children if it has at least
				// one, we can just check to see if it has one child.
				if (node.RightChild != null) 
				{
					levelQueue.Enqueue(node.RightChild);
					levelQueue.Enqueue(node.LeftChild);
				}
			}

			// Uh oh... couldn't find a node with the given count.
			// Something went wrong as we should have at least found current, assuming
			// it was in the tree, which it should have been.
			return null;
		}
		#endregion

		#region Properties
		/// <summary>Gets the root node of the Huffman tree.</summary>
		public AdaptiveHuffmanTreeNode RootNode { get { return _root; } }
		#endregion

		#region Debugging Functions
		/// <summary>Renders the tree in human readable form for debugging purposes.</summary>
		/// <returns>A string rendering of the tree.</returns>
		internal string Render()
		{
			string text = "";
			if (_root != null) 
			{
				text += "Depth: " + Depth(_root) + Environment.NewLine;
				text += Render(_root, 0);
			}
			return text;
		}

		/// <summary>Renders a node of the tree in human readable form for debugging purposes.</summary>
		/// <param name="node">The node to render.</param>
		/// <param name="level">The indentation level for this node.</param>
		/// <returns>A string rendering of the tree.</returns>
		private string Render(AdaptiveHuffmanTreeNode node, int level)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			// Print information about the node
			sb.Append(PrintTabs(level) + "Type: " + node.Type + Environment.NewLine);
			sb.Append(PrintTabs(level) + "Number: " + node.Number + Environment.NewLine);
			sb.Append(PrintTabs(level) + "Count: " + node.Count + Environment.NewLine);
			sb.Append(PrintTabs(level) + "Value: " + node.Value + 
				"(" + (Char.IsControl((char)node.Value) ? '-' : (char)node.Value) + ")" + Environment.NewLine);
			
			// Print the left child
			if (node.LeftChild != null)
			{
				sb.Append(PrintTabs(level+1) + "---- Left ----" + Environment.NewLine);
				sb.Append(Render(node.LeftChild, level+1));
			}

			// Print the right child
			if (node.RightChild != null) 
			{
				sb.Append(PrintTabs(level+1) + "---- Right ----" + Environment.NewLine);
				sb.Append(Render(node.RightChild, level+1));
			}

			// Return the rendering
			return sb.ToString();
		}

		/// <summary>Creates an indentation string for use in rendering.</summary>
		/// <param name="level">How many levels to indent.</param>
		/// <returns>String full of tabs for indentation to a certain level.</returns>
		private string PrintTabs(int level)
		{
			string tabs = "";
			for(int i=0; i<level; i++) tabs += "\t\t";
			return tabs;
		}

		/// <summary>Gets the depth of the tree starting at a particular node.</summary>
		/// <param name="node">The node for which we're computing the depth.</param>
		/// <returns>The depth starting at the given node.</returns>
		private int Depth(AdaptiveHuffmanTreeNode node)
		{
			// Get the left size and the right size.  Add ourselves to the max of the two.
			if (node == null) return 0;
			int leftDepth = Depth(node.LeftChild);
			int rightDepth = Depth(node.RightChild);
			return 1 + (leftDepth > rightDepth ? leftDepth : rightDepth);
		}

		/// <summary>List all of the values in the tree and their associated weights.</summary>
		/// <returns>A string description of all the values in the tree and their associated weights.</returns>
		private string ListValueNodeCounts()
		{
			// Create a StringBuilder to hold the text
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			// Get all possible byte values that could be in the tree
			for(int b=0; b<256; b++) 
			{
				// Get the node if it exists
				AdaptiveHuffmanTreeNode node = GetValueNode((byte)b);
				if (node != null) 
				{
					// Print out information on the node
					sb.Append(
						"[" + (Char.IsControl((char)node.Value) ? '-' : (char)node.Value) + "]: "
						+ node.Count + Environment.NewLine);
				}
			}

			// Return the information
			return sb.ToString();
		}
		#endregion
	}

	/// <summary>Represents a node in the adaptive Huffman tree.</summary>
	internal class AdaptiveHuffmanTreeNode
	{
		#region Member Variables
		/// <summary>The node number of the node.</summary>
		private int _number;
		/// <summary>The frequency count of the byte value in the node.</summary>
		private long _count;
		/// <summary>The byte value stored in the node.</summary>
		private byte _value;
		/// <summary>The node type of the node.</summary>
		private AdaptiveHuffmanTreeNodeType _type;
		/// <summary>The left child of the node.</summary>
		private AdaptiveHuffmanTreeNode _leftChild;
		/// <summary>The right child of the node.</summary>
		private AdaptiveHuffmanTreeNode _rightChild;
		/// <summary>The parent of the node.</summary>
		private AdaptiveHuffmanTreeNode _parent;
		#endregion

		#region Construction
		/// <summary>Initialize the node.</summary>
		/// <param name="type">The node type of the node.</param>
		/// <param name="value">The byte value to store in the node.</param>
		/// <param name="count">The frequency count of the byte value in the node.</param>
		/// <param name="number">The node number of the node.</param>
		public AdaptiveHuffmanTreeNode(AdaptiveHuffmanTreeNodeType type, byte value, long count, int number)
		{
			// Store the data in the node
			_value = value;
			_number = number;
			_count = count;
			_type = type;
		}
		#endregion

		#region Properties
		/// <summary>Gets or sets the node number of this node.</summary>
		public int Number { get { return _number; } set { _number = value; } }
		/// <summary>Gets or sets the frequency count of this node.</summary>
		public long Count { get { return _count; } set { _count = value; } }
		/// <summary>Gets or sets the byte value of this node.</summary>
		public byte Value { get { return _value; } set { _value = value; } }
		/// <summary>Gets or sets the node type of this node.</summary>
		public AdaptiveHuffmanTreeNodeType Type { get { return _type; } set { _type = value; } }
		/// <summary>Gets or sets the left child of this node.</summary>
		public AdaptiveHuffmanTreeNode LeftChild { get { return _leftChild; } set { _leftChild = value; } }
		/// <summary>Gets or sets the right child of this node.</summary>
		public AdaptiveHuffmanTreeNode RightChild { get { return _rightChild; } set { _rightChild = value; } }
		/// <summary>Gets or sets the parent of this node.</summary>
		public AdaptiveHuffmanTreeNode Parent { get { return _parent; } set { _parent = value; } }
		#endregion
	}
	
	/// <summary>Types of adaptive Huffman tree nodes.</summary>
	internal enum AdaptiveHuffmanTreeNodeType 
	{ 
		/// <summary>Node that represents an Not Yet Transmitted special node marker.</summary>
		NYT,
		/// <summary>Node that represents an End Of Stream special node marker.</summary>
		EndOfStream,
		/// <summary>Node that represents a byte value in the tree.</summary>
		Value,
		/// <summary>Node that represents an internal node, just part of the tree.</summary>
		Internal 
	};
}
