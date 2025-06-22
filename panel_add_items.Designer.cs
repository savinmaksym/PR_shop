namespace PR_shop
{
    partial class panel_add_items
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
            button1 = new Button();
            textBox_name = new TextBox();
            textBox_price = new TextBox();
            textBox_amount = new TextBox();
            textBox_image_url = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(319, 178);
            button1.Name = "button1";
            button1.Size = new Size(137, 47);
            button1.TabIndex = 0;
            button1.Text = "Добавити";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox_name
            // 
            textBox_name.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_name.Location = new Point(131, 51);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(325, 29);
            textBox_name.TabIndex = 1;
            // 
            // textBox_price
            // 
            textBox_price.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_price.Location = new Point(131, 145);
            textBox_price.Name = "textBox_price";
            textBox_price.Size = new Size(137, 29);
            textBox_price.TabIndex = 2;
            // 
            // textBox_amount
            // 
            textBox_amount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_amount.Location = new Point(131, 196);
            textBox_amount.Name = "textBox_amount";
            textBox_amount.Size = new Size(137, 29);
            textBox_amount.TabIndex = 3;
            // 
            // textBox_image_url
            // 
            textBox_image_url.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_image_url.Location = new Point(131, 96);
            textBox_image_url.Name = "textBox_image_url";
            textBox_image_url.Size = new Size(325, 29);
            textBox_image_url.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(76, 60);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 5;
            label1.Text = "назва";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(16, 105);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 6;
            label2.Text = "юрл картинки";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(86, 154);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 7;
            label3.Text = "ціна";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(55, 205);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 8;
            label4.Text = "кількість";
            // 
            // panel_add_items
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(531, 289);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_image_url);
            Controls.Add(textBox_amount);
            Controls.Add(textBox_price);
            Controls.Add(textBox_name);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "panel_add_items";
            Text = "panel_add_items";
            Load += panel_add_items_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox_name;
        private TextBox textBox_price;
        private TextBox textBox_amount;
        private TextBox textBox_image_url;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}