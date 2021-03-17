using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
   public class Note
    {
        public int x;
        public Note next;

        public Note(int data)
        {
            x = data;
            next = null;
        }

        
    }
}
