namespace DSSEM
{
    partial class dssem
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.assemblyFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.assemblyCode = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.codeSegmentGridView = new System.Windows.Forms.DataGridView();
            this.addressCodeSegment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataCodeSegment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSegmentGridView = new System.Windows.Forms.DataGridView();
            this.addressDataSegment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataSegment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stackSegmentGridView = new System.Windows.Forms.DataGridView();
            this.addressStackSegment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataStackSegment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.microoperation = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelGridView = new System.Windows.Forms.DataGridView();
            this.nameLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.indirect = new System.Windows.Forms.TextBox();
            this.inputRegister = new System.Windows.Forms.TextBox();
            this.sequenceCounter = new System.Windows.Forms.TextBox();
            this.E = new System.Windows.Forms.TextBox();
            this.stackPointer = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.accumulator = new System.Windows.Forms.TextBox();
            this.addressRegister = new System.Windows.Forms.TextBox();
            this.instructionRegister = new System.Windows.Forms.TextBox();
            this.dataRegister = new System.Windows.Forms.TextBox();
            this.programCounter = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lable19 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.binButton = new System.Windows.Forms.RadioButton();
            this.decButton = new System.Windows.Forms.RadioButton();
            this.octButton = new System.Windows.Forms.RadioButton();
            this.hexButton = new System.Windows.Forms.RadioButton();
            this.assemblyButton = new System.Windows.Forms.Button();
            this.microButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.registers = new System.Windows.Forms.GroupBox();
            this.memory = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.codeSegmentGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSegmentGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackSegmentGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelGridView)).BeginInit();
            this.registers.SuspendLayout();
            this.memory.SuspendLayout();
            this.SuspendLayout();
            // 
            // assemblyFile
            // 
            this.assemblyFile.Location = new System.Drawing.Point(97, 14);
            this.assemblyFile.Name = "assemblyFile";
            this.assemblyFile.Size = new System.Drawing.Size(168, 20);
            this.assemblyFile.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Assembly File";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(270, 12);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // assemblyCode
            // 
            this.assemblyCode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.assemblyCode.Enabled = false;
            this.assemblyCode.ForeColor = System.Drawing.Color.Black;
            this.assemblyCode.FormattingEnabled = true;
            this.assemblyCode.HorizontalScrollbar = true;
            this.assemblyCode.Location = new System.Drawing.Point(25, 80);
            this.assemblyCode.Name = "assemblyCode";
            this.assemblyCode.Size = new System.Drawing.Size(241, 316);
            this.assemblyCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(26, 59);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(77, 0, 77, 0);
            this.label2.Size = new System.Drawing.Size(240, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Code Block";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(25, 403);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(95, 0, 95, 0);
            this.label3.Size = new System.Drawing.Size(241, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Labels";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(57, 17);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(61, 0, 61, 0);
            this.label4.Size = new System.Drawing.Size(229, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Code Segment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(320, 17);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(63, 0, 63, 0);
            this.label5.Size = new System.Drawing.Size(228, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Data Segment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(583, 17);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(60, 0, 60, 0);
            this.label6.Size = new System.Drawing.Size(229, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Stack Segment";
            // 
            // codeSegmentGridView
            // 
            this.codeSegmentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.codeSegmentGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addressCodeSegment,
            this.dataCodeSegment});
            this.codeSegmentGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.codeSegmentGridView.Location = new System.Drawing.Point(58, 38);
            this.codeSegmentGridView.Name = "codeSegmentGridView";
            this.codeSegmentGridView.Size = new System.Drawing.Size(228, 212);
            this.codeSegmentGridView.TabIndex = 13;
            // 
            // addressCodeSegment
            // 
            this.addressCodeSegment.HeaderText = "Address";
            this.addressCodeSegment.Name = "addressCodeSegment";
            this.addressCodeSegment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.addressCodeSegment.Width = 60;
            // 
            // dataCodeSegment
            // 
            this.dataCodeSegment.HeaderText = "Data";
            this.dataCodeSegment.Name = "dataCodeSegment";
            this.dataCodeSegment.Width = 125;
            // 
            // dataSegmentGridView
            // 
            this.dataSegmentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSegmentGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addressDataSegment,
            this.dataDataSegment});
            this.dataSegmentGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataSegmentGridView.Location = new System.Drawing.Point(320, 38);
            this.dataSegmentGridView.Name = "dataSegmentGridView";
            this.dataSegmentGridView.Size = new System.Drawing.Size(228, 212);
            this.dataSegmentGridView.TabIndex = 14;
            // 
            // addressDataSegment
            // 
            this.addressDataSegment.HeaderText = "Address";
            this.addressDataSegment.Name = "addressDataSegment";
            this.addressDataSegment.Width = 60;
            // 
            // dataDataSegment
            // 
            this.dataDataSegment.HeaderText = "Data";
            this.dataDataSegment.Name = "dataDataSegment";
            this.dataDataSegment.Width = 125;
            // 
            // stackSegmentGridView
            // 
            this.stackSegmentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stackSegmentGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addressStackSegment,
            this.dataStackSegment});
            this.stackSegmentGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.stackSegmentGridView.Location = new System.Drawing.Point(583, 38);
            this.stackSegmentGridView.Name = "stackSegmentGridView";
            this.stackSegmentGridView.Size = new System.Drawing.Size(228, 212);
            this.stackSegmentGridView.TabIndex = 15;
            // 
            // addressStackSegment
            // 
            this.addressStackSegment.HeaderText = "Address";
            this.addressStackSegment.Name = "addressStackSegment";
            this.addressStackSegment.Width = 60;
            // 
            // dataStackSegment
            // 
            this.dataStackSegment.HeaderText = "Data";
            this.dataStackSegment.Name = "dataStackSegment";
            this.dataStackSegment.Width = 125;
            // 
            // microoperation
            // 
            this.microoperation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.microoperation.Enabled = false;
            this.microoperation.ForeColor = System.Drawing.Color.Black;
            this.microoperation.FormattingEnabled = true;
            this.microoperation.HorizontalScrollbar = true;
            this.microoperation.Location = new System.Drawing.Point(900, 54);
            this.microoperation.Name = "microoperation";
            this.microoperation.Size = new System.Drawing.Size(228, 264);
            this.microoperation.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(900, 33);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(60, 0, 60, 0);
            this.label7.Size = new System.Drawing.Size(228, 18);
            this.label7.TabIndex = 17;
            this.label7.Text = "Microoperation";
            // 
            // labelGridView
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.labelGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.labelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.labelGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameLabel,
            this.addressLabel});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.labelGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.labelGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.labelGridView.Location = new System.Drawing.Point(24, 424);
            this.labelGridView.Name = "labelGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.labelGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.labelGridView.Size = new System.Drawing.Size(242, 160);
            this.labelGridView.TabIndex = 18;
            // 
            // nameLabel
            // 
            this.nameLabel.HeaderText = "Name";
            this.nameLabel.Name = "nameLabel";
            // 
            // addressLabel
            // 
            this.addressLabel.HeaderText = "Address";
            this.addressLabel.Name = "addressLabel";
            // 
            // S
            // 
            this.S.Location = new System.Drawing.Point(477, 157);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(100, 20);
            this.S.TabIndex = 65;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label16.Location = new System.Drawing.Point(430, 157);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.label16.Size = new System.Drawing.Size(45, 19);
            this.label16.TabIndex = 63;
            this.label16.Text = "S";
            // 
            // indirect
            // 
            this.indirect.Location = new System.Drawing.Point(477, 114);
            this.indirect.Name = "indirect";
            this.indirect.Size = new System.Drawing.Size(100, 20);
            this.indirect.TabIndex = 62;
            // 
            // inputRegister
            // 
            this.inputRegister.Location = new System.Drawing.Point(293, 114);
            this.inputRegister.Name = "inputRegister";
            this.inputRegister.Size = new System.Drawing.Size(100, 20);
            this.inputRegister.TabIndex = 61;
            // 
            // sequenceCounter
            // 
            this.sequenceCounter.Location = new System.Drawing.Point(293, 155);
            this.sequenceCounter.Name = "sequenceCounter";
            this.sequenceCounter.Size = new System.Drawing.Size(100, 20);
            this.sequenceCounter.TabIndex = 60;
            // 
            // E
            // 
            this.E.Location = new System.Drawing.Point(477, 73);
            this.E.Name = "E";
            this.E.Size = new System.Drawing.Size(100, 20);
            this.E.TabIndex = 59;
            // 
            // stackPointer
            // 
            this.stackPointer.Location = new System.Drawing.Point(293, 73);
            this.stackPointer.Name = "stackPointer";
            this.stackPointer.Size = new System.Drawing.Size(100, 20);
            this.stackPointer.TabIndex = 58;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(430, 114);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(3, 3, 32, 3);
            this.label9.Size = new System.Drawing.Size(45, 19);
            this.label9.TabIndex = 57;
            this.label9.Text = "I";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label11.Location = new System.Drawing.Point(430, 73);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(3, 3, 28, 3);
            this.label11.Size = new System.Drawing.Size(45, 19);
            this.label11.TabIndex = 56;
            this.label11.Text = "E";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label12.Location = new System.Drawing.Point(246, 155);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(3, 3, 21, 3);
            this.label12.Size = new System.Drawing.Size(45, 19);
            this.label12.TabIndex = 55;
            this.label12.Text = "SC";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label13.Location = new System.Drawing.Point(246, 114);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.label13.Size = new System.Drawing.Size(45, 19);
            this.label13.TabIndex = 54;
            this.label13.Text = "INPR";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label14.Location = new System.Drawing.Point(246, 73);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(3, 3, 21, 3);
            this.label14.Size = new System.Drawing.Size(45, 19);
            this.label14.TabIndex = 53;
            this.label14.Text = "SP";
            // 
            // accumulator
            // 
            this.accumulator.Location = new System.Drawing.Point(108, 197);
            this.accumulator.Name = "accumulator";
            this.accumulator.Size = new System.Drawing.Size(100, 20);
            this.accumulator.TabIndex = 52;
            // 
            // addressRegister
            // 
            this.addressRegister.Location = new System.Drawing.Point(108, 73);
            this.addressRegister.Name = "addressRegister";
            this.addressRegister.Size = new System.Drawing.Size(100, 20);
            this.addressRegister.TabIndex = 51;
            // 
            // instructionRegister
            // 
            this.instructionRegister.Location = new System.Drawing.Point(108, 114);
            this.instructionRegister.Name = "instructionRegister";
            this.instructionRegister.Size = new System.Drawing.Size(100, 20);
            this.instructionRegister.TabIndex = 50;
            // 
            // dataRegister
            // 
            this.dataRegister.Location = new System.Drawing.Point(108, 157);
            this.dataRegister.Name = "dataRegister";
            this.dataRegister.Size = new System.Drawing.Size(100, 20);
            this.dataRegister.TabIndex = 49;
            // 
            // programCounter
            // 
            this.programCounter.Location = new System.Drawing.Point(108, 32);
            this.programCounter.Name = "programCounter";
            this.programCounter.Size = new System.Drawing.Size(100, 20);
            this.programCounter.TabIndex = 43;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label17.Location = new System.Drawing.Point(61, 198);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(3, 3, 21, 3);
            this.label17.Size = new System.Drawing.Size(45, 19);
            this.label17.TabIndex = 48;
            this.label17.Text = "AC";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label18.Location = new System.Drawing.Point(61, 157);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(3, 3, 19, 3);
            this.label18.Size = new System.Drawing.Size(45, 19);
            this.label18.TabIndex = 47;
            this.label18.Text = "DR";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label10.Location = new System.Drawing.Point(61, 114);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(3, 3, 24, 3);
            this.label10.Size = new System.Drawing.Size(45, 19);
            this.label10.TabIndex = 46;
            this.label10.Text = "IR";
            // 
            // lable19
            // 
            this.lable19.AutoSize = true;
            this.lable19.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lable19.Location = new System.Drawing.Point(61, 73);
            this.lable19.Name = "lable19";
            this.lable19.Padding = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.lable19.Size = new System.Drawing.Size(45, 19);
            this.lable19.TabIndex = 45;
            this.lable19.Text = "AR";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(61, 32);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(3, 3, 21, 3);
            this.label8.Size = new System.Drawing.Size(45, 19);
            this.label8.TabIndex = 44;
            this.label8.Text = "PC";
            // 
            // binButton
            // 
            this.binButton.AutoSize = true;
            this.binButton.Location = new System.Drawing.Point(425, 15);
            this.binButton.Name = "binButton";
            this.binButton.Size = new System.Drawing.Size(43, 17);
            this.binButton.TabIndex = 70;
            this.binButton.Text = "BIN";
            this.binButton.UseVisualStyleBackColor = true;
            this.binButton.CheckedChanged += new System.EventHandler(this.binButton_CheckedChanged);
            // 
            // decButton
            // 
            this.decButton.AutoSize = true;
            this.decButton.Checked = true;
            this.decButton.Location = new System.Drawing.Point(572, 15);
            this.decButton.Name = "decButton";
            this.decButton.Size = new System.Drawing.Size(47, 17);
            this.decButton.TabIndex = 71;
            this.decButton.TabStop = true;
            this.decButton.Text = "DEC";
            this.decButton.UseVisualStyleBackColor = true;
            this.decButton.CheckedChanged += new System.EventHandler(this.decButton_CheckedChanged);
            // 
            // octButton
            // 
            this.octButton.AutoSize = true;
            this.octButton.Location = new System.Drawing.Point(523, 15);
            this.octButton.Name = "octButton";
            this.octButton.Size = new System.Drawing.Size(47, 17);
            this.octButton.TabIndex = 72;
            this.octButton.Text = "OCT";
            this.octButton.UseVisualStyleBackColor = true;
            this.octButton.CheckedChanged += new System.EventHandler(this.octButton_CheckedChanged);
            // 
            // hexButton
            // 
            this.hexButton.AutoSize = true;
            this.hexButton.Location = new System.Drawing.Point(474, 15);
            this.hexButton.Name = "hexButton";
            this.hexButton.Size = new System.Drawing.Size(47, 17);
            this.hexButton.TabIndex = 73;
            this.hexButton.Text = "HEX";
            this.hexButton.UseVisualStyleBackColor = true;
            this.hexButton.CheckedChanged += new System.EventHandler(this.hexButton_CheckedChanged);
            // 
            // assemblyButton
            // 
            this.assemblyButton.BackColor = System.Drawing.Color.DarkCyan;
            this.assemblyButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.assemblyButton.FlatAppearance.BorderSize = 3;
            this.assemblyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.assemblyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.assemblyButton.Location = new System.Drawing.Point(281, 58);
            this.assemblyButton.Name = "assemblyButton";
            this.assemblyButton.Size = new System.Drawing.Size(147, 23);
            this.assemblyButton.TabIndex = 75;
            this.assemblyButton.Text = ">> Read Assembly Line";
            this.assemblyButton.UseVisualStyleBackColor = false;
            this.assemblyButton.Click += new System.EventHandler(this.assemblyButton_Click);
            // 
            // microButton
            // 
            this.microButton.BackColor = System.Drawing.Color.DarkCyan;
            this.microButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.microButton.FlatAppearance.BorderSize = 3;
            this.microButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.microButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.microButton.Location = new System.Drawing.Point(730, 59);
            this.microButton.Name = "microButton";
            this.microButton.Size = new System.Drawing.Size(151, 23);
            this.microButton.TabIndex = 76;
            this.microButton.Text = "Read Microoperation <<";
            this.microButton.UseVisualStyleBackColor = false;
            this.microButton.Click += new System.EventHandler(this.microButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(747, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 78;
            this.saveButton.Text = "Save As";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // registers
            // 
            this.registers.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.registers.Controls.Add(this.label8);
            this.registers.Controls.Add(this.lable19);
            this.registers.Controls.Add(this.label10);
            this.registers.Controls.Add(this.label18);
            this.registers.Controls.Add(this.label17);
            this.registers.Controls.Add(this.programCounter);
            this.registers.Controls.Add(this.dataRegister);
            this.registers.Controls.Add(this.instructionRegister);
            this.registers.Controls.Add(this.addressRegister);
            this.registers.Controls.Add(this.S);
            this.registers.Controls.Add(this.accumulator);
            this.registers.Controls.Add(this.label14);
            this.registers.Controls.Add(this.label16);
            this.registers.Controls.Add(this.label13);
            this.registers.Controls.Add(this.indirect);
            this.registers.Controls.Add(this.label12);
            this.registers.Controls.Add(this.inputRegister);
            this.registers.Controls.Add(this.label11);
            this.registers.Controls.Add(this.sequenceCounter);
            this.registers.Controls.Add(this.label9);
            this.registers.Controls.Add(this.E);
            this.registers.Controls.Add(this.stackPointer);
            this.registers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.registers.Location = new System.Drawing.Point(281, 88);
            this.registers.Name = "registers";
            this.registers.Size = new System.Drawing.Size(600, 230);
            this.registers.TabIndex = 79;
            this.registers.TabStop = false;
            this.registers.Text = "Registers";
            // 
            // memory
            // 
            this.memory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.memory.Controls.Add(this.label4);
            this.memory.Controls.Add(this.label5);
            this.memory.Controls.Add(this.label6);
            this.memory.Controls.Add(this.codeSegmentGridView);
            this.memory.Controls.Add(this.dataSegmentGridView);
            this.memory.Controls.Add(this.stackSegmentGridView);
            this.memory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.memory.Location = new System.Drawing.Point(281, 328);
            this.memory.Name = "memory";
            this.memory.Size = new System.Drawing.Size(847, 256);
            this.memory.TabIndex = 80;
            this.memory.TabStop = false;
            this.memory.Text = "Memory";
            // 
            // dssem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 605);
            this.Controls.Add(this.memory);
            this.Controls.Add(this.registers);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.microButton);
            this.Controls.Add(this.assemblyButton);
            this.Controls.Add(this.hexButton);
            this.Controls.Add(this.octButton);
            this.Controls.Add(this.decButton);
            this.Controls.Add(this.binButton);
            this.Controls.Add(this.labelGridView);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.microoperation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.assemblyCode);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.assemblyFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.HelpButton = true;
            this.MaximumSize = new System.Drawing.Size(1172, 644);
            this.MinimumSize = new System.Drawing.Size(1172, 644);
            this.Name = "dssem";
            this.Opacity = 0D;
            this.Text = "DSSEM";
            this.Load += new System.EventHandler(this.DSSEM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.codeSegmentGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSegmentGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackSegmentGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelGridView)).EndInit();
            this.registers.ResumeLayout(false);
            this.registers.PerformLayout();
            this.memory.ResumeLayout(false);
            this.memory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox assemblyFile;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox assemblyCode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView codeSegmentGridView;
        private System.Windows.Forms.DataGridView dataSegmentGridView;
        private System.Windows.Forms.DataGridView stackSegmentGridView;
        private System.Windows.Forms.ListBox microoperation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView labelGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataStackSegment;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressStackSegment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataSegment;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataSegment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataCodeSegment;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressCodeSegment;
        private System.Windows.Forms.TextBox S;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox indirect;
        private System.Windows.Forms.TextBox inputRegister;
        private System.Windows.Forms.TextBox sequenceCounter;
        private System.Windows.Forms.TextBox E;
        private System.Windows.Forms.TextBox stackPointer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox accumulator;
        private System.Windows.Forms.TextBox addressRegister;
        private System.Windows.Forms.TextBox instructionRegister;
        private System.Windows.Forms.TextBox dataRegister;
        private System.Windows.Forms.TextBox programCounter;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lable19;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameLabel;
        private System.Windows.Forms.RadioButton binButton;
        private System.Windows.Forms.RadioButton decButton;
        private System.Windows.Forms.RadioButton octButton;
        private System.Windows.Forms.RadioButton hexButton;
        private System.Windows.Forms.Button assemblyButton;
        private System.Windows.Forms.Button microButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox registers;
        private System.Windows.Forms.GroupBox memory;
    }
}

