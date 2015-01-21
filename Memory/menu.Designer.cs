namespace Memory
{
    partial class menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            this.btn_classique = new System.Windows.Forms.Button();
            this.btn_simple = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_classique
            // 
            this.btn_classique.BackColor = System.Drawing.Color.Chocolate;
            this.btn_classique.Location = new System.Drawing.Point(56, 206);
            this.btn_classique.Name = "btn_classique";
            this.btn_classique.Size = new System.Drawing.Size(143, 67);
            this.btn_classique.TabIndex = 0;
            this.btn_classique.Text = "version classique";
            this.btn_classique.UseVisualStyleBackColor = false;
            this.btn_classique.Click += new System.EventHandler(this.btn_classique_Click);
            // 
            // btn_simple
            // 
            this.btn_simple.BackColor = System.Drawing.Color.Chocolate;
            this.btn_simple.Location = new System.Drawing.Point(330, 206);
            this.btn_simple.Name = "btn_simple";
            this.btn_simple.Size = new System.Drawing.Size(143, 67);
            this.btn_simple.TabIndex = 0;
            this.btn_simple.Text = "version simple";
            this.btn_simple.UseVisualStyleBackColor = false;
            this.btn_simple.Click += new System.EventHandler(this.btn_simple_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Motorwerk", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(42, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenue dans Memory Z";
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Memory.Properties.Resources.DBZ_Earth_s_Special_Forces1;
            this.ClientSize = new System.Drawing.Size(534, 401);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_simple);
            this.Controls.Add(this.btn_classique);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "menu";
            this.Text = "menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_classique;
        private System.Windows.Forms.Button btn_simple;
        private System.Windows.Forms.Label label1;
    }
}