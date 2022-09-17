using System;
using System.Windows.Forms;
using DocumentManager.Models.DocumentsModels;

namespace DocumentManager.Forms
{
    public partial class BaseDocumentForm : Form
    {
        public new string Name { get; private set; }
        public string Subject { get; private set; }

        public BaseDocumentForm(bool editMode, BaseDocument document = null)
        {
            InitializeComponent();

            if (editMode && document != null)
            {
                DiscriminantTextBox.Text = document.Discriminator.ToString();
                NameTextBox.Text = document.Name;
                DocumentKindTextBox.Text = document.DocumentKind.Name;
                SubjectTextBox.Text = document.Subject;
                CreationDateTextBox.Text = document.CreatedDate.ToString();
                DocumentNumberTextBox.Text = document.DocumentNumber;
                
                SaveDocumentButton.Enabled = false;
            }
        }

        private void SaveDocumentButton_Click(object sender, EventArgs e)
        {
            if (IsFieldsInvalid)
            {
                MessageBox.Show("One or more fields left blank");
                return;
            }
            DialogResult = DialogResult.OK;
            Name = NameTextBox.Text;
            Subject = SubjectTextBox.Text;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"There are unsaved changes left, are you sure you want to exit?", @"Unsaved changes", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK) DialogResult = DialogResult.Cancel;
        }

        #region IsDocumentChanged

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveDocumentButton.Enabled = true;
        }

        private void SubjectTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveDocumentButton.Enabled = true;
        }

        #endregion

        private bool IsFieldsInvalid => string.IsNullOrEmpty(NameTextBox.Text) ||
                                           string.IsNullOrEmpty(SubjectTextBox.Text);
    }
}
