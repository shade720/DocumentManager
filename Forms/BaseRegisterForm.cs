using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DocumentManager.Models.DocumentsModels;
using DocumentManager.Models.Filters;

namespace DocumentManager.Forms
{
    public partial class BaseRegisterForm : Form
    {
        private readonly Models.DocumentManager _manager;
        private readonly Dictionary<string, int> _daysFromComboBox = new Dictionary<string, int>
        {
            {"Last week", 7},
            {"Last 30 days", 30},
            {"Last 90 days", 90}
        };

        protected override void OnShown(EventArgs e)
        {
            RefreshTable();
        }

        public BaseRegisterForm(Models.DocumentManager manager)
        {
            _manager = manager;
            InitializeComponent();
            FromDateTimePicker.Value = DateTime.Now.AddDays(-1);
            ToDateTimePicker.Value = DateTime.Now.AddDays(1);
        }

        private void CreateNewDocumentButton_Click(object sender, EventArgs e)
        {
            var baseDocumentForm = new BaseDocumentForm(false);
            if (baseDocumentForm.ShowDialog() != DialogResult.OK) return;
            try
            {
                _manager.AddToBaseRegister(baseDocumentForm.Name, baseDocumentForm.Subject);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            RefreshTable();
        }

        private BaseDocumentFilter CreateFilter()
        {
            if (FilteringByDateComboBox.SelectedItem != null && FilteringByDateComboBox.SelectedItem.ToString() != "")
            {
                FromDateTimePicker.Value = DateTime.Now.AddDays(-_daysFromComboBox[FilteringByDateComboBox.SelectedItem.ToString()]);
            }
            return new BaseDocumentFilter ("BaseDocument")
            {
                ByName = SearchTextBox.Text,
                FromDate = FromDateTimePicker.Value,
                ToDate = ToDateTimePicker.Value
            };
        }

        public void RefreshTable()
        {
            BaseDocumentsGrid.Rows.Clear();
            try
            {
                foreach (var document in _manager.GetBaseDocuments(CreateFilter()))
                {
                    BaseDocumentsGrid.Rows.Add(
                        document.Discriminator,
                        document.Name,
                        document.DocumentKind.Name,
                        document.Subject,
                        document.CreatedDate.ToString(CultureInfo.InvariantCulture),
                        document.DocumentNumber
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }

        private void BaseDocumentsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 6 || e.RowIndex == -1) return;

            var oldBaseDocument = new BaseDocumentBuilder()
                .AddDiscriminator(new Guid(BaseDocumentsGrid.Rows[e.RowIndex].Cells[0].Value.ToString()))
                .AddName(BaseDocumentsGrid.Rows[e.RowIndex].Cells[1].Value.ToString())
                .AddDocumentKind(0, BaseDocumentsGrid.Rows[e.RowIndex].Cells[2].Value.ToString())
                .AddSubject(BaseDocumentsGrid.Rows[e.RowIndex].Cells[3].Value.ToString())
                .AddCreationDate(DateTime.Parse(BaseDocumentsGrid.Rows[e.RowIndex].Cells[4].Value.ToString()))
                .AddDocumentNumber(BaseDocumentsGrid.Rows[e.RowIndex].Cells[5].Value.ToString())
                .Build();

            var changedBaseDocument = new BaseDocumentForm(true, oldBaseDocument);
            if (changedBaseDocument.ShowDialog() != DialogResult.OK) return;

            if (string.IsNullOrEmpty(changedBaseDocument.Name) || string.IsNullOrEmpty(changedBaseDocument.Subject)) return;

            oldBaseDocument.Name = changedBaseDocument.Name;
            oldBaseDocument.Subject = changedBaseDocument.Subject;
            try
            {
                _manager.UpdateBaseDocument(oldBaseDocument);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            RefreshTable();
        }
    }
}
