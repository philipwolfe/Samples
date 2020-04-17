using System;
using System.Configuration;
using System.Windows.Forms;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Serialization;
using System.Xml;
using Microsoft.Workflow.Samples.Administration;

namespace HostForm
{
    public partial class DocReviewForm : Form
    {
        private WinOEHost winOEHost = null;
        private Type workflowType1 = typeof(ActivityLibrary1.Activity1);
        private Type workflowType2 = typeof(ActivityLibrary1.Workflow1);
        private string trackingConnectionString = string.Empty;//"Initial Catalog=MyTrackingDb;Server=localhost;Integrated Security=SSPI;";

        public DocReviewForm()
        {
            InitializeComponent();
            this.startHost.Enabled = false;
        }

        private void DocReviewForm_Load(object sender, EventArgs e)
        {
            ReadConfiguration();
            this.startHost.Enabled = true;

            startHost_Click(this, EventArgs.Empty);
            //startInstance1_Click(this, EventArgs.Empty);
        }

        private void ReadConfiguration()
        {
            //getting workflow type 1 for instantiation by the sample host form
            try
            {
                WorkflowActivityType activateWorkflowTypeOne = ConfigurationManager.GetSection("Microsoft.Workflow.Samples.DynamicUpdate/activateWorkflowTypeOne") as WorkflowActivityType;
                if (activateWorkflowTypeOne != null)
                    this.workflowType1 = Type.GetType(activateWorkflowTypeOne.TypeName + ", " + activateWorkflowTypeOne.Assembly, false);
            }
            catch
            {
                this.workflowType1 = null;
            }

            //getting workflow type 2 for instantiation by the sample host form
            try
            {
                WorkflowActivityType activateWorkflowTypeTwo = ConfigurationManager.GetSection("Microsoft.Workflow.Samples.DynamicUpdate/activateWorkflowTypeTwo") as WorkflowActivityType;
                if (activateWorkflowTypeTwo != null)
                    this.workflowType2 = Type.GetType(activateWorkflowTypeTwo.TypeName + ", " + activateWorkflowTypeTwo.Assembly, false);
            }
            catch
            {
                this.workflowType2 = null;
            }

            //getting connection string for the host to track live instances
            try
            {
                SqlConnectionInfo liveTrackingDatabase = ConfigurationManager.GetSection("Microsoft.Workflow.Samples.DynamicUpdate/liveTrackingDatabase") as SqlConnectionInfo;
                if (liveTrackingDatabase != null && liveTrackingDatabase.ConnectionString != null && liveTrackingDatabase.ConnectionString.Length > 0)
                    this.trackingConnectionString = liveTrackingDatabase.ConnectionString;
            }
            catch
            {
                this.trackingConnectionString = null;
            }
        }

        private void startHost_Click(object sender, EventArgs e)
        {
            this.startHost.Enabled = false;

            StartHost();

            this.startInstance1.Enabled = true;
            this.startInstance2.Enabled = true;
        }

        const string xomlFileName1 = @"serialized1.xoml";
        private void startInstance1_Click(object sender, EventArgs e)
        {
            SequenceActivity seq1 = new SequentialWorkflowActivity("seq1");

            ParallelActivity parallel1 = new ParallelActivity("parallel1");
            seq1.Activities.Add(parallel1);

            SequenceActivity sequence1 = new SequenceActivity("sequence1");
            SequenceActivity sequence2 = new SequenceActivity("sequence2");
            parallel1.Activities.Add(sequence1);
            parallel1.Activities.Add(sequence2);

            SuspendActivity suspend1 = new SuspendActivity("suspend1");
            sequence1.Activities.Add(suspend1);

            DelayActivity delay1 = new DelayActivity("delay1");
            delay1.TimeoutDuration = new TimeSpan(0, 0, 0, 5);
            sequence2.Activities.Add(delay1);

            WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
            using (XmlWriter sw = XmlWriter.Create(xomlFileName1))
            {
                serializer.Serialize(sw, seq1);
            }

            using (XmlReader xmlReader = XmlReader.Create(xomlFileName1))
            {
                this.winOEHost.InstanceService.CreateWorkflow(xmlReader).Start();
            }

            //if (this.workflowType1 != null)
            //    this.winOEHost.InstanceService.CreateWorkflow(this.workflowType1).Start();
            //else
            //    MessageBox.Show("Workflow type 1 was not correctly specified in the config file");
        }

        private void startInstance2_Click(object sender, EventArgs e)
        {
            if (this.workflowType2 != null)
                this.winOEHost.InstanceService.CreateWorkflow(this.workflowType2).Start();
            else
                MessageBox.Show("Workflow type 2 was not correctly specified in the config file");
        }

        private void StartHost()
        {
            this.winOEHost = new WinOEHost(this.trackingConnectionString);
            this.winOEHost.LiveAdministrationEnabled = true;

            this.winOEHost.InitializeRuntime();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (this.winOEHost != null)
                this.winOEHost.Shutdown();
        }
    }
}