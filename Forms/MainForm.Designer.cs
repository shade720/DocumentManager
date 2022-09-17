namespace DocumentManager.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.OpenInputRegisterButton = new System.Windows.Forms.Button();
            this.OpenBaseRegisterButton = new System.Windows.Forms.Button();
            this.TableSpacePanel = new System.Windows.Forms.Panel();
            this.LeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftPanel.Controls.Add(this.RefreshButton);
            this.LeftPanel.Controls.Add(this.OpenInputRegisterButton);
            this.LeftPanel.Controls.Add(this.OpenBaseRegisterButton);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(230, 753);
            this.LeftPanel.TabIndex = 0;
            // 
            // RefreshButton
            // 
            this.RefreshButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshButton.Location = new System.Drawing.Point(30, 601);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(170, 120);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // OpenInputRegisterButton
            // 
            this.OpenInputRegisterButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.OpenInputRegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenInputRegisterButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenInputRegisterButton.Location = new System.Drawing.Point(30, 178);
            this.OpenInputRegisterButton.Name = "OpenInputRegisterButton";
            this.OpenInputRegisterButton.Size = new System.Drawing.Size(170, 120);
            this.OpenInputRegisterButton.TabIndex = 1;
            this.OpenInputRegisterButton.Text = "Incoming Documents";
            this.OpenInputRegisterButton.UseVisualStyleBackColor = true;
            this.OpenInputRegisterButton.Click += new System.EventHandler(this.OpenInputRegisterButton_Click);
            // 
            // OpenBaseRegisterButton
            // 
            this.OpenBaseRegisterButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.OpenBaseRegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenBaseRegisterButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenBaseRegisterButton.Location = new System.Drawing.Point(30, 30);
            this.OpenBaseRegisterButton.Name = "OpenBaseRegisterButton";
            this.OpenBaseRegisterButton.Size = new System.Drawing.Size(170, 120);
            this.OpenBaseRegisterButton.TabIndex = 0;
            this.OpenBaseRegisterButton.Text = "Base Documents";
            this.OpenBaseRegisterButton.UseVisualStyleBackColor = true;
            this.OpenBaseRegisterButton.Click += new System.EventHandler(this.OpenBaseRegisterButton_Click);
            // 
            // TableSpacePanel
            // 
            this.TableSpacePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TableSpacePanel.Location = new System.Drawing.Point(230, 0);
            this.TableSpacePanel.Name = "TableSpacePanel";
            this.TableSpacePanel.Size = new System.Drawing.Size(1351, 753);
            this.TableSpacePanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.TableSpacePanel);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DocumentManager";
            this.LeftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Button OpenInputRegisterButton;
        private System.Windows.Forms.Button OpenBaseRegisterButton;
        private System.Windows.Forms.Panel TableSpacePanel;
        private System.Windows.Forms.Button RefreshButton;
    }
}

