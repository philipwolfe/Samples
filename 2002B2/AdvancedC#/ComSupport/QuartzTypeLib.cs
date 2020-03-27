using System;
using System.Runtime.InteropServices;
 
namespace QuartzTypeLib 
{
	/// <summary>
	/// COM Object Identification for the Media Manager
	/// </summary>
	[ComImport]
	[Guid("E436EBB3-524F-11CE-9F53-0020AF0BA770")] 
    class FilgraphManager 
    { 
    }

	/// <summary>
	/// COM Interface identification for the Media Control Interface
	/// </summary>
	[Guid("56A868B1-0AD4-11CE-B03A-0020AF0BA770")]
    interface IMediaControl 
    { 
		/// <summary>
		/// Run any media loaded
		/// </summary>
        void Run();

		/// <summary>
		/// Pause the player
		/// </summary>
        void Pause();
            
		/// <summary>
		/// Stop the player
		/// </summary>
        void Stop();

		/// <summary>
		/// Not using this method - no need to document the parameters
		/// </summary>
        void GetState();

		/// <summary>
		/// Not using this method - no need to document the parameters
		/// </summary>
        void RenderFile(string  fileName);

		/// <summary>
		/// Not using this method - no need to document the parameters
		/// </summary>
        void AddSourceFilter();

		/// <summary>
		/// Not using this method - no need to document the parameters
		/// </summary>
        void FilterCollection();

		/// <summary>
		/// Not using this method - no need to document the parameters
		/// </summary>
        void RegFilterCollection();
            
		/// <summary>
		/// Not using this method - no need to document the parameters
		/// </summary>
        void StopWhenReady(); 
    }    
} 
