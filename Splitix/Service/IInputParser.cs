using System;
namespace Splitix.Service
{
    public enum Orientation
    {
        ColumnFirst = 0,
        RowFirst = 1
    }
    public enum Axis
    {
        Columns = 0,
        Rows = 1
    }

    public interface IInputParser
    {
        string Parse(string input, int numerOfItems, Axis axis, Orientation orientation);
    }
}
