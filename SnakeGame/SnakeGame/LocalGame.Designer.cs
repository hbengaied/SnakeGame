namespace SnakeGame
{
    partial class LocalGame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalGame));
            this.StartButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.HighScore = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LevelThree = new System.Windows.Forms.Button();
            this.LevelOne = new System.Windows.Forms.Button();
            this.LevelTwo = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.PickDifficult = new System.Windows.Forms.Label();
            this.GodMod = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(658, 223);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(463, 53);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartGame);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Lime;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(600, 600);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.GameTimer);
            // 
            // HighScore
            // 
            this.HighScore.AutoSize = true;
            this.HighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.HighScore.Location = new System.Drawing.Point(654, 327);
            this.HighScore.Name = "HighScore";
            this.HighScore.Size = new System.Drawing.Size(175, 31);
            this.HighScore.TabIndex = 11;
            this.HighScore.Text = "High Score :";
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.Score.Location = new System.Drawing.Point(654, 280);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(107, 31);
            this.Score.TabIndex = 12;
            this.Score.Text = "Score :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::SnakeGame.Properties.Resources.snake_text;
            this.pictureBox2.Location = new System.Drawing.Point(658, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(463, 157);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // LevelThree
            // 
            this.LevelThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.LevelThree.Location = new System.Drawing.Point(648, 513);
            this.LevelThree.Name = "LevelThree";
            this.LevelThree.Size = new System.Drawing.Size(200, 53);
            this.LevelThree.TabIndex = 6;
            this.LevelThree.Text = "Ultra Rapide";
            this.LevelThree.UseVisualStyleBackColor = true;
            this.LevelThree.Click += new System.EventHandler(this.LevelUltraRapide);
            // 
            // LevelOne
            // 
            this.LevelOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.LevelOne.Location = new System.Drawing.Point(648, 441);
            this.LevelOne.Name = "LevelOne";
            this.LevelOne.Size = new System.Drawing.Size(200, 53);
            this.LevelOne.TabIndex = 7;
            this.LevelOne.Text = "Lent";
            this.LevelOne.UseVisualStyleBackColor = true;
            this.LevelOne.Click += new System.EventHandler(this.LevelLent);
            // 
            // LevelTwo
            // 
            this.LevelTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelTwo.Location = new System.Drawing.Point(894, 441);
            this.LevelTwo.Name = "LevelTwo";
            this.LevelTwo.Size = new System.Drawing.Size(200, 53);
            this.LevelTwo.TabIndex = 8;
            this.LevelTwo.Text = "Rapide";
            this.LevelTwo.UseVisualStyleBackColor = true;
            this.LevelTwo.Click += new System.EventHandler(this.LevelRapide);
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
            // PickDifficult
            // 
            this.PickDifficult.AutoSize = true;
            this.PickDifficult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.PickDifficult.Location = new System.Drawing.Point(654, 386);
            this.PickDifficult.Name = "PickDifficult";
            this.PickDifficult.Size = new System.Drawing.Size(147, 31);
            this.PickDifficult.TabIndex = 13;
            this.PickDifficult.Text = "Difficulté :";
            // 
            // GodMod
            // 
            this.GodMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.GodMod.Location = new System.Drawing.Point(894, 513);
            this.GodMod.Name = "GodMod";
            this.GodMod.Size = new System.Drawing.Size(200, 53);
            this.GodMod.TabIndex = 9;
            this.GodMod.Text = "God Mod";
            this.GodMod.UseVisualStyleBackColor = true;
            this.GodMod.Click += new System.EventHandler(this.LevelGodMod);
            // 
            // LocalGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 649);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.HighScore);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LevelThree);
            this.Controls.Add(this.LevelOne);
            this.Controls.Add(this.LevelTwo);
            this.Controls.Add(this.PickDifficult);
            this.Controls.Add(this.GodMod);
            this.Name = "LocalGame";
            this.Text = "LocalGame";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label HighScore;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button LevelThree;
        private System.Windows.Forms.Button LevelOne;
        private System.Windows.Forms.Button LevelTwo;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label PickDifficult;
        private System.Windows.Forms.Button GodMod;
    }
}