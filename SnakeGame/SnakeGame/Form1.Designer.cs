namespace SnakeGame
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.StartButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LevelOne = new System.Windows.Forms.Button();
            this.LevelTwo = new System.Windows.Forms.Button();
            this.LevelThree = new System.Windows.Forms.Button();
            this.Score = new System.Windows.Forms.Label();
            this.HighScore = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.GodMod = new System.Windows.Forms.Button();
            this.PickDifficult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Lime;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(600, 600);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.GameTimer);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(658, 223);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(463, 53);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartGame);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::SnakeGame.Properties.Resources.snake_text;
            this.pictureBox2.Location = new System.Drawing.Point(658, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(463, 157);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // LevelOne
            // 
            this.LevelOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.LevelOne.Location = new System.Drawing.Point(659, 452);
            this.LevelOne.Name = "LevelOne";
            this.LevelOne.Size = new System.Drawing.Size(200, 53);
            this.LevelOne.TabIndex = 1;
            this.LevelOne.Text = "Lent";
            this.LevelOne.UseVisualStyleBackColor = true;
            this.LevelOne.Click += new System.EventHandler(this.LevelLent);
            // 
            // LevelTwo
            // 
            this.LevelTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelTwo.Location = new System.Drawing.Point(905, 452);
            this.LevelTwo.Name = "LevelTwo";
            this.LevelTwo.Size = new System.Drawing.Size(200, 53);
            this.LevelTwo.TabIndex = 1;
            this.LevelTwo.Text = "Rapide";
            this.LevelTwo.UseVisualStyleBackColor = true;
            this.LevelTwo.Click += new System.EventHandler(this.LevelRapide);
            // 
            // LevelThree
            // 
            this.LevelThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.LevelThree.Location = new System.Drawing.Point(659, 524);
            this.LevelThree.Name = "LevelThree";
            this.LevelThree.Size = new System.Drawing.Size(200, 53);
            this.LevelThree.TabIndex = 1;
            this.LevelThree.Text = "Ultra Rapide";
            this.LevelThree.UseVisualStyleBackColor = true;
            this.LevelThree.Click += new System.EventHandler(this.LevelUltraRapide);
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.Score.Location = new System.Drawing.Point(665, 291);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(107, 31);
            this.Score.TabIndex = 3;
            this.Score.Text = "Score :";
            // 
            // HighScore
            // 
            this.HighScore.AutoSize = true;
            this.HighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.HighScore.Location = new System.Drawing.Point(665, 338);
            this.HighScore.Name = "HighScore";
            this.HighScore.Size = new System.Drawing.Size(175, 31);
            this.HighScore.TabIndex = 3;
            this.HighScore.Text = "High Score :";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "body.png");
            this.imageList.Images.SetKeyName(1, "food.png");
            this.imageList.Images.SetKeyName(2, "head.png");
            this.imageList.Images.SetKeyName(3, "wall.png");
            // 
            // GodMod
            // 
            this.GodMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.GodMod.Location = new System.Drawing.Point(905, 524);
            this.GodMod.Name = "GodMod";
            this.GodMod.Size = new System.Drawing.Size(200, 53);
            this.GodMod.TabIndex = 1;
            this.GodMod.Text = "God Mod";
            this.GodMod.UseVisualStyleBackColor = true;
            this.GodMod.Click += new System.EventHandler(this.LevelGodMod);
            // 
            // PickDifficult
            // 
            this.PickDifficult.AutoSize = true;
            this.PickDifficult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.PickDifficult.Location = new System.Drawing.Point(665, 397);
            this.PickDifficult.Name = "PickDifficult";
            this.PickDifficult.Size = new System.Drawing.Size(147, 31);
            this.PickDifficult.TabIndex = 3;
            this.PickDifficult.Text = "Difficulté :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 656);
            this.Controls.Add(this.PickDifficult);
            this.Controls.Add(this.HighScore);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.GodMod);
            this.Controls.Add(this.LevelThree);
            this.Controls.Add(this.LevelOne);
            this.Controls.Add(this.LevelTwo);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button LevelOne;
        private System.Windows.Forms.Button LevelTwo;
        private System.Windows.Forms.Button LevelThree;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label HighScore;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button GodMod;
        private System.Windows.Forms.Label PickDifficult;
    }
}

