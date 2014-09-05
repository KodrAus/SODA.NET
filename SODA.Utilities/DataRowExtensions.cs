using System.Data;

namespace SODA.Utilities
{
    /// <summary>
    /// Extension methods for working with a <see cref="System.Data.DataRow"/>.
    /// </summary>
    public static class DataRowExtensions
    {
        /// <summary>
        /// Searches the data row for the first field among the provided field names.
        /// </summary>
        /// <param name="row">A data row.</param>
        /// <param name="fieldsToLookFor">A collection of field names to search for.</param>
        /// <returns>The value of the first matched field, or null.</returns>
        public static string SelectFirstOneOf(this DataRow row, params string[] fieldsToLookFor)
        {
            string result = null;

            if (row != null)
            {
                var columns = row.Table.Columns;

                if (fieldsToLookFor != null)
                {
                    foreach (string field in fieldsToLookFor)
                    {
                        if (columns.Contains(field))
                        {
                            result = row[field].SafeToString();
                            break;
                        }
                    }
                }
            }
            
            return result;
        }
    }
}