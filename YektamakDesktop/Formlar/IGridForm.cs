using Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar
{
    public interface IGridForm<T> where T : IEntity , new()
    {
        /// <summary>
        /// int i = GlobalData.IndexOfDataSet(dataTable, firma.id);
        /// if (i == -1)
        /// {
        /// AddNewRow(firma);
        /// }
        /// else
        /// {
        /// GlobalData.UpdateDataRow(dataTable, firma, i);
        /// }
        /// </summary>
        /// <param name="model"></param>
        public void UpdateRow(T model);
        /// <summary>
        /// public void AddNewRow(Firma firma)
        /// {
        ///    dataTable.Rows.Add(
        ///        );
        /// }
        /// </summary>
        /// <param name="model"></param>
        public void AddNewRow(T model);
        /// <summary>
        /// GlobalData.PlaceFilterFields(dataGridView,panelFilter);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void form_Load(object sender, EventArgs e);
        /// <summary>
        /// GlobalData.FillDataGrid(dataTable, dataGridView, firmaFilter);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataTableRowChanged(object sender, DataRowChangeEventArgs e);
        public void buttonEkle_Click(object sender, EventArgs e);
        /// <summary>
        /// GlobalData.CloseForm(ref _firmaGridForm);
        /// </summary>
        public void CloseForm();
        /// <summary>
        /// GlobalData.DataGridViewCellClick<SatinalmaSiparis>(ref _dataTable, dataGridView, e);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e);
        /// <summary>
        /// GlobalData.FillDataGrid(dataTable, dataGridView, filter);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonTumKayitlariGetir_Click(object sender, EventArgs e);
        /// <summary>
        /// GlobalData.FillDataGrid(dataTable, dataGridView, filter);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonFiltre_Click(object sender, EventArgs e);

        /// <summary>
        /// GlobalData.ResizeFilterFields(dataGridView, panelFilter);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e);

        /// <summary>
        /// CloseForm();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonClose_Click(object sender, EventArgs e);
        /// <summary>
        /// this.WindowState = FormWindowState.Minimized;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttomMinimize_Click(object sender, EventArgs e);
 
        /// <summary>
        /// GlobalData.AdjustControlsOnScroll(dataGridView, panelFilter, e, ref oldScrollOffset);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void dataGridView_Scroll(object sender, ScrollEventArgs e);
    }
}
