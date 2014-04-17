using System;
using Splitix.Model;

namespace Splitix.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("A\r\nB\r\nC\r\nD\r\nE");
            callback(item, null);
        }
    }
}