using System;
using System.Resources;


namespace Microsoft.Samples.Windows.Forms.ClickOnce.BackgroundUpdateDemo
{
    //=----------------------------------------------------------------------=
    // BackgroundUpdateDemoMain
    //=----------------------------------------------------------------------=
    /// <summary>
    /// This class holds global routines for our sample, and doesn't actualy
    /// contain any instance members.  The static routines are useful for such
    /// things as getting localized reosurces, etc.
    /// </summary>
    /// 
    public class BackgroundUpdateDemoMain
    {
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                    Private Members/Types/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        /// 
        /// <summary>
        /// The resource manager with which we will work for this dialog, 
        /// particularly for loading in error strings, etc.
        /// </summary>
        /// 
        private static ResourceManager s_resourceManager;


		private const string RESFILE_NAMESPACE = "Microsoft.Samples.Windows.Forms.ClickOnce.BackgroundUpdateDemo.BackgroundUpdateDemoResources";


        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //           Publicly Consumable Methods/Functions/Properties
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=


        //=------------------------------------------------------------------=
        // GetResourceManager
        //=------------------------------------------------------------------=
        /// <summary>
        /// Loads in the resource manager for this library if we haven't done
        /// so already.  This just loads in the .resx file containing our 
        /// primary set of localized resources, such as error strings, etc.
        /// </summary>
        /// 
        /// <returns>
        /// A System.Resources.ResourceManager object
        /// </returns>
        /// 
        public static ResourceManager GetResourceManager()
        {
            System.Type t;

            //
            // load in the resource manager if we have not yet done so.
            //
            if (s_resourceManager == null)
            {
				t = typeof(Microsoft.Samples.Windows.Forms.ClickOnce.BackgroundUpdateDemo.BackgroundUpdateDemoForm);
                s_resourceManager = new ResourceManager(RESFILE_NAMESPACE, t.Assembly);
            }

            System.Diagnostics.Debug.Assert(s_resourceManager != null);

            //
            // now we return what we have.  We'd have thrown an exception
            // if we didn't have this yet.
            //
            return s_resourceManager;
        }

    }
}
