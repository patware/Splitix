// -----------------------------------------------------------------------
// <copyright file="InputParser.cs" company="Chambre des communes">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Splitix.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class InputParser : Splitix.Service.IInputParser
    {
        private Dictionary<Splitix.Service.Orientation, Func<IList<string>, string>> _less;
        private Dictionary<Axis, Func<int, int, int>> _ipc;
        private Dictionary<Axis, Func<int, int, int>> _ipr;
        private Dictionary<Splitix.Service.Orientation, Func<IList<string>, string[][], string[][]>> _fill;

        public InputParser()
        {
            _less = new Dictionary<Splitix.Service.Orientation, Func<IList<string>, string>>();

            _less.Add(Splitix.Service.Orientation.ColumnFirst, (s) => string.Join(Environment.NewLine, s));
            _less.Add(Splitix.Service.Orientation.RowFirst, (s) => string.Join("\t", s));

            _ipc = new Dictionary<Axis, Func<int, int, int>>();
            _ipc.Add(Axis.Columns, (c, m) => (int)Math.Ceiling(1.0 * c / m));
            _ipc.Add(Axis.Rows, (c, m) => m);

            _ipr = new Dictionary<Axis, Func<int, int, int>>();
            _ipr.Add(Axis.Columns, (c, m) => m);
            _ipr.Add(Axis.Rows, (c, m) => (int)Math.Ceiling(1.0 * c / m));

            _fill = new Dictionary<Splitix.Service.Orientation, Func<IList<string>, string[][], string[][]>>();
            _fill.Add(Splitix.Service.Orientation.ColumnFirst, (i, t) => fillColumnFirst(i, t));
            _fill.Add(Splitix.Service.Orientation.RowFirst, (i, t) => fillRowFirst(i, t));
            
            
        }

        public string Parse(string input, int numberOfItems, Axis axis, Splitix.Service.Orientation orientation)
        {
            input = string.IsNullOrWhiteSpace(input) ? "Enter something" : input;
            numberOfItems = numberOfItems > 0 ? numberOfItems : 1;

            var items = getItems(input);

            if (items.Count <= numberOfItems)
                return _less[orientation](items);

            var itemsPerRow = _ipr[axis](items.Count, numberOfItems);
            var itemsPerColumn = _ipc[axis](items.Count, numberOfItems);

            var table = buildTable(itemsPerRow, itemsPerColumn);
            table = _fill[orientation](items, table);

            var output = print(table);

            return output;
        }
        #region Privates

        private IList<string> getItems(string input)
        {
            return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string[][] buildTable(int itemsPerRow, int itemsPerColumn)
        {
            var table = new string[itemsPerColumn][];
            for (int r = 0; r < itemsPerColumn; r++)
                table[r] = new string[itemsPerRow];

            return table;
        }

        private string[][] fillColumnFirst(IList<string> items, string[][] table)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var r = i % table.Length;
                var c = (int)Math.Floor(1.0 * i / table.Length);

                table[r][c] = items[i];
            }

            return table;
        }
        private string[][] fillRowFirst(IList<string> items, string[][] table)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var r = (int)Math.Floor(1.0 * i / table[0].Length);
                var c = i % table[0].Length;
                
                table[r][c] = items[i];
            }

            return table;
        }

        private string print(string[][] table)
        {
            var sb = new StringBuilder();

            for (int r = 0; r < table.Length; r++)
            {
                sb.AppendLine(string.Join("\t", table[r]).Trim());
            }

            return sb.ToString().Trim();

        }
        /*
        public string Parse(string input, int numerOfItems, IInputParser.Axis axis, IInputParser.Orientation orientation)
        {
            input = string.IsNullOrWhiteSpace(input) ? "Enter something" : input;
            numerOfItems = numerOfItems > 0 ? numerOfItems : 1;

            var items = getItems(input);
            
            // There's less items than itemsPerColumn, dont stress.
            if (items.Count <= numerOfItems)
            {
                switch (axis)
                {
                    case IInputParser.Axis.Columns:
                        return string.Join(Environment.NewLine, items);

                    case IInputParser.Axis.Rows:
                        return string.Join("\t", items);

                    default:
                        break;
                }
                
            }

            string[][] table;

            switch (axis)
            {
                case IInputParser.Axis.Columns:
                    table = buildTableColumnsAxis(input, numerOfItems);
                    
                case IInputParser.Axis.Rows:
                    table = buildTableRowAxis(input, numerOfItems);

                default:
                    break;
            }

            switch (orientation)
            {
                case IInputParser.Orientation.ColumnFirst:
                    return fillTable
                    break;
                case IInputParser.Orientation.RowFirst:
                    break;
                default:
                    break;
            }
        }

        #region Private parts, dont look

        private string[][] buildTableRowAxis(string input, int itemsPerColumn)
        {


            var itemsPerRow = (int)Math.Ceiling(1.0 * items.Count / itemsPerColumn);

            var table = buildTable(items, itemsPerRow, itemsPerColumn);

            for (int i = 0; i < items.Count; i++)
            {
                var r = i % itemsPerColumn;
                var c = (int)Math.Floor(1.0 * i / itemsPerColumn);

                table[r][c] = items[i];
            }

            return convertTableToString(table);
        }

        private string[][] buildTableColumnsAxis(int columnCount, int numberOfItems)
        {
            
        }

        private string[][] buildTableColumnsAxisOLD(string input, int columnCount)
        {
            input = string.IsNullOrWhiteSpace(input) ? "Enter something" : input;
            columnCount = columnCount > 0 ? columnCount : 1;

            var items = getItems(input);

            // There's less items than itemsPerColumn, dont stress.
            if (items.Count <= columnCount)
            {
                return string.Join("\t", items);
            }

            var itemsPerRow = columnCount;
            var itemsPerColumn = (int)Math.Ceiling(1.0 * items.Count / columnCount);

            var table = buildTable(items, itemsPerRow, itemsPerColumn);

            for (int i = 0; i < items.Count; i++)
            {
                var r = i % itemsPerColumn;
                var c = i / itemsPerColumn;

                table[r][c] = items[i];
            }

            return convertTableToString(table);
        }

        private string[][] buildTable(int itemsPerRow, int itemsPerColumn)
        {
            var table = new string[itemsPerColumn][];
            for (int r = 0; r < itemsPerColumn; r++)
                table[r] = new string[itemsPerRow];

            return table;
        }

        private string convertTableToString(string[][] table)
        {
            var sb = new StringBuilder();

            for (int r = 0; r < table.Length; r++)
            {
                sb.AppendLine(string.Join("\t", table[r]).Trim());
            }

            return sb.ToString().Trim();

        }
         */
        #endregion

    }
}
