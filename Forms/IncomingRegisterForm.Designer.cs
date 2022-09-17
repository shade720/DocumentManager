namespace DocumentManager.Forms
{
    partial class IncomingRegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FilteringByDateComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeliveryMethodComboBox = new System.Windows.Forms.ComboBox();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CounterpartyComboBox = new System.Windows.Forms.ComboBox();
            this.CreateNewDocumentButton = new System.Windows.Forms.Button();
            this.IncomingDocumentsGrid = new System.Windows.Forms.DataGridView();
            this.Discriminator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Addressee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Counterparty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CameFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editing = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IncomingDocumentsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.CreateNewDocumentButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 100);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DeliveryMethodComboBox);
            this.groupBox1.Controls.Add(this.SearchTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.CounterpartyComboBox);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(962, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtering";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(446, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "DeliveryMethod";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(198, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 23);
            this.label10.TabIndex = 38;
            this.label10.Text = "Delivery method";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ToDateTimePicker);
            this.groupBox2.Controls.Add(this.FromDateTimePicker);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.FilteringByDateComboBox);
            this.groupBox2.Location = new System.Drawing.Point(609, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 86);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Creation date";
            // 
            // ToDateTimePicker
            // 
            this.ToDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToDateTimePicker.Location = new System.Drawing.Point(180, 55);
            this.ToDateTimePicker.Name = "ToDateTimePicker";
            this.ToDateTimePicker.Size = new System.Drawing.Size(166, 27);
            this.ToDateTimePicker.TabIndex = 10;
            // 
            // FromDateTimePicker
            // 
            this.FromDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FromDateTimePicker.Location = new System.Drawing.Point(180, 22);
            this.FromDateTimePicker.Name = "FromDateTimePicker";
            this.FromDateTimePicker.Size = new System.Drawing.Size(166, 27);
            this.FromDateTimePicker.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "From:";
            // 
            // FilteringByDateComboBox
            // 
            this.FilteringByDateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilteringByDateComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilteringByDateComboBox.FormattingEnabled = true;
            this.FilteringByDateComboBox.Items.AddRange(new object[] {
            "",
            "Last week",
            "Last 30 days",
            "Last 90 days"});
            this.FilteringByDateComboBox.Location = new System.Drawing.Point(6, 54);
            this.FilteringByDateComboBox.Name = "FilteringByDateComboBox";
            this.FilteringByDateComboBox.Size = new System.Drawing.Size(121, 28);
            this.FilteringByDateComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Document name";
            // 
            // DeliveryMethodComboBox
            // 
            this.DeliveryMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeliveryMethodComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeliveryMethodComboBox.FormattingEnabled = true;
            this.DeliveryMethodComboBox.Items.AddRange(new object[] {
            "",
            "Email",
            "Letter",
            "Courier",
            "SEDM",
            "Plane"});
            this.DeliveryMethodComboBox.Location = new System.Drawing.Point(450, 66);
            this.DeliveryMethodComboBox.Name = "DeliveryMethodComboBox";
            this.DeliveryMethodComboBox.Size = new System.Drawing.Size(144, 28);
            this.DeliveryMethodComboBox.TabIndex = 39;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchTextBox.Location = new System.Drawing.Point(12, 67);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(281, 27);
            this.SearchTextBox.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(296, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 20);
            this.label9.TabIndex = 36;
            this.label9.Text = "Counterparty";
            // 
            // CounterpartyComboBox
            // 
            this.CounterpartyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CounterpartyComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CounterpartyComboBox.FormattingEnabled = true;
            this.CounterpartyComboBox.Items.AddRange(new object[] {
            "",
            "org1",
            "org2",
            "org3",
            "org4",
            "org5"});
            this.CounterpartyComboBox.Location = new System.Drawing.Point(300, 66);
            this.CounterpartyComboBox.Name = "CounterpartyComboBox";
            this.CounterpartyComboBox.Size = new System.Drawing.Size(144, 28);
            this.CounterpartyComboBox.TabIndex = 37;
            // 
            // CreateNewDocumentButton
            // 
            this.CreateNewDocumentButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateNewDocumentButton.Location = new System.Drawing.Point(1162, 12);
            this.CreateNewDocumentButton.Name = "CreateNewDocumentButton";
            this.CreateNewDocumentButton.Size = new System.Drawing.Size(126, 72);
            this.CreateNewDocumentButton.TabIndex = 2;
            this.CreateNewDocumentButton.Text = "Create new";
            this.CreateNewDocumentButton.UseVisualStyleBackColor = true;
            this.CreateNewDocumentButton.Click += new System.EventHandler(this.CreateNewDocumentButton_Click);
            // 
            // IncomingDocumentsGrid
            // 
            this.IncomingDocumentsGrid.AllowUserToAddRows = false;
            this.IncomingDocumentsGrid.AllowUserToDeleteRows = false;
            this.IncomingDocumentsGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.IncomingDocumentsGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.IncomingDocumentsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.IncomingDocumentsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.IncomingDocumentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IncomingDocumentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Discriminator,
            this.DocumentName,
            this.DocumentKind,
            this.Subject,
            this.CreatedDate,
            this.DocumentNumber,
            this.Addressee,
            this.Counterparty,
            this.DeliveryMethod,
            this.CameFrom,
            this.Editing});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.IncomingDocumentsGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.IncomingDocumentsGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.IncomingDocumentsGrid.GridColor = System.Drawing.SystemColors.Window;
            this.IncomingDocumentsGrid.Location = new System.Drawing.Point(0, 103);
            this.IncomingDocumentsGrid.Name = "IncomingDocumentsGrid";
            this.IncomingDocumentsGrid.ReadOnly = true;
            this.IncomingDocumentsGrid.RowHeadersVisible = false;
            this.IncomingDocumentsGrid.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.IncomingDocumentsGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.IncomingDocumentsGrid.RowTemplate.Height = 24;
            this.IncomingDocumentsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.IncomingDocumentsGrid.Size = new System.Drawing.Size(1300, 650);
            this.IncomingDocumentsGrid.TabIndex = 3;
            this.IncomingDocumentsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IncomingDocumentsGrid_CellContentClick);
            // 
            // Discriminator
            // 
            this.Discriminator.HeaderText = "Discriminator";
            this.Discriminator.MinimumWidth = 6;
            this.Discriminator.Name = "Discriminator";
            this.Discriminator.ReadOnly = true;
            this.Discriminator.Width = 125;
            // 
            // DocumentName
            // 
            this.DocumentName.HeaderText = "Name";
            this.DocumentName.MinimumWidth = 6;
            this.DocumentName.Name = "DocumentName";
            this.DocumentName.ReadOnly = true;
            this.DocumentName.Width = 70;
            // 
            // DocumentKind
            // 
            this.DocumentKind.HeaderText = "Document Kind";
            this.DocumentKind.MinimumWidth = 6;
            this.DocumentKind.Name = "DocumentKind";
            this.DocumentKind.ReadOnly = true;
            this.DocumentKind.Width = 90;
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Subject";
            this.Subject.MinimumWidth = 6;
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.HeaderText = "Created Date";
            this.CreatedDate.MinimumWidth = 6;
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            this.CreatedDate.Width = 60;
            // 
            // DocumentNumber
            // 
            this.DocumentNumber.HeaderText = "Document Number";
            this.DocumentNumber.MinimumWidth = 6;
            this.DocumentNumber.Name = "DocumentNumber";
            this.DocumentNumber.ReadOnly = true;
            this.DocumentNumber.Width = 125;
            // 
            // Addressee
            // 
            this.Addressee.HeaderText = "Addressee";
            this.Addressee.MinimumWidth = 6;
            this.Addressee.Name = "Addressee";
            this.Addressee.ReadOnly = true;
            this.Addressee.Width = 90;
            // 
            // Counterparty
            // 
            this.Counterparty.HeaderText = "Counterparty";
            this.Counterparty.MinimumWidth = 6;
            this.Counterparty.Name = "Counterparty";
            this.Counterparty.ReadOnly = true;
            this.Counterparty.Width = 125;
            // 
            // DeliveryMethod
            // 
            this.DeliveryMethod.HeaderText = "Delivery Method";
            this.DeliveryMethod.MinimumWidth = 6;
            this.DeliveryMethod.Name = "DeliveryMethod";
            this.DeliveryMethod.ReadOnly = true;
            this.DeliveryMethod.Width = 60;
            // 
            // CameFrom
            // 
            this.CameFrom.HeaderText = "Came From";
            this.CameFrom.MinimumWidth = 6;
            this.CameFrom.Name = "CameFrom";
            this.CameFrom.ReadOnly = true;
            this.CameFrom.Width = 70;
            // 
            // Editing
            // 
            this.Editing.HeaderText = "Editing";
            this.Editing.MinimumWidth = 6;
            this.Editing.Name = "Editing";
            this.Editing.ReadOnly = true;
            this.Editing.Text = "Edit";
            this.Editing.UseColumnTextForButtonValue = true;
            this.Editing.Width = 48;
            // 
            // IncomingRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 753);
            this.Controls.Add(this.IncomingDocumentsGrid);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IncomingRegisterForm";
            this.Text = "InputRegister";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IncomingDocumentsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox FilteringByDateComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button CreateNewDocumentButton;
        private System.Windows.Forms.DataGridView IncomingDocumentsGrid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox DeliveryMethodComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CounterpartyComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ToDateTimePicker;
        private System.Windows.Forms.DateTimePicker FromDateTimePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discriminator;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Addressee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Counterparty;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliveryMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn CameFrom;
        private System.Windows.Forms.DataGridViewButtonColumn Editing;
    }
}