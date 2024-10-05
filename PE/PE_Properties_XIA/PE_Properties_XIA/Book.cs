using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Properties_XIA
{
    internal class Book
    {
        //Declare fields
        private string title;
        private string author;
        private int numberOfPages;
        private string owner;
        private int totalTimes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">Book title</param>
        /// <param name="author">Book author</param>
        /// <param name="numberOfPages">Number of book pages</param>
        /// <param name="owner">Book owner</param>
        public Book(string title, string author, int numberOfPages, string owner)
        {
            this.title = title; 
            this.author = author;
            this.numberOfPages = numberOfPages;
            this.owner = owner;

            //Set total read times to 0
            totalTimes = 0;
        }


        /// <summary>
        /// Return the book title
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
        }


        /// <summary>
        /// Return the book author
        /// </summary>
        public string Author
        {
            get
            {
                return author;
            }
        }


        /// <summary>
        /// Return the number of book pages
        /// </summary>
        public int NumberOfPages
        {
            get
            {
                return numberOfPages;
            }
        }


        /// <summary>
        /// Return the book owner,
        /// set the new owner when new input is not empty
        /// </summary>
        public string Owner
        {
            get
            {
                return owner;
            }

            set
            {
                //Set the value only when the value is not an empty string
                if (value != String.Empty)
                {
                    owner = value;
                }
            }
        }


        /// <summary>
        /// Return the total times this book is read,
        /// set the new total times when the new value is bigger
        /// </summary>
        public int TotalTimes
        {
            get
            {
                return totalTimes;
            }

            set
            {
                //if the new value is bigger, set it as new read times
                if (totalTimes < value)
                {
                    totalTimes = value;
                }
            }
        }


        /// <summary>
        /// Print out all the information of the book.
        /// </summary>
        public void Print()
        {
            Console.WriteLine(" - Book Title: {0}", title);
            Console.WriteLine(" - Author: {0}", author);
            Console.WriteLine(" - Number of Pages: {0}", numberOfPages);
            Console.WriteLine(" - Book Owner: {0}", Owner);
            Console.WriteLine(" - The book has been read for {0} times.", totalTimes);
        }
    }
}
