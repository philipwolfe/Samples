//Copyright (c) 2006 Jon Flanders - http://www.masteringbiztalk.com/
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
//associated documentation files (the "Software"), to deal in the Software without restriction, 
//including without limitation the rights to use, copy, modify, merge, publish, distribute, 
//sublicense, and/or sell copies of the Software, and to permit persons to whom the Software 
//is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included 
//in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
//INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
//PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
//FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

namespace WorkflowDesignerControl
{
    using System;
    using System.IO;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.ComponentModel.Design.Serialization;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Compiler;
    using System.Workflow.ComponentModel.Design;
    using System.Workflow.ComponentModel.Serialization;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing.Design;
    using System.Xml;
    using System.Web;
    using System.Text;

    #region WorkflowLoader
    internal sealed class WorkflowLoader : WorkflowDesignerLoader
    {
        private string xoml = string.Empty;

        internal WorkflowLoader()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();

            IDesignerLoaderHost host = LoaderHost;
            if (host != null)
            {
                TypeProvider typeProvider = new TypeProvider(host);
                typeProvider.AddAssemblyReference(typeof(string).Assembly.Location);
                host.AddService(typeof(ITypeProvider), typeProvider, true);
            }
        }

        public override void Dispose()
        {
            IDesignerLoaderHost host = LoaderHost;
            if (host != null)
            {

                host.RemoveService(typeof(ITypeProvider), true);
            }

            base.Dispose();
        }




        public string Xoml
        {
            get
            {
                return this.xoml;
            }

            set
            {
                this.xoml = value;
            }
        }




        public override string FileName
        {
            get { return "IThinkThisSucks"; }
        }

        public override TextReader GetFileReader(string filePath)
        {
            if (filePath.EndsWith(".rules"))
            {
                string rulexaml = null;
                object sb = HttpContext.Current.Session["rulexaml"];
                if (sb != null)
                {
                    rulexaml = sb.ToString();
                }
                if (!String.IsNullOrEmpty(rulexaml))
                {
                    return new StringReader(rulexaml);
                }
            }
            return null;
        }

        public override TextWriter GetFileWriter(string filePath)
        {
            if (filePath.EndsWith(".rules"))
            {
                StringBuilder sb = new StringBuilder();
                HttpContext.Current.Session["rulexaml"] = sb;
                StringWriter sw = new StringWriter(sb);
            }
            return null;
        }

        protected override void PerformLoad(IDesignerSerializationManager serializationManager)
        {
            IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
            Activity rootActivity = null;
            TextReader reader = new StringReader(this.xoml);
            try
            {
                using (XmlReader xmlReader = XmlReader.Create(reader))
                {
                    WorkflowMarkupSerializer xomlSerializer = new WorkflowMarkupSerializer();
                    rootActivity = xomlSerializer.Deserialize(xmlReader) as Activity;
                }
            }
            finally
            {
                reader.Close();
            }



            if (rootActivity != null && designerHost != null)
            {
                this.AddActivityToDesigner(rootActivity);
                ServiceContainer sc = new ServiceContainer();
                ValidationErrorCollection errors = new ValidationErrorCollection();
                sc.AddService(typeof(ITypeProvider),this.LoaderHost.GetService(typeof(ITypeProvider)));
                ValidationManager vmanager = new ValidationManager(sc);
                foreach (Validator validator in vmanager.GetValidators(rootActivity.GetType()))
                {
                    foreach (ValidationError ve in validator.Validate(vmanager, rootActivity))
                    {

                        errors.Add(ve);
                    }
                }
                HttpContext.Current.Session["wferrors"] = errors;
            }
        }





    }
    #endregion
}
