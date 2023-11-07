using System;

namespace DoublyLinkedListProject
{
    class EmptyListException : Exception
    {
        public EmptyListException() : base ("Η λίστα είναι κενή.")
        {

        }
    }
}