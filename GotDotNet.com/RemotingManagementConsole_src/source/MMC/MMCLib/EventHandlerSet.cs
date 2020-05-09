using System;
using System.Collections;

namespace Ironring.Management.MMC
{
	/// <summary>
	/// Manages event/delegate list pairs for many event.
	/// Used when an object supports many events that are 
	/// registered sparsely if at all.  This method prevents
	/// excessive overhead if no one registers for the event.
	/// </summary>
    public class EventHandlerSet : IDisposable
    {
        /// <summary>
        /// The hash table that stores event key/delegate value pairs
        /// </summary>
        protected Hashtable m_events = new Hashtable();

        /////////////////////////////////////////////////////////////////
        ///
        /// Implementation
        ///

        /// <summary>
        /// get and set events in the set
        /// </summary>
        public virtual Delegate this[object eventKey]
        {
            get { return (Delegate)m_events[eventKey]; }
            set { m_events[eventKey] = value; }
        }

        /// <summary>
        /// Adds a delegate for the indicated event key
        /// </summary>
        /// <param name="eventKey"></param>
        /// <param name="handler"></param>
        public virtual void AddHandler(object eventKey, Delegate handler)
        {
            m_events[eventKey] = Delegate.Combine((Delegate)m_events[eventKey], handler);
        }

        /// <summary>
        /// Remove the delegate with the given key
        /// </summary>
        /// <param name="eventKey"></param>
        /// <param name="handler"></param>
        public virtual void RemoveHandler(object eventKey, Delegate handler)
        {   
            m_events[eventKey] = Delegate.Remove((Delegate)m_events[eventKey], handler);
        }

        /// <summary>
        /// Fire the delegate for the event hash code 
        /// </summary>
        /// <param name="eventKey"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Fire(object eventKey, object sender, EventArgs e)
        {
            Delegate d = (Delegate)m_events[eventKey];
            if (d != null)
            {
                object [] args = new object[] {sender, e};
                d.DynamicInvoke(args);
            }
        }

        /// <summary>
        /// cleanup 
        /// </summary>
        public void Dispose()
        {
            m_events = null;
        }
    }

}
