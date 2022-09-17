using System;
using System.Windows.Forms;

namespace DocumentManager.Forms
{
    public partial class MainForm : Form
    {
        private readonly Models.DocumentManager _documentManager;
        private readonly BaseRegisterForm _baseRegisterForm;
        private readonly IncomingRegisterForm _incomingRegisterForm;

        public MainForm()
        {
            InitializeComponent();

            _documentManager = new Models.DocumentManager();
            _baseRegisterForm = new BaseRegisterForm(_documentManager);
            _incomingRegisterForm = new IncomingRegisterForm(_documentManager);

            _baseRegisterForm.TopLevel = false;
            TableSpacePanel.Controls.Add(_baseRegisterForm);

            _incomingRegisterForm.TopLevel = false;
            TableSpacePanel.Controls.Add(_incomingRegisterForm);
        }

        private void OpenBaseRegisterButton_Click(object sender, EventArgs e)
        {
            _incomingRegisterForm.Visible = false;
            _baseRegisterForm.Visible = true;
        }

        private void OpenInputRegisterButton_Click(object sender, EventArgs e)
        {
            _incomingRegisterForm.Visible = true;
            _baseRegisterForm.Visible = false;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if (_baseRegisterForm.Visible) _baseRegisterForm.RefreshTable();
            else _incomingRegisterForm.RefreshTable();
        }
    }
}
