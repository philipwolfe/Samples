using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;
using System.IO;

namespace WebNotes
{

    public class WebNoteCollection : CollectionBase , IEnumerable, ISerializable
    {
        public void Add (WebNote webnote)
        {
            this.List.Add ( webnote );
        }
        public void Remove ( WebNote webnote )
        {
            this.List.Remove ( webnote );
        }

        public WebNote this [int index]
        {
            get
            {
                return ( WebNote ) this.GetItem ( index );
            }
        }
        public new WebNoteEnumerator GetEnumerator ()
        {
            return new WebNoteEnumerator ( this );
        }
        IEnumerator IEnumerable.GetEnumerator ()
        {
            return this.GetEnumerator ();
        }
        private WebNote GetItem ( int index )
        {
            return ( WebNote )this.List [ index ];
        }
        public void GetObjectData ( SerializationInfo info , StreamingContext context )
        {
        }

    }
}
