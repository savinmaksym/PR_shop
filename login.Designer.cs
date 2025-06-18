namespace PR_shop
{
    partial class login
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
            label_login_login = new Label();
            textBox_name = new TextBox();
            textBox_password = new TextBox();
            label_login_name = new Label();
            label_login_password = new Label();
            button_login_login = new Button();
            label_login_registr = new Label();
            label_login_error1 = new Label();
            label_login_error2 = new Label();
            SuspendLayout();
            // 
            // label_login_login
            // 
            label_login_login.AutoSize = true;
            label_login_login.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_login_login.Location = new Point(237, 34);
            label_login_login.Name = "label_login_login";
            label_login_login.Size = new Size(98, 37);
            label_login_login.TabIndex = 0;
            label_login_login.Text = "Увійти";
            // 
            // textBox_name
            // 
            textBox_name.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_name.Location = new Point(200, 133);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(173, 39);
            textBox_name.TabIndex = 1;
            // 
            // textBox_password
            // 
            textBox_password.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_password.Location = new Point(200, 219);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(173, 39);
            textBox_password.TabIndex = 2;
            // 
            // label_login_name
            // 
            label_login_name.AutoSize = true;
            label_login_name.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_login_name.Location = new Point(200, 100);
            label_login_name.Name = "label_login_name";
            label_login_name.Size = new Size(50, 30);
            label_login_name.TabIndex = 3;
            label_login_name.Text = "Ім'я";
            // 
            // label_login_password
            // 
            label_login_password.AutoSize = true;
            label_login_password.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_login_password.Location = new Point(200, 186);
            label_login_password.Name = "label_login_password";
            label_login_password.Size = new Size(88, 30);
            label_login_password.TabIndex = 4;
            label_login_password.Text = "Пароль";
            // 
            // button_login_login
            // 
            button_login_login.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_login_login.Location = new Point(200, 283);
            button_login_login.Name = "button_login_login";
            button_login_login.Size = new Size(173, 52);
            button_login_login.TabIndex = 5;
            button_login_login.Text = "Увійти";
            button_login_login.UseVisualStyleBackColor = true;
            button_login_login.Click += button_login_login_Click;
            // 
            // label_login_registr
            // 
            label_login_registr.AutoSize = true;
            label_login_registr.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_login_registr.ForeColor = Color.MidnightBlue;
            label_login_registr.Location = new Point(225, 410);
            label_login_registr.Name = "label_login_registr";
            label_login_registr.Size = new Size(125, 20);
            label_login_registr.TabIndex = 6;
            label_login_registr.Text = "Зареєструватись";
            label_login_registr.MouseClick += label_login_registr_MouseClick;
            // 
            // label_login_error1
            // 
            label_login_error1.AutoSize = true;
            label_login_error1.ForeColor = Color.Brown;
            label_login_error1.Location = new Point(200, 175);
            label_login_error1.Name = "label_login_error1";
            label_login_error1.Size = new Size(38, 15);
            label_login_error1.TabIndex = 7;
            label_login_error1.Text = "error1";
            label_login_error1.Visible = false;
            // 
            // label_login_error2
            // 
            label_login_error2.AutoSize = true;
            label_login_error2.ForeColor = Color.Brown;
            label_login_error2.Location = new Point(200, 261);
            label_login_error2.Name = "label_login_error2";
            label_login_error2.Size = new Size(38, 15);
            label_login_error2.TabIndex = 8;
            label_login_error2.Text = "error2";
            label_login_error2.Visible = false;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 461);
            Controls.Add(label_login_error2);
            Controls.Add(label_login_error1);
            Controls.Add(label_login_registr);
            Controls.Add(button_login_login);
            Controls.Add(label_login_password);
            Controls.Add(label_login_name);
            Controls.Add(textBox_password);
            Controls.Add(textBox_name);
            Controls.Add(label_login_login);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "login";
            Text = "Вхід";
            Load += login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_login_login;
        private TextBox textBox_name;
        private TextBox textBox_password;
        private Label label_login_name;
        private Label label_login_password;
        private Button button_login_login;
        private Label label_login_registr;
        private Label label_login_error1;
        private Label label_login_error2;
    }
}
