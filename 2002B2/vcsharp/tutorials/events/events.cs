// Events\events.cs
using System;
namespace MyCollections 
{
   using System.Collections;
   // A delegate type for hooking up change notifications.
   public delegate void ChangeDelegate();

   // A class that works just like ArrayList, but sends event
   // notifications whenever the list changes.
   public class ListWithChangeEvent: ArrayList 
   {
      // An event that clients can use to be notified whenever the
      // elements of the list change.
      public event ChangeDelegate Changed;

      // Invoke the Changed event; called whenever list changes
      protected virtual void FireChangeEvent() 
      {
         if (Changed != null)
            Changed();
      }

      // Override some of the methods that can change the list;
      // invoke event after each
      public override int Add(object value) 
      {
         int i = base.Add(value);
         FireChangeEvent();
         return i;
      }

      public override void Clear() 
      {
         base.Clear();
         FireChangeEvent();
      }

      public override object this[int index] 
      {
         set 
         {
            base[index] = value;
            FireChangeEvent();
         }
      }
   }
}

namespace TestEvents 
{
   using MyCollections;

   class EventListener 
   {
      private ListWithChangeEvent List;

      public EventListener(ListWithChangeEvent list) 
      {
         List = list;
         // Add "ListChanged" to the Change event on "List".
         List.Changed += new ChangeDelegate(ListChanged);
      }

      // This will be called whenever the list changes.
      private void ListChanged() 
      {
         Console.WriteLine("This is called when the event fires.");
      }

      public void Detach() 
      {
         // Detach the event and delete the list
         List.Changed -= new ChangeDelegate(ListChanged);
         List = null;
      }
   }

   class Test 
   {
      // Test the ListWithChangeEvent class.
      public static void Main() 
      {
      // Create a new list.
      ListWithChangeEvent list = new ListWithChangeEvent();

      // Create a class that listens to the list's change event.
      EventListener listener = new EventListener(list);

      // Add and remove items from the list.
      list.Add("item 1");
      list.Clear();
      listener.Detach();
      }
   }
}
