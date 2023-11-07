using System;
using System.IO;

namespace DoublyLinkedListProject
{
    class FileDemo
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList myList = new DoublyLinkedList();
            ListNode pivot = null;
            StreamReader reader;
            char ch;
            int totalChars = 0;

            try
            {
                // In the place of dots insert your file path
                string file = @"...";
                if (!File.Exists(file))
                {
                    Console.WriteLine("Το αρχείο δεν υπάρχει.")
                    Environment.Exit(-1);
                }

                reader = new StreamReader(file);

                while (reader.Peek() >= 0)
                {
                    ch = (char) reader.Read();

                    if (Convert.ToInt32(ch) != 13)
                    {
                        if (myList.charExists(ch, out pivot))
                        {
                            myList.increaseCharNum(pivot);
                        }
                        else
                        {
                            myList.InsertEnd(ch);
                        }
                        totalChars++;
                    }
                    else 
                    {
                        reader.Read();
                    }
                }

                Console.WriteLine("ΤΑΞΙΝΟΜΗΣΗ ΩΣ ΠΡΟΣ ΤΟΥΣ ΧΑΡΑΚΤΗΡΕΣ.");
                myList.SortByCharName();
                myList.Traverse(totalChars);

                Console.WriteLine("\n\nΤΑΞΙΝΟΜΗΣΗ ΩΣ ΠΡΟΣ ΤΗΝ ΣΥΧΝΟΤΗΤΑ.");
                myList.SortByCharFrequency();
                myList.Traverse(totalChars);

                reader.Close();
            }
            catch (FileNotFoundException e1)
            {
                Console.WriteLine("Το αρχείο δεν βρέθηκε: {0}", e1.ToString());
            }
            catch (IOException e2)
            {
                Console.WriteLine("Το αρχείο δεν βρέθηκε: {0}", e2.ToString());
            }
        }
    }
}