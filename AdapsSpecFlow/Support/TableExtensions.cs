using System.Data;

namespace AdapsSpecFlow.Support
{
    public static class TableExtensions
    {
        public static DataTable ToDataTable(this Table t)
        {
            var dataTable = new DataTable();

            foreach(var header in t.Header)
            {
                dataTable.Columns.Add(header, typeof(string));

            }
            foreach (var row in t.Rows)
            {
                var newRow = dataTable.NewRow();
                foreach (var header in t.Header)
                {
                    newRow.SetField(header, row[header]);
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

    }
}
