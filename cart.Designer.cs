namespace PR_shop
{
    partial class cart
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
            flowLayoutPanel = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            label_total_price = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Location = new Point(0, 1);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(353, 335);
            flowLayoutPanel.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(359, 278);
            button1.Name = "button1";
            button1.Size = new Size(187, 47);
            button1.TabIndex = 1;
            button1.Text = "Замовити";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.Location = new Point(359, 1);
            button2.Name = "button2";
            button2.Size = new Size(187, 34);
            button2.TabIndex = 2;
            button2.Text = "Очистити";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label_total_price
            // 
            label_total_price.AutoSize = true;
            label_total_price.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_total_price.Location = new Point(355, 255);
            label_total_price.Name = "label_total_price";
            label_total_price.Size = new Size(0, 20);
            label_total_price.TabIndex = 4;
            // 
            // cart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 337);
            Controls.Add(label_total_price);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(flowLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "cart";
            Text = "кошик";
            Load += cart_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private Button button1;
        private Button button2;
        private Label label_total_price;
    }
}