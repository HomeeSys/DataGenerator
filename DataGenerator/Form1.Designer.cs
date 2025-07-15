namespace DataGenerator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            TrackBarDevices = new TrackBar();
            ComboBoxDevices = new ComboBox();
            groupBox1 = new GroupBox();
            DateTimePickerTimeEnd = new DateTimePicker();
            DateTimePickerTimeStart = new DateTimePicker();
            TextBoxEstimatedMeasurements = new TextBox();
            label6 = new Label();
            label5 = new Label();
            ComboBoxFrequency = new ComboBox();
            label3 = new Label();
            TextBoxDeviceNumber = new TextBox();
            DateTimePickerDateEnd = new DateTimePicker();
            label2 = new Label();
            DateTimePickerDateStart = new DateTimePicker();
            label1 = new Label();
            CheckedListBoxConfigs = new CheckedListBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            TextBoxDevicesAmount = new TextBox();
            label4 = new Label();
            ButtonGenerate = new Button();
            ButtonApplyConfigToAll = new Button();
            ButtonOutput = new Button();
            ((System.ComponentModel.ISupportInitialize)TrackBarDevices).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // TrackBarDevices
            // 
            TrackBarDevices.LargeChange = 1;
            TrackBarDevices.Location = new Point(6, 20);
            TrackBarDevices.Maximum = 20;
            TrackBarDevices.Minimum = 1;
            TrackBarDevices.Name = "TrackBarDevices";
            TrackBarDevices.Size = new Size(613, 45);
            TrackBarDevices.TabIndex = 0;
            TrackBarDevices.Value = 1;
            // 
            // ComboBoxDevices
            // 
            ComboBoxDevices.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxDevices.FormattingEnabled = true;
            ComboBoxDevices.Location = new Point(6, 48);
            ComboBoxDevices.MaxDropDownItems = 5;
            ComboBoxDevices.Name = "ComboBoxDevices";
            ComboBoxDevices.Size = new Size(148, 23);
            ComboBoxDevices.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DateTimePickerTimeEnd);
            groupBox1.Controls.Add(DateTimePickerTimeStart);
            groupBox1.Controls.Add(TextBoxEstimatedMeasurements);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(ComboBoxFrequency);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(TextBoxDeviceNumber);
            groupBox1.Controls.Add(DateTimePickerDateEnd);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(DateTimePickerDateStart);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(CheckedListBoxConfigs);
            groupBox1.Location = new Point(178, 92);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(459, 233);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Current device";
            // 
            // DateTimePickerTimeEnd
            // 
            DateTimePickerTimeEnd.Format = DateTimePickerFormat.Time;
            DateTimePickerTimeEnd.Location = new Point(117, 138);
            DateTimePickerTimeEnd.Name = "DateTimePickerTimeEnd";
            DateTimePickerTimeEnd.ShowUpDown = true;
            DateTimePickerTimeEnd.Size = new Size(133, 23);
            DateTimePickerTimeEnd.TabIndex = 11;
            // 
            // DateTimePickerTimeStart
            // 
            DateTimePickerTimeStart.Format = DateTimePickerFormat.Time;
            DateTimePickerTimeStart.Location = new Point(117, 80);
            DateTimePickerTimeStart.Name = "DateTimePickerTimeStart";
            DateTimePickerTimeStart.ShowUpDown = true;
            DateTimePickerTimeStart.Size = new Size(133, 23);
            DateTimePickerTimeStart.TabIndex = 10;
            // 
            // TextBoxEstimatedMeasurements
            // 
            TextBoxEstimatedMeasurements.Location = new Point(117, 196);
            TextBoxEstimatedMeasurements.Name = "TextBoxEstimatedMeasurements";
            TextBoxEstimatedMeasurements.ReadOnly = true;
            TextBoxEstimatedMeasurements.Size = new Size(133, 23);
            TextBoxEstimatedMeasurements.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 201);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 9;
            label6.Text = "Estimated";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 170);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 8;
            label5.Text = "Frequency";
            // 
            // ComboBoxFrequency
            // 
            ComboBoxFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxFrequency.FormattingEnabled = true;
            ComboBoxFrequency.Location = new Point(117, 167);
            ComboBoxFrequency.MaxDropDownItems = 3;
            ComboBoxFrequency.Name = "ComboBoxFrequency";
            ComboBoxFrequency.Size = new Size(133, 23);
            ComboBoxFrequency.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 115);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 5;
            label3.Text = "Last measurement";
            // 
            // TextBoxDeviceNumber
            // 
            TextBoxDeviceNumber.Location = new Point(117, 22);
            TextBoxDeviceNumber.Name = "TextBoxDeviceNumber";
            TextBoxDeviceNumber.Size = new Size(133, 23);
            TextBoxDeviceNumber.TabIndex = 3;
            // 
            // DateTimePickerDateEnd
            // 
            DateTimePickerDateEnd.Format = DateTimePickerFormat.Short;
            DateTimePickerDateEnd.Location = new Point(117, 109);
            DateTimePickerDateEnd.Name = "DateTimePickerDateEnd";
            DateTimePickerDateEnd.Size = new Size(133, 23);
            DateTimePickerDateEnd.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 57);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 2;
            label2.Text = "First measurement";
            // 
            // DateTimePickerDateStart
            // 
            DateTimePickerDateStart.Format = DateTimePickerFormat.Short;
            DateTimePickerDateStart.Location = new Point(117, 51);
            DateTimePickerDateStart.Name = "DateTimePickerDateStart";
            DateTimePickerDateStart.Size = new Size(133, 23);
            DateTimePickerDateStart.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 1;
            label1.Text = "Device Number";
            // 
            // CheckedListBoxConfigs
            // 
            CheckedListBoxConfigs.FormattingEnabled = true;
            CheckedListBoxConfigs.Location = new Point(256, 22);
            CheckedListBoxConfigs.Name = "CheckedListBoxConfigs";
            CheckedListBoxConfigs.Size = new Size(197, 202);
            CheckedListBoxConfigs.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(TrackBarDevices);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(625, 74);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Devices";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(TextBoxDevicesAmount);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(ComboBoxDevices);
            groupBox3.Location = new Point(12, 92);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(160, 80);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Available devices";
            // 
            // TextBoxDevicesAmount
            // 
            TextBoxDevicesAmount.Location = new Point(63, 19);
            TextBoxDevicesAmount.Name = "TextBoxDevicesAmount";
            TextBoxDevicesAmount.ReadOnly = true;
            TextBoxDevicesAmount.Size = new Size(91, 23);
            TextBoxDevicesAmount.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 22);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 2;
            label4.Text = "Amount";
            // 
            // ButtonGenerate
            // 
            ButtonGenerate.Location = new Point(12, 291);
            ButtonGenerate.Name = "ButtonGenerate";
            ButtonGenerate.Size = new Size(160, 34);
            ButtonGenerate.TabIndex = 7;
            ButtonGenerate.Text = "Generate";
            ButtonGenerate.UseVisualStyleBackColor = true;
            ButtonGenerate.Click += ButtonGenerate_Click;
            // 
            // ButtonApplyConfigToAll
            // 
            ButtonApplyConfigToAll.Location = new Point(12, 251);
            ButtonApplyConfigToAll.Name = "ButtonApplyConfigToAll";
            ButtonApplyConfigToAll.Size = new Size(160, 34);
            ButtonApplyConfigToAll.TabIndex = 8;
            ButtonApplyConfigToAll.Text = "Sync config";
            ButtonApplyConfigToAll.UseVisualStyleBackColor = true;
            ButtonApplyConfigToAll.Click += ButtonApplyConfigToAll_Click;
            // 
            // ButtonOutput
            // 
            ButtonOutput.Location = new Point(12, 211);
            ButtonOutput.Name = "ButtonOutput";
            ButtonOutput.Size = new Size(160, 34);
            ButtonOutput.TabIndex = 9;
            ButtonOutput.Text = "Output";
            ButtonOutput.UseVisualStyleBackColor = true;
            ButtonOutput.Click += ButtonOutput_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(647, 333);
            Controls.Add(ButtonOutput);
            Controls.Add(ButtonApplyConfigToAll);
            Controls.Add(ButtonGenerate);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Measurements generator";
            ((System.ComponentModel.ISupportInitialize)TrackBarDevices).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TrackBar TrackBarDevices;
        private ComboBox ComboBoxDevices;
        private GroupBox groupBox1;
        private CheckedListBox CheckedListBoxConfigs;
        private TextBox TextBoxDeviceNumber;
        private Label label2;
        private Label label1;
        private DateTimePicker DateTimePickerDateStart;
        private DateTimePicker DateTimePickerDateEnd;
        private Label label3;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox TextBoxDevicesAmount;
        private Label label4;
        private Button ButtonGenerate;
        private Button ButtonApplyConfigToAll;
        private Label label5;
        private ComboBox ComboBoxFrequency;
        private TextBox TextBoxEstimatedMeasurements;
        private Label label6;
        private DateTimePicker DateTimePickerTimeStart;
        private DateTimePicker DateTimePickerTimeEnd;
        private Button ButtonOutput;
    }
}
