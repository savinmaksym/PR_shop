namespace PR_shop
{
    partial class shop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(shop));
            flowLayoutPanel = new FlowLayoutPanel();
            label_shop_username = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label_shop_name = new Label();
            label_admin_panel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Location = new Point(140, 0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(510, 411);
            flowLayoutPanel.TabIndex = 0;
            // 
            // label_shop_username
            // 
            label_shop_username.AutoSize = true;
            label_shop_username.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_shop_username.Location = new Point(735, 20);
            label_shop_username.Name = "label_shop_username";
            label_shop_username.Size = new Size(81, 21);
            label_shop_username.TabIndex = 1;
            label_shop_username.Text = "username";
            label_shop_username.TextAlign = ContentAlignment.TopRight;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.exit;
            pictureBox1.Location = new Point(822, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 35);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.cart;
            pictureBox2.Location = new Point(647, 1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 45);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label_shop_name
            // 
            label_shop_name.AutoSize = true;
            label_shop_name.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_shop_name.Location = new Point(3, 4);
            label_shop_name.Name = "label_shop_name";
            label_shop_name.Size = new Size(128, 25);
            label_shop_name.TabIndex = 4;
            label_shop_name.Text = "Говно Шоп";
            // 
            // label_admin_panel
            // 
            label_admin_panel.AutoSize = true;
            label_admin_panel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_admin_panel.ForeColor = Color.Blue;
            label_admin_panel.Location = new Point(747, 382);
            label_admin_panel.Name = "label_admin_panel";
            label_admin_panel.Size = new Size(110, 20);
            label_admin_panel.TabIndex = 5;
            label_admin_panel.Text = "Админ панель";
            label_admin_panel.Click += label1_Click;
            // 
            // shop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(863, 411);
            Controls.Add(label_admin_panel);
            Controls.Add(label_shop_name);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label_shop_username);
            Controls.Add(flowLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "shop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Магазин";
            Load += shop_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private Label label_shop_username;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label_shop_name;
        private Label label_admin_panel;
    }
}