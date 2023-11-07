namespace DoublyLinkedListProject
{
    class DoublyLinkedList
    {
        public ListNode HEAD {set; get;}
        public ListNode TAIL {set;get;}
        public int Size {set;get;}

        // constructor
        public DoublyLinkedList() {}

        public static DoublyLinkedList CreateDoublyLinkedList()
        {
            return new DoublyLinkedList();
        }

        public void InsertFront(char c)
        {
            ListNode newNode = new ListNode();
            newNode.item = c;
            newNode.times++;

            newNode.next = HEAD;
            newNode.prev = null;

            HEAD = newNode;
            TAIL = (TAIL == NULL) ? newNode : TAIL;

            Size++;
        }

        public void InsertEnd(char c)
        {
            ListNode newNode = new ListNode();
            newNode.item = c;
            newNode.times++;
            newNode.next = null;
            newNode.prev = TAIL;

            if (ListSize() != 0)
            {
                TAIL.next = newNode;
                TAIL = newNode;
            } 
            else
            {
                InsertFront(c);
            }
            Size++;
        }

        public void RemoveFront()
        {
            if (HEAD != null)
            {
                HEAD = HEAD.next;
            } 
            else
            {
                throw new EmptyListException();
            }
            if (HEAD == null) TAIL = null;
            
            Size--;
        }

        public void RemoveEnd()
        {
            if (TAIL != null)
            {
                TAIL = TAIL.prev;
            }
            else
            {
                throw new EmptyListException();
            }

            if (TAIL == null) HEAD = null;

            Size--;
        }

        public int ListSize()
        {
            return Size;
        }

        public bool charExists(char ch, out ListNode pivot)
        {
            bool found = false;
            pivot = null;

            if (this.ListSize() != 0)
            {
                ListNode tmp = HEAD;

                while (!found && tmp != null)
                    if (tmp.item == ch)
                    {
                        found = true;
                        pivot = tmp;
                    } 
                    else tmp = tmp.next;
            }
            return found;
        }

        public void Traverse (int charCount)
        {
            for (ListNode i = HEAD; != null; i = i.next)
            {
                if (!(i.item == ' ')) Console.Write(i.item + " ");
                else Console.Write("KENO" + " ");
                Console.WriteLine("{0:P}", i.items / (float) charCount);
            }
        }

        public void increaseCharNum(ListNode listNode)
        {
            listNode.times++;
        }

        public void SortByCharName()
        {
            ListNode j = null, piv = null;
            char min;

            for (ListNode i = HEAD; i != null; i = i.next)
            {
                min = Convert.ToChar(127);
                for (j = i; j != null; j = j.next)
                    if (j.item < min)
                    {
                        min = j.item;
                        piv = j;
                    }
                Swap(i, piv);
            }
        }

        public void SortByCharFrequency()
        {
            ListNode j = null, piv = null;

            for (ListNode i = HEAD; i != null; i = i.next)
            {
                int max = Int32.MinValue;
                for (j = i; j != null; j = j.next)
                    if (j.times > max)
                    {
                        max = j.times;
                        piv = j;
                    }
                Swap(i, piv);
            }
        }

        private void Swap(ListNode i, listNode j)
        {
            char tmpChar = i.item;
            int tmpNum = i.times;

            i.item = j.item;
            i.times = j.times;
            j.item = tmpChar;
            j.times = tmpNum;
        }
    }
}