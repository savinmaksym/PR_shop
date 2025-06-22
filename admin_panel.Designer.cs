namespace PR_shop
{
    partial class admin_panel
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
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.Location = new Point(25, 34);
            button1.Name = "button1";
            button1.Size = new Size(193, 58);
            button1.TabIndex = 0;
            button1.Text = "панель добавлення товарів";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.Location = new Point(25, 107);
            button2.Name = "button2";
            button2.Size = new Size(193, 58);
            button2.TabIndex = 1;
            button2.Text = "редагування та видалення товара";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // admin_panel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(261, 239);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "admin_panel";
            Text = "Меню адміністратора";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
    }
}