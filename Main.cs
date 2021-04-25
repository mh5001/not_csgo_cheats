using System;
using System.Threading;
using System.Windows.Forms;

namespace FunkyMonkey {
    public partial class Main : Form {
        private Thread mainThread;

        public Main() {
            InitializeComponent();
            MemoryReader reader = new MemoryReader();
            if (!reader.isSuccess) Application.Exit();
            else {
                printToLog("Found Counter Strike: Global Offensive");
                printToLog("Reading Config...");
                reader.Start();

                mainThread = new Thread(() => {
                    while (true) {
                        if (this.InvokeRequired) {
                            IAsyncResult result = BeginInvoke(new MethodInvoker(() => {
                                player_x.Text = reader.playerPos.x.ToString();
                                player_y.Text = reader.playerPos.y.ToString();
                                player_z.Text = reader.playerPos.z.ToString();

                                tb_aimx.Text = reader.playerAim.x.ToString();
                                tb_aimy.Text = reader.playerAim.y.ToString();

                                tb_playerName.Text = reader.nearestPlayerName;
                            }));
                        }

                        reader.Update();
                        Thread.Sleep(10);
                    }
                });
                mainThread.Start();
            }

            tb_Aimbot.Checked = Options.AIMBOT;
            tb_Radar.Checked = Options.RADAR;
            tb_Wall.Checked = Options.GLOW;
        }

        public void printToLog(string output) {
            this.tb_Log.Text += output + '\n';
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            mainThread.Abort();
        }

        private void Tb_Aimbot_Click(object sender, EventArgs e) {
            Options.AIMBOT = tb_Aimbot.Checked;
        }

        private void Tb_Wall_Click(object sender, EventArgs e) {
            Options.GLOW = tb_Wall.Checked;
        }

        private void Tb_Radar_Click(object sender, EventArgs e) {
            Options.RADAR = tb_Radar.Checked;
        }
    }
}
