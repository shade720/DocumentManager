using DocumentManager.Models.DocumentsModels;
using System.Windows.Forms;

namespace DocumentManager.Forms
{
    public partial class IncomingDocumentForm : Form
    {
        public new string Name { get; private set; }
        public string Subject { get; private set; }
        public string Addressee { get; private set; }
        public string Counterparty { get; private set; }
        public string DeliveryMethod { get; private set; }
        public string CameFrom { get; private set; }

        public IncomingDocumentForm(bool editMode, IncomingDocument document = null)
        {
            InitializeComponent();

            if (editMode && document != null)
            {
                DiscriminatorTextBox.Text = document.BaseDocument.Discriminator.ToString();
                NameTextbox.Text = document.BaseDocument.Name;
                DocumentKindTextBox.Text = document.BaseDocument.DocumentKind.Name;
                SubjectTextbox.Text = document.BaseDocument.Subject;
                CreatedDateTextBox.Text = document.BaseDocument.CreatedDate.ToString();
                DocumentNumberTextBox.Text = document.BaseDocument.DocumentNumber;
                AddresseeComboBox.SelectedItem = string.Join(" ", document.Addresses.Surname, document.Addresses.Name, document.Addresses.Patronymic);
                CounterpartyComboBox.SelectedItem = document.Counterparty.OrganizationName;
                DeliveryMethodComboBox.SelectedItem = document.DeliveryMethod.MethodName;
                CameFromComboBox.SelectedItem = document.CameFrom.OrganizationName;
                SaveDocumentButton.Enabled = false;
            }
        }

        private void SaveDocumentButton_Click(object sender, System.EventArgs e)
        {
            if (IsFieldsInvalid)
            {
                MessageBox.Show("One or more fields left blank");
                return;
            }

            DialogResult = DialogResult.OK;
            Name = NameTextbox.Text;
            Subject = SubjectTextbox.Text;
            Addressee = AddresseeComboBox.SelectedItem.ToString();
            Counterparty = CounterpartyComboBox.SelectedItem.ToString();
            DeliveryMethod = DeliveryMethodComboBox.SelectedItem.ToString();
            CameFrom = CameFromComboBox.SelectedItem.ToString();
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"There are unsaved changes left, are you sure you want to exit?", @"Unsaved changes", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK) DialogResult = DialogResult.Cancel;
        }

        #region IsDocumentChanged

        private void NameTextbox_TextChanged(object sender, System.EventArgs e)
        {
            SaveDocumentButton.Enabled = true;
        }

        private void SubjectTextbox_TextChanged(object sender, System.EventArgs e)
        {
            SaveDocumentButton.Enabled = true;
        }

        private void AddresseeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SaveDocumentButton.Enabled = true;
        }

        private void CounterpartyComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SaveDocumentButton.Enabled = true;
        }

        private void DeliveryMethodComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SaveDocumentButton.Enabled = true;
        }

        private void CameFromComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SaveDocumentButton.Enabled = true;
        }

        #endregion

        private bool IsFieldsInvalid => string.IsNullOrEmpty(NameTextbox.Text) ||
                                           string.IsNullOrEmpty(SubjectTextbox.Text) ||
                                           AddresseeComboBox.SelectedItem == null ||
                                           string.IsNullOrEmpty(AddresseeComboBox.SelectedItem.ToString()) ||
                                           CounterpartyComboBox.SelectedItem == null ||
                                           string.IsNullOrEmpty(CounterpartyComboBox.SelectedItem.ToString()) ||
                                           DeliveryMethodComboBox.SelectedItem == null ||
                                           string.IsNullOrEmpty(DeliveryMethodComboBox.SelectedItem.ToString()) ||
                                           CameFromComboBox.SelectedItem == null ||
                                           string.IsNullOrEmpty(CameFromComboBox.SelectedItem.ToString());
    }
}
