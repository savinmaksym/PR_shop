namespace PR_shop
{
    partial class panel_edit_items
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
            button_delet = new Button();
            button_search = new Button();
            button_save = new Button();
            comboBox_name = new ComboBox();
            textBox_name = new TextBox();
            textBox_count = new TextBox();
            textBox_price = new TextBox();
            textBox_image_url = new TextBox();
            pictureBox = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // button_delet
            // 
            button_delet.Location = new Point(330, 257);
            button_delet.Name = "button_delet";
            button_delet.Size = new Size(101, 34);
            button_delet.TabIndex = 1;
            button_delet.Text = "видалити";
            button_delet.UseVisualStyleBackColor = true;
            button_delet.Click += this.button_delet_Click;
            // 
            // button_search
            // 
            button_search.Location = new Point(75, 257);
            button_search.Name = "button_search";
            button_search.Size = new Size(101, 34);
            button_search.TabIndex = 2;
            button_search.Text = "Знайти";
            button_search.UseVisualStyleBackColor = true;
            button_search.Click += button_search_Click;
            // 
            // button_save
            // 
            button_save.Location = new Point(202, 257);
            button_save.Name = "button_save";
            button_save.Size = new Size(101, 34);
            button_save.TabIndex = 3;
            button_save.Text = "зберегти";
            button_save.UseVisualStyleBackColor = true;
            button_save.Click += button_save_Click;
            // 
            // comboBox_name
            // 
            comboBox_name.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBox_name.FormattingEnabled = true;
            comboBox_name.Location = new Point(12, 12);
            comboBox_name.Name = "comboBox_name";
            comboBox_name.Size = new Size(463, 38);
            comboBox_name.TabIndex = 4;
            // 
            // textBox_name
            // 
            textBox_name.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_name.Location = new Point(241, 68);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(234, 29);
            textBox_name.TabIndex = 5;
            // 
            // textBox_count
            // 
            textBox_count.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_count.Location = new Point(241, 138);
            textBox_count.Name = "textBox_count";
            textBox_count.Size = new Size(234, 29);
            textBox_count.TabIndex = 6;
            // 
            // textBox_price
            // 
            textBox_price.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_price.Location = new Point(241, 103);
            textBox_price.Name = "textBox_price";
            textBox_price.Size = new Size(234, 29);
            textBox_price.TabIndex = 7;
            // 
            // textBox_image_url
            // 
            textBox_image_url.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_image_url.Location = new Point(241, 173);
            textBox_image_url.Name = "textBox_image_url";
            textBox_image_url.Size = new Size(234, 29);
            textBox_image_url.TabIndex = 8;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(12, 68);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(134, 134);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 9;
            pictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(152, 76);
            label1.Name = "label1";
            label1.Size = new Size(58, 21);
            label1.TabIndex = 10;
            label1.Text = "Назва:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(152, 111);
            label2.Name = "label2";
            label2.Size = new Size(47, 21);
            label2.TabIndex = 11;
            label2.Text = "Ціна:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(152, 141);
            label3.Name = "label3";
            label3.Size = new Size(80, 21);
            label3.TabIndex = 12;
            label3.Text = "Кількість:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(152, 176);
            label4.Name = "label4";
            label4.Size = new Size(83, 21);
            label4.TabIndex = 13;
            label4.Text = "URL карт.:";
            // 
            // panel_edit_items
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 322);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox);
            Controls.Add(textBox_image_url);
            Controls.Add(textBox_price);
            Controls.Add(textBox_count);
            Controls.Add(textBox_name);
            Controls.Add(comboBox_name);
            Controls.Add(button_save);
            Controls.Add(button_search);
            Controls.Add(button_delet);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "panel_edit_items";
            Text = "panel_delet_items";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button_delet;
        private Button button_search;
        private Button button_save;
        private ComboBox comboBox_name;
        private TextBox textBox_name;
        private TextBox textBox_count;
        private TextBox textBox_price;
        private TextBox textBox_image_url;
        private PictureBox pictureBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}