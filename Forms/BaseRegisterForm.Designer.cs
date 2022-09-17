namespace DocumentManager.Forms
{
    partial class BaseRegisterForm
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
            this.BaseDocumentsGrid = new System.Windows.Forms.DataGridView();
            this.Discriminator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editing = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FilteringByDateComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.CreateNewDocumentButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BaseDocumentsGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseDocumentsGrid
            // 
            this.BaseDocumentsGrid.AllowUserToAddRows = false;
            this.BaseDocumentsGrid.AllowUserToDeleteRows = false;
            this.BaseDocumentsGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.BaseDocumentsGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BaseDocumentsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.BaseDocumentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BaseDocumentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Discriminator,
            this.DocumentName,
            this.DocumentKind,
            this.Subject,
            this.CreatedDate,
            this.DocumentNumber,
            this.Editing});
            this.BaseDocumentsGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BaseDocumentsGrid.GridColor = System.Drawing.SystemColors.Window;
            this.BaseDocumentsGrid.Location = new System.Drawing.Point(0, 103);
            this.BaseDocumentsGrid.Margin = new System.Windows.Forms.Padding(0);
            this.BaseDocumentsGrid.Name = "BaseDocumentsGrid";
            this.BaseDocumentsGrid.ReadOnly = true;
            this.BaseDocumentsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.BaseDocumentsGrid.RowHeadersVisible = false;
            this.BaseDocumentsGrid.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BaseDocumentsGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.BaseDocumentsGrid.RowTemplate.Height = 24;
            this.BaseDocumentsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BaseDocumentsGrid.Size = new System.Drawing.Size(1300, 650);
            this.BaseDocumentsGrid.TabIndex = 0;
            this.BaseDocumentsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BaseDocumentsGrid_CellContentClick);
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
            this.DocumentName.Width = 125;
            // 
            // DocumentKind
            // 
            this.DocumentKind.HeaderText = "Document Kind";
            this.DocumentKind.MinimumWidth = 6;
            this.DocumentKind.Name = "DocumentKind";
            this.DocumentKind.ReadOnly = true;
            this.DocumentKind.Width = 125;
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Subject";
            this.Subject.MinimumWidth = 6;
            this.Subject.Name = "Subject";
            this.Subject.ReadOnly = true;
            this.Subject.Width = 250;
            // 
            // CreatedDate
            // 
            this.CreatedDate.HeaderText = "CreatedDate";
            this.CreatedDate.MinimumWidth = 6;
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            this.CreatedDate.Width = 125;
            // 
            // DocumentNumber
            // 
            this.DocumentNumber.HeaderText = "DocumentNumber";
            this.DocumentNumber.MinimumWidth = 6;
            this.DocumentNumber.Name = "DocumentNumber";
            this.DocumentNumber.ReadOnly = true;
            this.DocumentNumber.Width = 125;
            // 
            // Editing
            // 
            this.Editing.HeaderText = "Editing";
            this.Editing.MinimumWidth = 6;
            this.Editing.Name = "Editing";
            this.Editing.ReadOnly = true;
            this.Editing.Text = "Edit";
            this.Editing.UseColumnTextForButtonValue = true;
            this.Editing.Width = 70;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.CreateNewDocumentButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 100);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SearchTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtering";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ToDateTimePicker);
            this.groupBox2.Controls.Add(this.FromDateTimePicker);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.FilteringByDateComboBox);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(305, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 89);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Creation date";
            // 
            // ToDateTimePicker
            // 
            this.ToDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToDateTimePicker.Location = new System.Drawing.Point(204, 54);
            this.ToDateTimePicker.Name = "ToDateTimePicker";
            this.ToDateTimePicker.Size = new System.Drawing.Size(166, 27);
            this.ToDateTimePicker.TabIndex = 8;
            // 
            // FromDateTimePicker
            // 
            this.FromDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FromDateTimePicker.Location = new System.Drawing.Point(204, 21);
            this.FromDateTimePicker.Name = "FromDateTimePicker";
            this.FromDateTimePicker.Size = new System.Drawing.Size(166, 27);
            this.FromDateTimePicker.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(170, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(156, 25);
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
            this.FilteringByDateComboBox.Location = new System.Drawing.Point(23, 53);
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
            // SearchTextBox
            // 
            this.SearchTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchTextBox.Location = new System.Drawing.Point(12, 67);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(281, 27);
            this.SearchTextBox.TabIndex = 0;
            // 
            // CreateNewDocumentButton
            // 
            this.CreateNewDocumentButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateNewDocumentButton.Location = new System.Drawing.Point(1162, 13);
            this.CreateNewDocumentButton.Name = "CreateNewDocumentButton";
            this.CreateNewDocumentButton.Size = new System.Drawing.Size(126, 72);
            this.CreateNewDocumentButton.TabIndex = 2;
            this.CreateNewDocumentButton.Text = "Create new";
            this.CreateNewDocumentButton.UseVisualStyleBackColor = true;
            this.CreateNewDocumentButton.Click += new System.EventHandler(this.CreateNewDocumentButton_Click);
            // 
            // BaseRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 753);
            this.Controls.Add(this.BaseDocumentsGrid);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseRegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseRegister";
            ((System.ComponentModel.ISupportInitialize)(this.BaseDocumentsGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView BaseDocumentsGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.ComboBox FilteringByDateComboBox;
        private System.Windows.Forms.Button CreateNewDocumentButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker ToDateTimePicker;
        private System.Windows.Forms.DateTimePicker FromDateTimePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discriminator;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentNumber;
        private System.Windows.Forms.DataGridViewButtonColumn Editing;
    }
}