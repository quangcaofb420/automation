using System;

namespace ControlUtils
{
    public static class DataGridViewEx
    {
        public static T SelectedData<T>(this System.Windows.Forms.DataGridView dgv)
        {
            System.Windows.Forms.DataGridViewSelectedRowCollection selectedRows = dgv.SelectedRows;

            if (selectedRows.Count > 0)
            {
                T t = (T)selectedRows[0].DataBoundItem;
                return t;
            }
            return default(T);
        }
    }
}
