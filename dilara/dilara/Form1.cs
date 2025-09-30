using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace dilara
{
    public partial class Form1 : Form
    {
        int pipe_speed = 6; // Orijinal Flappy Bird'e benzer hız
        int gravity = 2; // Yerçekimi gücü
        int jump = -15; // Zıplama gücü
        int velocity = 0;
        int Score = 0;
        int gap = 150; // Borular arası boşluk artırıldı (daha oynanabilir olsun)
        Random rnd = new Random();

        List<int> previousScores = new List<int>();

        Panel startPanel;
        Panel gamePanel;
        Panel endPanel;

        Label welcomeLabel;
        Label scoresHeader;
        ListBox scoresList;
        Button startButton;

        Label endLabel;
        Button restartButton;

        // Oyun kontrolleri (tasarımcıda oluşturulduğunu varsayarak)
        // bird, pipe_down (alt boru), pipe (üst boru), ground, label (score), timer

        int initialBirdTop;
        int initialPipeDownLeft;
        int initialPipeLeft;

        bool isGameRunning = false;
        bool gameStarted = false;

        public Form1()
        {
            InitializeComponent();

            // Tam ekran ayarları
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;

            this.KeyPreview = true;

            // Dinamik konumlar
            initialBirdTop = this.ClientSize.Height / 2 - bird.Height / 2;
            bird.Top = initialBirdTop;
            bird.Left = 100;

            initialPipeDownLeft = this.ClientSize.Width + 200;
            initialPipeLeft = this.ClientSize.Width + 500; // Borular arası mesafe artırıldı

            // Paneller Dock.Fill
            startPanel = new Panel() { Dock = DockStyle.Fill, Visible = false };
            gamePanel = new Panel() { Dock = DockStyle.Fill, Visible = false };
            endPanel = new Panel() { Dock = DockStyle.Fill, Visible = false };

            this.Controls.Add(startPanel);
            this.Controls.Add(gamePanel);
            this.Controls.Add(endPanel);

            // Start panel kontrolleri
            welcomeLabel = new Label() { Text = "Hoşgeldiniz", Font = new Font("Arial", 24), AutoSize = true };
            UpdateControlPosition(welcomeLabel, 50);
            scoresHeader = new Label() { Text = "Önceki Skorlar:", Font = new Font("Arial", 16), AutoSize = true };
            UpdateControlPosition(scoresHeader, 100);
            scoresList = new ListBox() { Size = new Size(200, 100) };
            UpdateControlPosition(scoresList, 130);
            startButton = new Button() { Text = "Başla", Size = new Size(100, 50) };
            UpdateControlPosition(startButton, 250);
            startButton.Click += StartButton_Click;

            startPanel.Controls.Add(welcomeLabel);
            startPanel.Controls.Add(scoresHeader);
            startPanel.Controls.Add(scoresList);
            startPanel.Controls.Add(startButton);

            // Game panel kontrolleri
            gamePanel.Controls.Add(bird);
            gamePanel.Controls.Add(pipe_down);
            gamePanel.Controls.Add(pipe);
            gamePanel.Controls.Add(ground);
            gamePanel.Controls.Add(label);

            // Ground düzeltme: Dock.Bottom ve boyut
            ground.Dock = DockStyle.Bottom;
            ground.Height = 100; // Ground yüksekliği (tasarımcıya göre ayarla)
            ground.Width = this.ClientSize.Width;
            ground.Visible = true; // Görünür olduğundan emin ol

            // Skor label
            label.Top = 20;
            UpdateControlPosition(label, 20);

           // End panel
            endLabel = new Label() { Font = new Font("Arial", 20), AutoSize = true };
            UpdateControlPosition(endLabel, 100);
            restartButton = new Button() { Text = "Yeniden Başla", Size = new Size(150, 50) };
            UpdateControlPosition(restartButton, 200);
            restartButton.Click += RestartButton_Click;

            endPanel.Controls.Add(endLabel);
            endPanel.Controls.Add(restartButton);

            // Resize olay
            this.Resize += Form1_Resize;

            // Başlangıç ekran
            ShowStartScreen();
        }

        private void UpdateControlPosition(Control control, int top)
        {
            control.Left = (this.ClientSize.Width - control.Width) / 2;
            control.Top = top;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ground.Width = this.ClientSize.Width;

            UpdateControlPosition(welcomeLabel, 50);
            UpdateControlPosition(scoresHeader, 100);
            UpdateControlPosition(scoresList, 130);
            UpdateControlPosition(startButton, 250);

            UpdateControlPosition(endLabel, 100);
            UpdateControlPosition(restartButton, 200);

            UpdateControlPosition(label, 20);
 }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (!gameStarted) return;

            velocity += gravity;
            bird.Top += velocity;

            pipe_down.Left -= pipe_speed;
            pipe.Left -= pipe_speed;
            label.Text = "Score: " + Score;

            // Random pipe reset
            if (pipe_down.Left < -pipe_down.Width)
            {
                pipe_down.Left = this.ClientSize.Width + rnd.Next(200, 400);
               Score++;
            }

            if (pipe.Left < -pipe.Width)
            {
                pipe.Left = this.ClientSize.Width + rnd.Next(200, 400);
               Score++;
            }

            if (bird.Bounds.IntersectsWith(pipe_down.Bounds) || bird.Bounds.IntersectsWith(pipe.Bounds) || bird.Bounds.IntersectsWith(ground.Bounds) || bird.Top < -bird.Height)
            {
                endGame();
            }

            if (Score > 5)
            {
                pipe_speed = 10;
            }

            if (bird.Top < 0)
            {
                bird.Top = 0;
                velocity = 0;
            }
        }

        private void SetRandomPipeHeight(PictureBox upper, PictureBox lower)
        {
            // Random yükseklik düzeltme
            int minHeight = 50;
            int maxHeight = this.ClientSize.Height - ground.Height - gap - 150; // Daha iyi aralık için -150
            int randomUpperHeight = rnd.Next(minHeight, maxHeight);

            upper.Top = 0;
            upper.Height = randomUpperHeight;

            lower.Top = upper.Bottom + gap;
            lower.Height = this.ClientSize.Height - lower.Top - ground.Height; // Ground yüksekliğini dikkate al
        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            if (!isGameRunning) return;

            if (e.KeyCode == Keys.Space)
            {
                if (!gameStarted)
                {
                    gameStarted = true;
                }
                velocity = jump;
                e.Handled = true;
            }
        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
        }

        private void endGame()
        {
            timer.Stop();
            SaveScore(Score);
            isGameRunning = false;
            gameStarted = false;
            this.KeyDown -= gameKeyDown;
            this.KeyUp -= gameKeyUp;
            ShowEndScreen();
        }

        private void ShowStartScreen()
        {
            LoadScores();
            scoresList.Items.Clear();
            var sortedScores = previousScores.OrderByDescending(x => x).ToList();
            foreach (var s in sortedScores)
            {
                scoresList.Items.Add(s);
            }

            startPanel.Visible = true;
            gamePanel.Visible = false;
            endPanel.Visible = false;

            this.KeyDown -= gameKeyDown;
            this.KeyUp -= gameKeyUp;

            timer.Stop();
            isGameRunning = false;
            gameStarted = false;
        }

        private void ShowGameScreen()
        {
            startPanel.Visible = false;
            gamePanel.Visible = true;
            endPanel.Visible = false;

            bird.Top = initialBirdTop;
            pipe_down.Left = initialPipeDownLeft;
            pipe.Left = initialPipeLeft;
            SetRandomPipeHeight(pipe, pipe_down);
            Score = 0;
            pipe_speed = 6;
            velocity = 0;
            label.Text = "Score: 0";

            this.KeyDown += gameKeyDown;
            this.KeyUp += gameKeyUp;

            isGameRunning = true;
            gameStarted = false;
            timer.Start();
        }

        private void ShowEndScreen()
        {
            startPanel.Visible = false;
            gamePanel.Visible = false;
            endPanel.Visible = true;

            endLabel.Text = "Oyun Bitti, Skorunuz: " + Score;
            UpdateControlPosition(endLabel, 100);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ShowGameScreen();
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            ShowGameScreen();
        }

        private void LoadScores()
        {
            previousScores.Clear();
            if (File.Exists("scores.txt"))
            {
                string[] lines = File.ReadAllLines("scores.txt");
                foreach (string line in lines)
                {
                    if (int.TryParse(line, out int s))
                    {
                        previousScores.Add(s);
                    }
                }
            }
        }

        private void SaveScore(int score)
        {
            File.AppendAllText("scores.txt", score + "\n");
            previousScores.Add(score);
        }
    }
}