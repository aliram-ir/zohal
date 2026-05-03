namespace Test
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
            TopPanel = new Panel();
            statusStrip1 = new StatusStrip();
            RightPanel = new Panel();
            groupBox2 = new GroupBox();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            button17 = new Button();
            NationalIdentityInquiryBtn = new Button();
            groupBox1 = new GroupBox();
            BouncedChequeBtn = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            card_inquiryBtn = new Button();
            MainPanel = new Panel();
            RightPanel.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // TopPanel
            // 
            TopPanel.Dock = DockStyle.Top;
            TopPanel.Font = new Font("Tahoma", 9F);
            TopPanel.Location = new Point(0, 0);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(818, 53);
            TopPanel.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Font = new Font("Tahoma", 9F);
            statusStrip1.Location = new Point(0, 571);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(818, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // RightPanel
            // 
            RightPanel.AutoScroll = true;
            RightPanel.Controls.Add(groupBox2);
            RightPanel.Controls.Add(groupBox1);
            RightPanel.Dock = DockStyle.Right;
            RightPanel.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RightPanel.Location = new Point(593, 53);
            RightPanel.Name = "RightPanel";
            RightPanel.RightToLeft = RightToLeft.Yes;
            RightPanel.Size = new Size(225, 518);
            RightPanel.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button14);
            groupBox2.Controls.Add(button15);
            groupBox2.Controls.Add(button16);
            groupBox2.Controls.Add(button17);
            groupBox2.Controls.Add(NationalIdentityInquiryBtn);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 236);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(225, 147);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "احراز هویت";
            // 
            // button14
            // 
            button14.Dock = DockStyle.Top;
            button14.Location = new Point(3, 110);
            button14.Name = "button14";
            button14.Size = new Size(219, 23);
            button14.TabIndex = 6;
            button14.Text = "شاهکار (تطابق کد ملی و موبایل)​";
            button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            button15.Dock = DockStyle.Top;
            button15.Location = new Point(3, 87);
            button15.Name = "button15";
            button15.Size = new Size(219, 23);
            button15.TabIndex = 5;
            button15.Text = "تطابق کارت و نام صاحب کارت​";
            button15.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            button16.Dock = DockStyle.Top;
            button16.Location = new Point(3, 64);
            button16.Name = "button16";
            button16.Size = new Size(219, 23);
            button16.TabIndex = 4;
            button16.Text = "تطابق شماره کارت و کد ملی​";
            button16.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            button17.Dock = DockStyle.Top;
            button17.Location = new Point(3, 41);
            button17.Name = "button17";
            button17.Size = new Size(219, 23);
            button17.TabIndex = 3;
            button17.Text = "تطابق کد ملی و شماره شبا​";
            button17.UseVisualStyleBackColor = true;
            // 
            // NationalIdentityInquiryBtn
            // 
            NationalIdentityInquiryBtn.Dock = DockStyle.Top;
            NationalIdentityInquiryBtn.Location = new Point(3, 18);
            NationalIdentityInquiryBtn.Name = "NationalIdentityInquiryBtn";
            NationalIdentityInquiryBtn.Size = new Size(219, 23);
            NationalIdentityInquiryBtn.TabIndex = 2;
            NationalIdentityInquiryBtn.Text = "استعلام اطلاعات هویتی";
            NationalIdentityInquiryBtn.UseVisualStyleBackColor = true;
            NationalIdentityInquiryBtn.Click += NationalIdentityInquiryBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BouncedChequeBtn);
            groupBox1.Controls.Add(button8);
            groupBox1.Controls.Add(button7);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(card_inquiryBtn);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(225, 236);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "بانکی";
            // 
            // BouncedChequeBtn
            // 
            BouncedChequeBtn.Dock = DockStyle.Top;
            BouncedChequeBtn.Location = new Point(3, 202);
            BouncedChequeBtn.Name = "BouncedChequeBtn";
            BouncedChequeBtn.Size = new Size(219, 23);
            BouncedChequeBtn.TabIndex = 10;
            BouncedChequeBtn.Text = "استعلام چک برگشتی​";
            BouncedChequeBtn.UseVisualStyleBackColor = true;
            BouncedChequeBtn.Click += BouncedChequeBtn_Click;
            // 
            // button8
            // 
            button8.Dock = DockStyle.Top;
            button8.Location = new Point(3, 179);
            button8.Name = "button8";
            button8.Size = new Size(219, 23);
            button8.TabIndex = 9;
            button8.Text = "استعلام چک صیادی​";
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Top;
            button7.Location = new Point(3, 156);
            button7.Name = "button7";
            button7.Size = new Size(219, 23);
            button7.TabIndex = 8;
            button7.Text = "استعلام شبا​";
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Top;
            button6.Location = new Point(3, 133);
            button6.Name = "button6";
            button6.Size = new Size(219, 23);
            button6.TabIndex = 7;
            button6.Text = "تبدیل کارت به حساب​";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Top;
            button5.Location = new Point(3, 110);
            button5.Name = "button5";
            button5.Size = new Size(219, 23);
            button5.TabIndex = 6;
            button5.Text = "تطابق شبا و نام صاحب شبا​";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Top;
            button4.Location = new Point(3, 87);
            button4.Name = "button4";
            button4.Size = new Size(219, 23);
            button4.TabIndex = 5;
            button4.Text = "تطابق کارت و نام صاحب کارت​";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.Location = new Point(3, 64);
            button3.Name = "button3";
            button3.Size = new Size(219, 23);
            button3.TabIndex = 4;
            button3.Text = "تبدیل حساب به شبا​";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.Location = new Point(3, 41);
            button2.Name = "button2";
            button2.Size = new Size(219, 23);
            button2.TabIndex = 3;
            button2.Text = "تبدیل کارت به شبا​";
            button2.UseVisualStyleBackColor = true;
            // 
            // card_inquiryBtn
            // 
            card_inquiryBtn.Dock = DockStyle.Top;
            card_inquiryBtn.Location = new Point(3, 18);
            card_inquiryBtn.Name = "card_inquiryBtn";
            card_inquiryBtn.Size = new Size(219, 23);
            card_inquiryBtn.TabIndex = 2;
            card_inquiryBtn.Text = "استعلام نام صاحب کارت​";
            card_inquiryBtn.UseVisualStyleBackColor = true;
            card_inquiryBtn.Click += card_inquiryBtn_Click;
            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Font = new Font("Tahoma", 9F);
            MainPanel.Location = new Point(0, 53);
            MainPanel.Name = "MainPanel";
            MainPanel.RightToLeft = RightToLeft.Yes;
            MainPanel.Size = new Size(593, 518);
            MainPanel.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 593);
            Controls.Add(MainPanel);
            Controls.Add(RightPanel);
            Controls.Add(statusStrip1);
            Controls.Add(TopPanel);
            Name = "Form1";
            Text = "Form1";
            RightPanel.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel TopPanel;
        private StatusStrip statusStrip1;
        private Panel RightPanel;
        private Panel MainPanel;
        private GroupBox groupBox1;
        private Button BouncedChequeBtn;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button card_inquiryBtn;
        private GroupBox groupBox2;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button NationalIdentityInquiryBtn;
    }
}
