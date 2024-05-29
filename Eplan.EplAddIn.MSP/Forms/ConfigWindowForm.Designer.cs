namespace Eplan.EplAddIn.MSP
{
    partial class ConfigWindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigWindowForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.motorPowerTextBox = new System.Windows.Forms.TextBox();
            this.clampsCheckBox = new System.Windows.Forms.CheckBox();
            this.startTypeComboBox = new System.Windows.Forms.ComboBox();
            this.protectionValueTextBox = new System.Windows.Forms.TextBox();
            this.orderNumberComboBox = new System.Windows.Forms.ComboBox();
            this.protectionTypeComboBox = new System.Windows.Forms.ComboBox();
            this.motorPowerLabel = new System.Windows.Forms.Label();
            this.clampsLabel = new System.Windows.Forms.Label();
            this.startTypeLabel = new System.Windows.Forms.Label();
            this.orderNumberLabel = new System.Windows.Forms.Label();
            this.protectionValueLabel = new System.Windows.Forms.Label();
            this.protectionTypeLabel = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.motorPowerTextBox);
            this.mainPanel.Controls.Add(this.clampsCheckBox);
            this.mainPanel.Controls.Add(this.startTypeComboBox);
            this.mainPanel.Controls.Add(this.protectionValueTextBox);
            this.mainPanel.Controls.Add(this.orderNumberComboBox);
            this.mainPanel.Controls.Add(this.protectionTypeComboBox);
            this.mainPanel.Controls.Add(this.motorPowerLabel);
            this.mainPanel.Controls.Add(this.clampsLabel);
            this.mainPanel.Controls.Add(this.startTypeLabel);
            this.mainPanel.Controls.Add(this.orderNumberLabel);
            this.mainPanel.Controls.Add(this.protectionValueLabel);
            this.mainPanel.Controls.Add(this.protectionTypeLabel);
            this.mainPanel.Location = new System.Drawing.Point(6, 6);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(438, 200);
            this.mainPanel.TabIndex = 0;
            // 
            // motorPowerTextBox
            // 
            this.motorPowerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.motorPowerTextBox.Location = new System.Drawing.Point(149, 163);
            this.motorPowerTextBox.Name = "motorPowerTextBox";
            this.motorPowerTextBox.Size = new System.Drawing.Size(270, 20);
            this.motorPowerTextBox.TabIndex = 11;
            // 
            // clampsCheckBox
            // 
            this.clampsCheckBox.AutoSize = true;
            this.clampsCheckBox.Location = new System.Drawing.Point(149, 136);
            this.clampsCheckBox.Name = "clampsCheckBox";
            this.clampsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.clampsCheckBox.TabIndex = 10;
            this.clampsCheckBox.UseVisualStyleBackColor = true;
            // 
            // startTypeComboBox
            // 
            this.startTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startTypeComboBox.FormattingEnabled = true;
            this.startTypeComboBox.Location = new System.Drawing.Point(149, 101);
            this.startTypeComboBox.Name = "startTypeComboBox";
            this.startTypeComboBox.Size = new System.Drawing.Size(270, 21);
            this.startTypeComboBox.TabIndex = 9;
            // 
            // protectionValueTextBox
            // 
            this.protectionValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.protectionValueTextBox.Location = new System.Drawing.Point(149, 43);
            this.protectionValueTextBox.Name = "protectionValueTextBox";
            this.protectionValueTextBox.Size = new System.Drawing.Size(270, 20);
            this.protectionValueTextBox.TabIndex = 8;
            // 
            // orderNumberComboBox
            // 
            this.orderNumberComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderNumberComboBox.FormattingEnabled = true;
            this.orderNumberComboBox.Location = new System.Drawing.Point(149, 71);
            this.orderNumberComboBox.Name = "orderNumberComboBox";
            this.orderNumberComboBox.Size = new System.Drawing.Size(270, 21);
            this.orderNumberComboBox.TabIndex = 7;
            // 
            // protectionTypeComboBox
            // 
            this.protectionTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.protectionTypeComboBox.FormattingEnabled = true;
            this.protectionTypeComboBox.Location = new System.Drawing.Point(149, 11);
            this.protectionTypeComboBox.Name = "protectionTypeComboBox";
            this.protectionTypeComboBox.Size = new System.Drawing.Size(270, 21);
            this.protectionTypeComboBox.TabIndex = 6;
            this.protectionTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.protectionTypeComboBox_SelectedIndexChanged);
            // 
            // motorPowerLabel
            // 
            this.motorPowerLabel.AutoSize = true;
            this.motorPowerLabel.Location = new System.Drawing.Point(14, 166);
            this.motorPowerLabel.Name = "motorPowerLabel";
            this.motorPowerLabel.Size = new System.Drawing.Size(128, 13);
            this.motorPowerLabel.TabIndex = 5;
            this.motorPowerLabel.Text = "Мотор Ном. мощность :";
            // 
            // clampsLabel
            // 
            this.clampsLabel.AutoSize = true;
            this.clampsLabel.Location = new System.Drawing.Point(16, 134);
            this.clampsLabel.Name = "clampsLabel";
            this.clampsLabel.Size = new System.Drawing.Size(53, 13);
            this.clampsLabel.TabIndex = 4;
            this.clampsLabel.Text = "Клеммы:";
            // 
            // startTypeLabel
            // 
            this.startTypeLabel.AutoSize = true;
            this.startTypeLabel.Location = new System.Drawing.Point(14, 104);
            this.startTypeLabel.Name = "startTypeLabel";
            this.startTypeLabel.Size = new System.Drawing.Size(61, 13);
            this.startTypeLabel.TabIndex = 3;
            this.startTypeLabel.Text = "Тип пуска:";
            // 
            // orderNumberLabel
            // 
            this.orderNumberLabel.AutoSize = true;
            this.orderNumberLabel.Location = new System.Drawing.Point(16, 74);
            this.orderNumberLabel.Name = "orderNumberLabel";
            this.orderNumberLabel.Size = new System.Drawing.Size(94, 13);
            this.orderNumberLabel.TabIndex = 2;
            this.orderNumberLabel.Text = "Заказной номер:";
            // 
            // protectionValueLabel
            // 
            this.protectionValueLabel.AutoSize = true;
            this.protectionValueLabel.Location = new System.Drawing.Point(16, 46);
            this.protectionValueLabel.Name = "protectionValueLabel";
            this.protectionValueLabel.Size = new System.Drawing.Size(96, 13);
            this.protectionValueLabel.TabIndex = 1;
            this.protectionValueLabel.Text = "Уставка защиты:";
            // 
            // protectionTypeLabel
            // 
            this.protectionTypeLabel.AutoSize = true;
            this.protectionTypeLabel.Location = new System.Drawing.Point(14, 14);
            this.protectionTypeLabel.Name = "protectionTypeLabel";
            this.protectionTypeLabel.Size = new System.Drawing.Size(72, 13);
            this.protectionTypeLabel.TabIndex = 0;
            this.protectionTypeLabel.Text = "Тип защиты:";
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateButton.Image = global::Eplan.EplAddIn.MSP.Properties.Resources.media_play_green;
            this.generateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.generateButton.Location = new System.Drawing.Point(114, 214);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(162, 23);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Генерировать";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Image = global::Eplan.EplAddIn.MSP.Properties.Resources.cancel;
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(282, 214);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(162, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ConfigWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 244);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigWindowForm";
            this.Text = "Motor Starter with Protection";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox motorPowerTextBox;
        private System.Windows.Forms.CheckBox clampsCheckBox;
        private System.Windows.Forms.ComboBox startTypeComboBox;
        private System.Windows.Forms.TextBox protectionValueTextBox;
        private System.Windows.Forms.ComboBox orderNumberComboBox;
        private System.Windows.Forms.ComboBox protectionTypeComboBox;
        private System.Windows.Forms.Label motorPowerLabel;
        private System.Windows.Forms.Label clampsLabel;
        private System.Windows.Forms.Label startTypeLabel;
        private System.Windows.Forms.Label orderNumberLabel;
        private System.Windows.Forms.Label protectionValueLabel;
        private System.Windows.Forms.Label protectionTypeLabel;
    }
}