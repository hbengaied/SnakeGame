namespace SnakeGame
{
    partial class CreateOrJoinServer
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
            this.Create = new System.Windows.Forms.Button();
            this.Join = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Create
            // 
            this.Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create.Location = new System.Drawing.Point(12, 28);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(175, 48);
            this.Create.TabIndex = 0;
            this.Create.Text = "Creer Un Serveur";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Join
            // 
            this.Join.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Join.Location = new System.Drawing.Point(207, 28);
            this.Join.Name = "Join";
            this.Join.Size = new System.Drawing.Size(175, 48);
            this.Join.TabIndex = 0;
            this.Join.Text = "Rejoindre Un Serveur";
            this.Join.UseVisualStyleBackColor = true;
            this.Join.Click += new System.EventHandler(this.Join_Click);
            // 
            // CreateOrJoinServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 107);
            this.Controls.Add(this.Join);
            this.Controls.Add(this.Create);
            this.Name = "CreateOrJoinServer";
            this.Text = "CreateOrJoinServer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button Join;
    }
}