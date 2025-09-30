namespace dilara
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pipe = new System.Windows.Forms.PictureBox();
            this.pipe_down = new System.Windows.Forms.PictureBox();
            this.ground = new System.Windows.Forms.PictureBox();
            this.bird = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipe_down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bird)).BeginInit();
            this.SuspendLayout();
            // 
            // pipe
            // 
            this.pipe.Image = ((System.Drawing.Image)(resources.GetObject("pipe.Image")));
            this.pipe.Location = new System.Drawing.Point(1405, 562);
            this.pipe.Name = "pipe";
            this.pipe.Size = new System.Drawing.Size(190, 556);
            this.pipe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pipe.TabIndex = 2;
            this.pipe.TabStop = false;
            // 
            // pipe_down
            // 
            this.pipe_down.Image = ((System.Drawing.Image)(resources.GetObject("pipe_down.Image")));
            this.pipe_down.Location = new System.Drawing.Point(651, -225);
            this.pipe_down.Name = "pipe_down";
            this.pipe_down.Size = new System.Drawing.Size(190, 556);
            this.pipe_down.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pipe_down.TabIndex = 3;
            this.pipe_down.TabStop = false;
            // 
            // ground
            // 
            this.ground.Image = ((System.Drawing.Image)(resources.GetObject("ground.Image")));
            this.ground.Location = new System.Drawing.Point(-41, 871);
            this.ground.Name = "ground";
            this.ground.Size = new System.Drawing.Size(2251, 199);
            this.ground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ground.TabIndex = 7;
            this.ground.TabStop = false;
            // 
            // bird
            // 
            this.bird.Image = ((System.Drawing.Image)(resources.GetObject("bird.Image")));
            this.bird.Location = new System.Drawing.Point(23, 384);
            this.bird.Name = "bird";
            this.bird.Size = new System.Drawing.Size(80, 60);
            this.bird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bird.TabIndex = 8;
            this.bird.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.gameTimerEvent);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label.Location = new System.Drawing.Point(1521, 129);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(236, 54);
            this.label.TabIndex = 9;
            this.label.Text = "SCORE:0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.ground);
            this.Controls.Add(this.pipe);
            this.Controls.Add(this.label);
            this.Controls.Add(this.bird);
            this.Controls.Add(this.pipe_down);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gameKeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipe_down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bird)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pipe;
        private System.Windows.Forms.PictureBox pipe_down;
        private System.Windows.Forms.PictureBox ground;
        private System.Windows.Forms.PictureBox bird;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label;
    }
}

