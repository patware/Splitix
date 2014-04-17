using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Splitix.Model
{
    public class DataItem
    {
        public DataItem(string title)
        {
            InitialInput = title;
            InitialNumberOfItems = 3;

        }

        public string InitialInput
        {
            get;
            private set;
        }


        public int InitialNumberOfItems { get; set; }

    }
}
