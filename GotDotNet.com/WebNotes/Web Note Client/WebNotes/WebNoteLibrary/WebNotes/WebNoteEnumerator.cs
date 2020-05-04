using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace WebNotes
{
    public class WebNoteEnumerator : IEnumerator
    {
        private int index;
        private WebNoteCollection webnotecollection;
        public WebNoteEnumerator ( WebNoteCollection webnotecollection )
        {
            this.webnotecollection = webnotecollection;
        }
        public void Reset ()
        {
            this.index = -1;
        }
        public bool MoveNext ()
        {
            this.index++;
            return ( this.index < this.webnotecollection.Count );
        }
        public WebNote Current
        {
            get
            {
                return ( ( WebNote) this.webnotecollection [this.index] );
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return ( Current );
            }
        } 


    }
}
