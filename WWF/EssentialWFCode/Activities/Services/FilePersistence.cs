using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.ComponentModel.Serialization;

namespace EssentialWF.Services {
  
    public class FilePersistenceService : WorkflowPersistenceService {
    private string location;
    private bool unloadOnIdle = false;

    public string Location {
      get { return this.location; }
    }

    protected override bool UnloadOnIdle(Activity activity) {
      return this.unloadOnIdle;
    }

    public FilePersistenceService(string location) {
      this.location = location;
    }

    public FilePersistenceService(string location, bool unloadOnIdle) {
      this.location = location;
      this.unloadOnIdle = unloadOnIdle;
    }

    string BuildFilePath(Guid ctxid) {
      return Path.Combine(this.Location, ctxid.ToString() + ".bin");
    }

    protected override Activity LoadCompletedContextActivity(Guid ctxId, Activity outerActivity) {
      return Load(ctxId, outerActivity);
    }

    protected override Activity LoadWorkflowInstanceState(Guid instanceId) {
      return Load(instanceId, null);
    }

    protected override void SaveCompletedContextActivity(Activity ctxActivity) {
      this.Save(ctxActivity, true);
    }

    protected override void SaveWorkflowInstanceState(Activity rootActivity, bool unlock) {
      this.Save(rootActivity, unlock);
    }

    void Save(Activity activity, bool unlock) {
      Guid ctxid = (Guid)activity.GetValue(Activity.ActivityContextGuidProperty);

      string filePath = this.BuildFilePath(ctxid);

      if (File.Exists(filePath))
        File.Delete(filePath);

      using (FileStream fs = new FileStream(filePath,FileMode.CreateNew)) {
        IFormatter formatter = new BinaryFormatter();
        formatter.SurrogateSelector = ActivitySurrogateSelector.Default;

        activity.Save(fs, formatter);
      }

      if (!unlock)
        File.SetAttributes(filePath, FileAttributes.ReadOnly);
    }

    Activity Load(Guid ctxid, Activity outerActivity) {
      string filePath = this.BuildFilePath(ctxid);

      using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
        fs.Seek(0, SeekOrigin.Begin);
        IFormatter formatter = new BinaryFormatter();
        formatter.SurrogateSelector = ActivitySurrogateSelector.Default;

        return Activity.Load(fs, outerActivity, formatter);
      }
    }

    protected override void UnlockWorkflowInstanceState(Activity rootActivity) {
      Guid ctxid = (Guid)rootActivity.GetValue(Activity.ActivityContextGuidProperty);
      string filePath = this.BuildFilePath(ctxid);
      using (FileStream fs = new FileStream(filePath, FileMode.Open))
        File.SetAttributes(filePath, FileAttributes.Normal);
    }
  }
}
