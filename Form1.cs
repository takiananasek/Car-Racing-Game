namespace CarRacing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            restartLabel.Visible = false;
            coin1.BackColor = Color.Transparent;
            coin2.BackColor = Color.Transparent;
            coin3.BackColor = Color.Transparent;
            coin4.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            car.BackColor = Color.Transparent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(gamespeed);
            enemy(gamespeed);
            gameover();
            coins(gamespeed);
            coinscollection();
            coinLocationCheck();
        }

        Random r = new Random();
        int x;
        void enemy(int speed)
        {
            if (enemy1.Top >= 500)
            {
                x = r.Next(10,200);
                bool sameAsEnemy2 = true;
                while (sameAsEnemy2)
                {
                    x = r.Next(10, 200);
                    if ((Math.Abs(x - enemy2.Left) > 40))
                    {
                        sameAsEnemy2 = false;
                    }

                }
                enemy1.Location = new Point(x,0);      
            }
            else
            {
                enemy1.Top += speed;
            }
            if (enemy2.Top >= 500)
            {
                bool sameAsEnemy1 = true;
                while (sameAsEnemy1)
                {
                    x = r.Next(10, 200);
                    if ((Math.Abs(x - enemy1.Left) > 40))
                    {
                        sameAsEnemy1 = false;
                    }
                }  
                    enemy2.Location = new Point(x, 0);     
            }
            else
            {
                enemy2.Top += speed;
            }
            if (enemy3.Top >= 500)
            {
                x = r.Next(230, 350);   
                enemy3.Location = new Point(x, 0);
            }
            else
            {
                enemy3.Top += speed;
            }
        }

        int collectedCoins=0;
        void coinscollection()
        {
            if (car.Bounds.IntersectsWith(coin1.Bounds))
            {
                collectedCoins++;
                coin1.Visible = false;
                label2.Text = "Total coins: " + collectedCoins.ToString();
                x = r.Next(10, 200);
                coin1.Location = new Point(x, 0);
            }
            if (car.Bounds.IntersectsWith(coin2.Bounds))
            {
                collectedCoins++;
                coin2.Visible = false;
                label2.Text = "Total coins: " + collectedCoins.ToString();
                x = r.Next(10, 200);
                coin2.Location = new Point(x, 0);
            }
            if (car.Bounds.IntersectsWith(coin3.Bounds))
            {
                collectedCoins++;
                coin3.Visible = false;
                label2.Text = "Total coins: " + collectedCoins.ToString();
                x = r.Next(10, 200);
                coin3.Location = new Point(x, 0);
            }
            if (car.Bounds.IntersectsWith(coin4.Bounds))
            {
                collectedCoins++;
                coin4.Visible = false;
                label2.Text = "Total coins: " + collectedCoins.ToString();
                x = r.Next(10, 200);
                coin4.Location = new Point(x, 0);
            }
        }
        bool coinLocationOk(PictureBox coin)
        {
            if (coin.Bounds.IntersectsWith(enemy1.Bounds)) { return false; }
            if (coin.Bounds.IntersectsWith(enemy2.Bounds)) { return false; }
            if (coin.Bounds.IntersectsWith(enemy3.Bounds)) { return false; }
            return true;
        }
        void coinLocationCheck()
        {
            if (!coinLocationOk(coin1)) { coin1.Visible = false; }
            if (!coinLocationOk(coin2)) { coin2.Visible = false; }
            if (!coinLocationOk(coin3)) { coin3.Visible = false; }
            if (!coinLocationOk(coin4)) { coin4.Visible = false; }

        }
        void coins(int speed)
        {
            if (coin1.Top >= 500)
            {
                if (!coinLocationOk(coin1))
                {
                    coin1.Visible = false;
                }
                coin1.Visible = true;
                x = r.Next(10, 200);
                coin1.Location = new Point(x, 0);

            }
            else
            {
                coin1.Top += speed;
            }

            if (coin2.Top >= 500)
            {

                coin2.Visible = true;
                x = r.Next(10, 200);
                coin2.Location = new Point(x, 0);

            }
            else
            {
                coin2.Top += speed;
            }
            if (coin3.Top >= 500)
            {
                coin3.Visible = true;
                x = r.Next(10, 200);
                coin3.Location = new Point(x, 0);
            }
            else
            {
                coin3.Top += speed;
            }
            if (coin4.Top >= 500)
            {

                coin4.Visible = true;
                x = r.Next(10, 200);
                coin4.Location = new Point(x, 0);
            }
            else
            {
                coin4.Top += speed;
            }

        }

        void gameover()
        {
            if (car.Bounds.IntersectsWith(enemy1.Bounds))
            {
                timer1.Enabled = false;
                label1.Visible = true;
                restartLabel.Visible = true;
            }
            if (car.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                label1.Visible = true;
                restartLabel.Visible = true;
            }
            if (car.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                label1.Visible = true;
                restartLabel.Visible = true;
            }
            
        }
        void moveline(int speed)
        {
            if (pictureBox1.Top >= 500)
            {
                pictureBox1.Top = 0;
            }
            else{
                pictureBox1.Top += speed;
            }
            if (pictureBox2.Top >= 500)
            {
                pictureBox2.Top = 0;
            }
            else
            {
                pictureBox2.Top += speed;
            }
            if (pictureBox3.Top >= 500)
            {
                pictureBox3.Top = 0;
            }
            else
            {
                pictureBox3.Top += speed;
            }
            if (pictureBox4.Top >= 500)
            {
                pictureBox4.Top = 0;
            }
            else
            {
                pictureBox4.Top += speed;
            }

           
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        int gamespeed = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if(car.Left>0)
                car.Left -= gamespeed+12;
            }
            if (e.KeyCode == Keys.Right)
            {
                if(car.Left<380)
                car.Left += gamespeed+12;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (gamespeed < 21)
                {
                    gamespeed++;
                }
                
            }
            if (e.KeyCode == Keys.Down)
                {
                    if (gamespeed > 0)
                    {
                        gamespeed--;
                    }
                }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void enemy2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void restartLabel_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}