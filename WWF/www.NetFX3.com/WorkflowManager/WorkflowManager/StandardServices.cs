using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Workflow.ComponentModel;

namespace Microsoft.Workflow.Samples.WorkflowManager
{
    //based on the mode we will have a provider manager that will decide
    //who will give different typed data on request

    //for sql - an array of property name and condition
    //for live - serialized rule to be evaluated against every running instance???

    public interface IDataProvider
    {
        int MaxCount { get; set; }
        ICollection Enumerate(Type type);
        object GetInstance(Type type, Hashtable keys);
        ICollection GetCollectionForWorkflowInstance(Type type, TrackedWorkflowInstance instance);
    }

    #region SQL Tracking provider
    public class SQLTrackingDataProvider : IDataProvider
    {
        public SQLTrackingDataProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private string connectionString = null;
        private SqlConnection connection = null;
        private SqlConnection Connection
        {
            get
            {
                if (this.connection == null)
                    this.connection = new SqlConnection(this.connectionString);

                //user will open and close the connection
                return this.connection;
            }
        }

        private int maxCount = 200;
        public int MaxCount
        {
            get { return this.maxCount; }
            set { this.maxCount = value; }
        }

        public ICollection Enumerate(Type type)
        {
            if (type == null)
                throw new ArgumentException("type is null");

            if (typeof(TrackedEntity).IsAssignableFrom(type))
            {
                ArrayList collection = new ArrayList();
                object[] attributes = type.GetCustomAttributes(typeof(EnumerationSqlStatementAttribute), true);
                if (attributes != null && attributes.Length > 0)
                {
                    EnumerationSqlStatementAttribute sqlStatementAttribute = attributes[0] as EnumerationSqlStatementAttribute;

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlDataReader reader = null;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sqlStatementAttribute.SQL;
                        cmd.Connection = Connection;

                        if (cmd.Connection.State != ConnectionState.Open)
                            cmd.Connection.Open();

                        using (reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (reader.Read())
                            {
                                TrackedEntity instance = Activator.CreateInstance(type, new object[] { this }) as TrackedEntity;
                                instance.Initialize(reader);
                                collection.Add(instance);
                            }
                            reader.Close();
                        }
                    }
                }
                return collection;
            }
            throw new ArgumentException("not supported enumeration");
        }

        public ICollection GetCollectionForWorkflowInstance(Type type, TrackedWorkflowInstance instance)
        {
            if (type == null)
                throw new ArgumentException("type is null");

            if (typeof(TrackedEntity).IsAssignableFrom(type))
            {
                ArrayList collection = new ArrayList();
                object[] attributes = type.GetCustomAttributes(typeof(EnumerationForWorkflowInstanceSqlStatementAttribute), true);
                if (attributes != null && attributes.Length > 0)
                {
                    EnumerationForWorkflowInstanceSqlStatementAttribute sqlStatementAttribute = attributes[0] as EnumerationForWorkflowInstanceSqlStatementAttribute;

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlDataReader reader = null;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sqlStatementAttribute.SQL;
                        cmd.Connection = Connection;

                        cmd.Parameters.Add(new SqlParameter("@workflowInternalInstanceId", instance.WorkflowInstanceInternalId));

                        if (cmd.Connection.State != ConnectionState.Open)
                            cmd.Connection.Open();

                        try
                        {
                            using (reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (reader.Read())
                                {
                                    TrackedEntity trackedInstance = Activator.CreateInstance(type, new object[] { this, instance }) as TrackedEntity;
                                    trackedInstance.Initialize(reader);
                                    collection.Add(trackedInstance);
                                }
                                reader.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            reader.Close();
                            reader.Dispose();
                        }
                    }
                }
                return collection;
            }
            throw new ArgumentException("not supported enumeration");
        }

        public object GetInstance(Type type, Hashtable keys)
        {
            if (type == null || keys == null)
                throw new ArgumentException("type or keys is null");

            if (typeof(TrackedEntity).IsAssignableFrom(type))
            {
                object[] attributes = type.GetCustomAttributes(typeof(GetInstanceSqlStatementAttribute), true);
                if (attributes != null && attributes.Length > 0)
                {
                    GetInstanceSqlStatementAttribute sqlStatementAttribute = attributes[0] as GetInstanceSqlStatementAttribute;

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlDataReader reader = null;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sqlStatementAttribute.SQL;
                        foreach (string paramName in keys.Keys)
                            cmd.Parameters.Add(new SqlParameter(paramName, keys[paramName]));
                        cmd.Connection = Connection;

                        if (cmd.Connection.State != ConnectionState.Open)
                            cmd.Connection.Open();

                        using (reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (reader.Read())
                            {
                                TrackedEntity instance = Activator.CreateInstance(type, new object[] { this }) as TrackedEntity;
                                instance.Initialize(reader);
                                return instance;
                            }
                            reader.Close();
                        }
                    }
                }
                return null;
            }
            throw new ArgumentException("not supported get instance");
        }
    }
    #endregion

    #region Activity State Provider
    public class ActivityStatus
    {
        private ActivityExecutionStatus status;
        private Guid trackingContext;

        public ActivityStatus(ActivityExecutionStatus status, Guid trackingContext)
        {
            this.status = status;
            this.trackingContext = trackingContext;
        }

        public ActivityExecutionStatus Status
        {
            get { return this.status; }
        }

        public Guid TrackingContext
        {
            get { return this.trackingContext; }
        }
    }

    public interface IActivityStateProvider
    {
        //there may be multiple instances of the activity executing in different executors (differentiated by the tracking context id)
        ActivityStatus[] GetActivityState(string qualifiedActivityId);
    }

    public class ActivityStateProvider : IActivityStateProvider
    {
        private List<TrackedActivity> activities;

        public ActivityStateProvider(List<TrackedActivity> activities)
        {
            this.activities = activities;
        }

        public ActivityStatus[] GetActivityState(string qualifiedActivityId)
        {
            //we only need to report the latest event for the activity in every given context
            Dictionary<Guid, ActivityStatus> lastActivityEventInContext = new Dictionary<Guid, ActivityStatus>();
            foreach (TrackedActivity activity in activities)
            {
                if (activity.QualifiedName.Equals(qualifiedActivityId))
                {
                    if (lastActivityEventInContext.ContainsKey(activity.Context))
                        lastActivityEventInContext.Remove(activity.Context);

                    lastActivityEventInContext.Add(activity.Context, new ActivityStatus(activity.Status, activity.Context));
                }
            }

            if (lastActivityEventInContext.Values.Count > 0)
            {
                ActivityStatus[] statuses = new ActivityStatus[lastActivityEventInContext.Values.Count];
                lastActivityEventInContext.Values.CopyTo(statuses, 0);
                return statuses;
            }
            else
                return null;
        }
    }
    #endregion
}