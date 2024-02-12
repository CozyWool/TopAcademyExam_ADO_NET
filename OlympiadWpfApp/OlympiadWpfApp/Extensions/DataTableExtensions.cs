using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace OlympiadWpfApp.Extensions;

public static class DataTableExtensions // https://www.c-sharpcorner.com/UploadFile/ee01e6/different-way-to-convert-datatable-to-list/
{
    public static IList<T> ToList<T>(this DataTable table)
    {
        var data = new List<T>();
        foreach (DataRow row in table.Rows)
        {
            T item = GetItem<T>(row);
            data.Add(item);
        }

        return data;
    }

    private static T GetItem<T>(DataRow row)
    {
        Type temp = typeof(T);
        T obj = Activator.CreateInstance<T>();

        foreach (DataColumn column in row.Table.Columns)
        {
            foreach (PropertyInfo pro in temp.GetProperties())
            {
                if (pro.Name == column.ColumnName)
                    pro.SetValue(obj, row[column.ColumnName], null);
            }
        }

        return obj;
    }
}