using System;

namespace Splitix.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            item.InitialNumberOfItems = 2;
            callback(item, null);
        }
    }
}