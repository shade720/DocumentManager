using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DocumentManager.Models.DocumentsModels;
using DocumentManager.Models.Filters;

namespace DocumentManager.Forms
{
    public partial class IncomingRegisterForm : Form
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

        public IncomingRegisterForm(Models.DocumentManager manager)
        {
            _manager = manager;
            InitializeComponent();
            FromDateTimePicker.Value = DateTime.Now.AddDays(-1);
            ToDateTimePicker.Value = DateTime.Now.AddDays(1);
        }

        private void CreateNewDocumentButton_Click(object sender, EventArgs e)
        {
            var incomingDocumentForm = new IncomingDocumentForm(false);
            if (incomingDocumentForm.ShowDialog() != DialogResult.OK) return;
            try
            {
                _manager.AddToIncomingRegister(incomingDocumentForm.Name, incomingDocumentForm.Subject, incomingDocumentForm.Addressee, incomingDocumentForm.Counterparty, incomingDocumentForm.DeliveryMethod, incomingDocumentForm.CameFrom);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            RefreshTable();
        }

        private IncomingDocumentFilter CreateFilter()
        {
            if (FilteringByDateComboBox.SelectedItem != null && FilteringByDateComboBox.SelectedItem.ToString() != "")
            {
                FromDateTimePicker.Value = DateTime.Now.AddDays(-_daysFromComboBox[FilteringByDateComboBox.SelectedItem.ToString()]);
            }
            return new IncomingDocumentFilter
            {
                BaseDocumentFilter = new BaseDocumentFilter ("IncomingDocument")
                {
                    ByName = SearchTextBox.Text,
                    FromDate = FromDateTimePicker.Value,
                    ToDate = ToDateTimePicker.Value
                },
                ByCounterparty = new Counterparty { OrganizationName = CounterpartyComboBox.SelectedItem != null ? CounterpartyComboBox.SelectedItem.ToString() : string.Empty},
                ByDeliveryMethod = new DeliveryMethod { MethodName = DeliveryMethodComboBox.SelectedItem != null ? DeliveryMethodComboBox.SelectedItem.ToString() : string.Empty }
            };
        }

        public void RefreshTable()
        {
            try
            {
                IncomingDocumentsGrid.Rows.Clear();
                foreach (var document in _manager.GetIncomingDocuments(CreateFilter()))
                {
                    IncomingDocumentsGrid.Rows.Add
                    (
                        document.BaseDocument.Discriminator,
                        document.BaseDocument.Name,
                        document.BaseDocument.DocumentKind.Name,
                        document.BaseDocument.Subject,
                        document.BaseDocument.CreatedDate,
                        document.BaseDocument.DocumentNumber,
                        string.Join(" ", document.Addresses.Surname, document.Addresses.Name, document.Addresses.Patronymic),
                        document.Counterparty.OrganizationName,
                        document.DeliveryMethod.MethodName,
                        document.CameFrom.OrganizationName
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }

        private void IncomingDocumentsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 10 || e.RowIndex == -1) return;

            var oldBaseDocument = new BaseDocumentBuilder()
                .AddDiscriminator(new Guid(IncomingDocumentsGrid.Rows[e.RowIndex].Cells[0].Value.ToString()))
                .AddName(IncomingDocumentsGrid.Rows[e.RowIndex].Cells[1].Value.ToString())
                .AddDocumentKind(0, IncomingDocumentsGrid.Rows[e.RowIndex].Cells[2].Value.ToString())
                .AddSubject(IncomingDocumentsGrid.Rows[e.RowIndex].Cells[3].Value.ToString())
                .AddCreationDate(DateTime.Parse(IncomingDocumentsGrid.Rows[e.RowIndex].Cells[4].Value.ToString()))
                .AddDocumentNumber(IncomingDocumentsGrid.Rows[e.RowIndex].Cells[5].Value.ToString())
                .Build();

            var addresseeSplit = IncomingDocumentsGrid.Rows[e.RowIndex].Cells[6].Value.ToString().Split(' ');
            var oldIncomingDocument = new IncomingDocumentBuilder()
                .AddBaseDocument(oldBaseDocument)
                .AddAddressee(0, addresseeSplit[0], addresseeSplit[1], addresseeSplit[2])
                .AddCounterparty(0, IncomingDocumentsGrid.Rows[e.RowIndex].Cells[7].Value.ToString())
                .AddDeliveryMethod(0, IncomingDocumentsGrid.Rows[e.RowIndex].Cells[8].Value.ToString())
                .AddCameFrom(0, IncomingDocumentsGrid.Rows[e.RowIndex].Cells[9].Value.ToString())
                .Build();

            var changedIncomingDocument = new IncomingDocumentForm(true, oldIncomingDocument);
            if (changedIncomingDocument.ShowDialog() != DialogResult.OK) return;

            var splittedAddressee = changedIncomingDocument.Addressee.Split(' ');
            oldIncomingDocument.BaseDocument.Name = changedIncomingDocument.Name;
            oldIncomingDocument.BaseDocument.Subject = changedIncomingDocument.Subject;
            oldIncomingDocument.Addresses.Surname = splittedAddressee[0];
            oldIncomingDocument.Addresses.Name = splittedAddressee[1];
            oldIncomingDocument.Addresses.Patronymic = splittedAddressee[2];
            oldIncomingDocument.Counterparty.OrganizationName = changedIncomingDocument.Counterparty;
            oldIncomingDocument.DeliveryMethod.MethodName = changedIncomingDocument.DeliveryMethod;
            oldIncomingDocument.CameFrom.OrganizationName = changedIncomingDocument.CameFrom;

            try
            {
                _manager.UpdateIncomingDocument(oldIncomingDocument);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
            RefreshTable();
        }
    }
}
