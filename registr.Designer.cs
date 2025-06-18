namespace PR_shop
{
    partial class registr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registr));
            label_registr_login = new Label();
            button_registr_registr = new Button();
            label_registr_password = new Label();
            label_registr_name = new Label();
            textBox_password = new TextBox();
            textBox_name = new TextBox();
            label_registr_registr = new Label();
            label_registr_error2 = new Label();
            label_registr_error1 = new Label();
            checkBox_save_data = new CheckBox();
            SuspendLayout();
            // 
            // label_registr_login
            // 
            label_registr_login.AutoSize = true;
            label_registr_login.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_registr_login.ForeColor = Color.MidnightBlue;
            label_registr_login.Location = new Point(265, 418);
            label_registr_login.Name = "label_registr_login";
            label_registr_login.Size = new Size(39, 20);
            label_registr_login.TabIndex = 13;
            label_registr_login.Text = "Вхід";
            label_registr_login.Click += label_registr_login_Click;
            // 
            // button_registr_registr
            // 
            button_registr_registr.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_registr_registr.Location = new Point(206, 280);
            button_registr_registr.Name = "button_registr_registr";
            button_registr_registr.Size = new Size(173, 52);
            button_registr_registr.TabIndex = 12;
            button_registr_registr.Text = "Зареєструвати";
            button_registr_registr.UseVisualStyleBackColor = true;
            button_registr_registr.Click += button_registr_registr_Click;
            // 
            // label_registr_password
            // 
            label_registr_password.AutoSize = true;
            label_registr_password.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_registr_password.Location = new Point(206, 184);
            label_registr_password.Name = "label_registr_password";
            label_registr_password.Size = new Size(88, 30);
            label_registr_password.TabIndex = 11;
            label_registr_password.Text = "Пароль";
            // 
            // label_registr_name
            // 
            label_registr_name.AutoSize = true;
            label_registr_name.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_registr_name.Location = new Point(206, 98);
            label_registr_name.Name = "label_registr_name";
            label_registr_name.Size = new Size(50, 30);
            label_registr_name.TabIndex = 10;
            label_registr_name.Text = "Ім'я";
            // 
            // textBox_password
            // 
            textBox_password.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_password.Location = new Point(206, 217);
            textBox_password.Name = "textBox_password";
            textBox_password.PasswordChar = '*';
            textBox_password.Size = new Size(173, 39);
            textBox_password.TabIndex = 9;
            // 
            // textBox_name
            // 
            textBox_name.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_name.Location = new Point(206, 131);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(173, 39);
            textBox_name.TabIndex = 8;
            // 
            // label_registr_registr
            // 
            label_registr_registr.AutoSize = true;
            label_registr_registr.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_registr_registr.Location = new Point(180, 42);
            label_registr_registr.Name = "label_registr_registr";
            label_registr_registr.Size = new Size(228, 37);
            label_registr_registr.TabIndex = 7;
            label_registr_registr.Text = "Зареєструватись";
            // 
            // label_registr_error2
            // 
            label_registr_error2.AutoSize = true;
            label_registr_error2.ForeColor = Color.Brown;
            label_registr_error2.Location = new Point(206, 259);
            label_registr_error2.Name = "label_registr_error2";
            label_registr_error2.Size = new Size(38, 15);
            label_registr_error2.TabIndex = 15;
            label_registr_error2.Text = "error2";
            label_registr_error2.Visible = false;
            // 
            // label_registr_error1
            // 
            label_registr_error1.AutoSize = true;
            label_registr_error1.ForeColor = Color.Brown;
            label_registr_error1.Location = new Point(206, 173);
            label_registr_error1.Name = "label_registr_error1";
            label_registr_error1.Size = new Size(38, 15);
            label_registr_error1.TabIndex = 14;
            label_registr_error1.Text = "error1";
            label_registr_error1.Visible = false;
            // 
            // checkBox_save_data
            // 
            checkBox_save_data.AutoSize = true;
            checkBox_save_data.Location = new Point(206, 338);
            checkBox_save_data.Name = "checkBox_save_data";
            checkBox_save_data.Size = new Size(155, 19);
            checkBox_save_data.TabIndex = 16;
            checkBox_save_data.Text = "зберегти дані для входу";
            checkBox_save_data.UseVisualStyleBackColor = true;
            // 
            // registr
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 461);
            Controls.Add(checkBox_save_data);
            Controls.Add(label_registr_error2);
            Controls.Add(label_registr_error1);
            Controls.Add(label_registr_login);
            Controls.Add(button_registr_registr);
            Controls.Add(label_registr_password);
            Controls.Add(label_registr_name);
            Controls.Add(textBox_password);
            Controls.Add(textBox_name);
            Controls.Add(label_registr_registr);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "registr";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Зареєструватись";
            Load += registr_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_registr_login;
        private Button button_registr_registr;
        private Label label_registr_password;
        private Label label_registr_name;
        private TextBox textBox_password;
        private TextBox textBox_name;
        private Label label_registr_registr;
        private Label label_registr_error2;
        private Label label_registr_error1;
        private CheckBox checkBox_save_data;
    }
}