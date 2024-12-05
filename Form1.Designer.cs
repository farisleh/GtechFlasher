namespace GTechFlasher
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
            startButton = new Button();
            groupBox1 = new GroupBox();
            label17 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            comboBox1 = new ComboBox();
            stopButton = new Button();
            manualRadio = new RadioButton();
            autoRadio = new RadioButton();
            rfidRadio = new RadioButton();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label12 = new Label();
            label10 = new Label();
            label8 = new Label();
            label6 = new Label();
            label9 = new Label();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label1 = new Label();
            label11 = new Label();
            label4 = new Label();
            label19 = new Label();
            label2 = new Label();
            label18 = new Label();
            productionButton = new Button();
            testButton = new Button();
            debugButton = new Button();
            portBox = new ComboBox();
            baudRateBox = new ComboBox();
            connectButton = new Button();
            pictureBox2 = new PictureBox();
            label16 = new Label();
            packButton = new Button();
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BackColor = SystemColors.Highlight;
            startButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startButton.ForeColor = SystemColors.ButtonHighlight;
            startButton.Location = new Point(6, 137);
            startButton.Name = "startButton";
            startButton.Size = new Size(75, 23);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(stopButton);
            groupBox1.Controls.Add(manualRadio);
            groupBox1.Controls.Add(autoRadio);
            groupBox1.Controls.Add(startButton);
            groupBox1.Controls.Add(rfidRadio);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(18, 74);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(477, 189);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Flash Mode";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.Red;
            label17.Location = new Point(389, 96);
            label17.Name = "label17";
            label17.Size = new Size(0, 21);
            label17.TabIndex = 9;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(379, 135);
            label15.Name = "label15";
            label15.Size = new Size(0, 25);
            label15.TabIndex = 8;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.Red;
            label14.Location = new Point(263, 96);
            label14.Name = "label14";
            label14.Size = new Size(130, 21);
            label14.TabIndex = 7;
            label14.Text = "**Next S/N Flash:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(225, 45);
            label13.Name = "label13";
            label13.Size = new Size(79, 21);
            label13.TabIndex = 5;
            label13.Text = "Firmware:";
            // 
            // comboBox1
            // 
            comboBox1.FlatStyle = FlatStyle.Popup;
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(304, 42);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(167, 29);
            comboBox1.TabIndex = 4;
            // 
            // stopButton
            // 
            stopButton.BackColor = Color.Red;
            stopButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stopButton.ForeColor = SystemColors.ButtonHighlight;
            stopButton.Location = new Point(87, 137);
            stopButton.Name = "stopButton";
            stopButton.RightToLeft = RightToLeft.No;
            stopButton.Size = new Size(75, 23);
            stopButton.TabIndex = 3;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = false;
            // 
            // manualRadio
            // 
            manualRadio.AutoSize = true;
            manualRadio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            manualRadio.Location = new Point(6, 96);
            manualRadio.Name = "manualRadio";
            manualRadio.Size = new Size(80, 25);
            manualRadio.TabIndex = 2;
            manualRadio.TabStop = true;
            manualRadio.Text = "Manual";
            manualRadio.UseVisualStyleBackColor = true;
            manualRadio.CheckedChanged += manualRadio_CheckedChanged;
            // 
            // autoRadio
            // 
            autoRadio.AutoSize = true;
            autoRadio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoRadio.Location = new Point(6, 69);
            autoRadio.Name = "autoRadio";
            autoRadio.Size = new Size(61, 25);
            autoRadio.TabIndex = 1;
            autoRadio.TabStop = true;
            autoRadio.Text = "Auto";
            autoRadio.UseVisualStyleBackColor = true;
            autoRadio.CheckedChanged += autoRadio_CheckedChanged;
            // 
            // rfidRadio
            // 
            rfidRadio.AutoSize = true;
            rfidRadio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rfidRadio.Location = new Point(6, 42);
            rfidRadio.Name = "rfidRadio";
            rfidRadio.Size = new Size(168, 25);
            rfidRadio.TabIndex = 0;
            rfidRadio.TabStop = true;
            rfidRadio.Text = "RFID(Scan RFID Tag)";
            rfidRadio.UseVisualStyleBackColor = true;
            rfidRadio.CheckedChanged += rfidRadio_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(18, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 41);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 158F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 39F));
            tableLayoutPanel1.Controls.Add(label12, 0, 1);
            tableLayoutPanel1.Controls.Add(label10, 1, 4);
            tableLayoutPanel1.Controls.Add(label8, 1, 3);
            tableLayoutPanel1.Controls.Add(label6, 1, 2);
            tableLayoutPanel1.Controls.Add(label9, 0, 6);
            tableLayoutPanel1.Controls.Add(label7, 0, 5);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(label11, 0, 0);
            tableLayoutPanel1.Controls.Add(label4, 1, 1);
            tableLayoutPanel1.Controls.Add(label19, 1, 6);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(label18, 1, 5);
            tableLayoutPanel1.Location = new Point(18, 280);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(477, 234);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(6, 36);
            label12.Name = "label12";
            label12.Size = new Size(146, 20);
            label12.TabIndex = 11;
            label12.Text = "FIRMWARE VERSION";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(167, 135);
            label10.Name = "label10";
            label10.Size = new Size(0, 20);
            label10.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(167, 102);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(167, 69);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(6, 201);
            label9.Name = "label9";
            label9.Size = new Size(88, 20);
            label9.TabIndex = 8;
            label9.Text = "TIMESTAMP";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(6, 168);
            label7.Name = "label7";
            label7.Size = new Size(88, 20);
            label7.TabIndex = 6;
            label7.Text = "LONGITUDE";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 135);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 4;
            label5.Text = "LATITUDE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 102);
            label3.Name = "label3";
            label3.Size = new Size(139, 20);
            label3.TabIndex = 2;
            label3.Text = "LOCATION FIX TIME";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 69);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 0;
            label1.Text = "VBAT";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(6, 3);
            label11.Name = "label11";
            label11.Size = new Size(119, 20);
            label11.TabIndex = 10;
            label11.Text = "SERIAL NUMBER";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(167, 36);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 3;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(167, 201);
            label19.Name = "label19";
            label19.Size = new Size(0, 20);
            label19.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(167, 3);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 1;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.Location = new Point(167, 168);
            label18.Name = "label18";
            label18.Size = new Size(0, 20);
            label18.TabIndex = 12;
            // 
            // productionButton
            // 
            productionButton.BackColor = SystemColors.Highlight;
            productionButton.FlatStyle = FlatStyle.Flat;
            productionButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            productionButton.ForeColor = SystemColors.ButtonHighlight;
            productionButton.Location = new Point(568, 445);
            productionButton.Name = "productionButton";
            productionButton.Size = new Size(86, 36);
            productionButton.TabIndex = 5;
            productionButton.Text = "Production";
            productionButton.UseVisualStyleBackColor = false;
            productionButton.Click += productionButton_Click;
            // 
            // testButton
            // 
            testButton.BackColor = SystemColors.Highlight;
            testButton.FlatStyle = FlatStyle.Flat;
            testButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            testButton.ForeColor = SystemColors.ButtonHighlight;
            testButton.Location = new Point(660, 445);
            testButton.Name = "testButton";
            testButton.Size = new Size(86, 36);
            testButton.TabIndex = 6;
            testButton.Text = "Test";
            testButton.UseVisualStyleBackColor = false;
            testButton.Click += testButton_Click;
            // 
            // debugButton
            // 
            debugButton.BackColor = SystemColors.Highlight;
            debugButton.FlatStyle = FlatStyle.Flat;
            debugButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            debugButton.ForeColor = SystemColors.ButtonHighlight;
            debugButton.Location = new Point(752, 445);
            debugButton.Name = "debugButton";
            debugButton.Size = new Size(86, 36);
            debugButton.TabIndex = 7;
            debugButton.Text = "Debug";
            debugButton.UseVisualStyleBackColor = false;
            debugButton.Click += debugButton_Click;
            // 
            // portBox
            // 
            portBox.FlatStyle = FlatStyle.Popup;
            portBox.FormattingEnabled = true;
            portBox.Location = new Point(510, 56);
            portBox.Name = "portBox";
            portBox.Size = new Size(121, 23);
            portBox.TabIndex = 8;
            portBox.Text = "PORT";
            // 
            // baudRateBox
            // 
            baudRateBox.FlatStyle = FlatStyle.Popup;
            baudRateBox.FormattingEnabled = true;
            baudRateBox.Location = new Point(637, 56);
            baudRateBox.Name = "baudRateBox";
            baudRateBox.Size = new Size(121, 23);
            baudRateBox.TabIndex = 9;
            baudRateBox.Text = "BAUD RATE";
            // 
            // connectButton
            // 
            connectButton.BackColor = SystemColors.Highlight;
            connectButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            connectButton.ForeColor = SystemColors.ButtonHighlight;
            connectButton.Location = new Point(905, 49);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(89, 33);
            connectButton.TabIndex = 10;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = false;
            connectButton.Click += connectButton_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(772, 520);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(222, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(694, 529);
            label16.Name = "label16";
            label16.Size = new Size(80, 15);
            label16.TabIndex = 12;
            label16.Text = "Innovation by";
            // 
            // packButton
            // 
            packButton.BackColor = SystemColors.Highlight;
            packButton.FlatStyle = FlatStyle.Flat;
            packButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            packButton.ForeColor = SystemColors.ButtonHighlight;
            packButton.Location = new Point(844, 445);
            packButton.Name = "packButton";
            packButton.Size = new Size(86, 36);
            packButton.TabIndex = 13;
            packButton.Text = "Pack";
            packButton.UseVisualStyleBackColor = false;
            packButton.Click += packButton_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.WindowText;
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(510, 85);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(484, 350);
            textBox1.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 562);
            Controls.Add(textBox1);
            Controls.Add(packButton);
            Controls.Add(label16);
            Controls.Add(pictureBox2);
            Controls.Add(connectButton);
            Controls.Add(baudRateBox);
            Controls.Add(portBox);
            Controls.Add(debugButton);
            Controls.Add(testButton);
            Controls.Add(productionButton);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "GTech Flasher";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private RadioButton manualRadio;
        private RadioButton autoRadio;
        private RadioButton rfidRadio;
        private Button stopButton;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label14;
        private Label label13;
        private ComboBox comboBox1;
        private Label label15;
        private Button productionButton;
        private Button testButton;
        private Button debugButton;
        private ComboBox portBox;
        private ComboBox baudRateBox;
        private Button connectButton;
        private PictureBox pictureBox2;
        private Label label16;
        private Label label17;
        private Button packButton;
        private TextBox textBox1;
        private Label label12;
        private Label label11;
        private Label label19;
        private Label label18;
    }
}
