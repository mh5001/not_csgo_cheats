namespace FunkyMonkey {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tb_Log = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.player_x = new System.Windows.Forms.TextBox();
            this.player_y = new System.Windows.Forms.TextBox();
            this.player_z = new System.Windows.Forms.TextBox();
            this.tb_Aimbot = new System.Windows.Forms.CheckBox();
            this.tb_Wall = new System.Windows.Forms.CheckBox();
            this.tb_Radar = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_aimy = new System.Windows.Forms.TextBox();
            this.tb_aimx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_playerName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_Log
            // 
            this.tb_Log.Location = new System.Drawing.Point(12, 37);
            this.tb_Log.Name = "tb_Log";
            this.tb_Log.ReadOnly = true;
            this.tb_Log.Size = new System.Drawing.Size(320, 252);
            this.tb_Log.TabIndex = 0;
            this.tb_Log.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Not CSGO Hack V1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(606, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Michael";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Player Position:";
            // 
            // player_x
            // 
            this.player_x.Location = new System.Drawing.Point(434, 34);
            this.player_x.Name = "player_x";
            this.player_x.ReadOnly = true;
            this.player_x.Size = new System.Drawing.Size(57, 20);
            this.player_x.TabIndex = 4;
            // 
            // player_y
            // 
            this.player_y.Location = new System.Drawing.Point(497, 34);
            this.player_y.Name = "player_y";
            this.player_y.ReadOnly = true;
            this.player_y.Size = new System.Drawing.Size(57, 20);
            this.player_y.TabIndex = 5;
            // 
            // player_z
            // 
            this.player_z.Location = new System.Drawing.Point(560, 34);
            this.player_z.Name = "player_z";
            this.player_z.ReadOnly = true;
            this.player_z.Size = new System.Drawing.Size(57, 20);
            this.player_z.TabIndex = 6;
            // 
            // tb_Aimbot
            // 
            this.tb_Aimbot.AutoSize = true;
            this.tb_Aimbot.Checked = true;
            this.tb_Aimbot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tb_Aimbot.Location = new System.Drawing.Point(341, 163);
            this.tb_Aimbot.Name = "tb_Aimbot";
            this.tb_Aimbot.Size = new System.Drawing.Size(58, 17);
            this.tb_Aimbot.TabIndex = 7;
            this.tb_Aimbot.Text = "Aimbot";
            this.tb_Aimbot.UseVisualStyleBackColor = true;
            this.tb_Aimbot.Click += new System.EventHandler(this.Tb_Aimbot_Click);
            // 
            // tb_Wall
            // 
            this.tb_Wall.AutoSize = true;
            this.tb_Wall.Checked = true;
            this.tb_Wall.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tb_Wall.Location = new System.Drawing.Point(341, 186);
            this.tb_Wall.Name = "tb_Wall";
            this.tb_Wall.Size = new System.Drawing.Size(76, 17);
            this.tb_Wall.TabIndex = 8;
            this.tb_Wall.Text = "Wall Hack";
            this.tb_Wall.UseVisualStyleBackColor = true;
            this.tb_Wall.Click += new System.EventHandler(this.Tb_Wall_Click);
            // 
            // tb_Radar
            // 
            this.tb_Radar.AutoSize = true;
            this.tb_Radar.Checked = true;
            this.tb_Radar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tb_Radar.Location = new System.Drawing.Point(341, 209);
            this.tb_Radar.Name = "tb_Radar";
            this.tb_Radar.Size = new System.Drawing.Size(84, 17);
            this.tb_Radar.TabIndex = 9;
            this.tb_Radar.Text = "Radar Hack";
            this.tb_Radar.UseVisualStyleBackColor = true;
            this.tb_Radar.Click += new System.EventHandler(this.Tb_Radar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Player Aim:";
            // 
            // tb_aimy
            // 
            this.tb_aimy.Location = new System.Drawing.Point(497, 63);
            this.tb_aimy.Name = "tb_aimy";
            this.tb_aimy.ReadOnly = true;
            this.tb_aimy.Size = new System.Drawing.Size(57, 20);
            this.tb_aimy.TabIndex = 12;
            // 
            // tb_aimx
            // 
            this.tb_aimx.Location = new System.Drawing.Point(434, 63);
            this.tb_aimx.Name = "tb_aimx";
            this.tb_aimx.ReadOnly = true;
            this.tb_aimx.Size = new System.Drawing.Size(57, 20);
            this.tb_aimx.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nearest Player:";
            // 
            // tb_playerName
            // 
            this.tb_playerName.Location = new System.Drawing.Point(434, 98);
            this.tb_playerName.Name = "tb_playerName";
            this.tb_playerName.ReadOnly = true;
            this.tb_playerName.Size = new System.Drawing.Size(183, 20);
            this.tb_playerName.TabIndex = 14;
            this.tb_playerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 301);
            this.Controls.Add(this.tb_playerName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_aimy);
            this.Controls.Add(this.tb_aimx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_Radar);
            this.Controls.Add(this.tb_Wall);
            this.Controls.Add(this.tb_Aimbot);
            this.Controls.Add(this.player_z);
            this.Controls.Add(this.player_y);
            this.Controls.Add(this.player_x);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Log);
            this.Name = "Main";
            this.Text = "Notepad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tb_Log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox player_x;
        private System.Windows.Forms.TextBox player_y;
        private System.Windows.Forms.TextBox player_z;
        private System.Windows.Forms.CheckBox tb_Aimbot;
        private System.Windows.Forms.CheckBox tb_Wall;
        private System.Windows.Forms.CheckBox tb_Radar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_aimy;
        private System.Windows.Forms.TextBox tb_aimx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_playerName;
    }
}

