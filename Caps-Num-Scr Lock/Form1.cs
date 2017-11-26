using Caps_Num_Scr_Lock.Properties;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Caps_Num_Scr_Lock
{
    public partial class Form1 : Form
    {

        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private int gosterKontrol = -1;
        private int lockKontrol = -1;
        private bool gizli = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey("Caps - Num - Scr Lock");
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Caps - Num - Scr Lock", true);
            regkey.SetValue("caps", ((CheckBox)sender).Checked ? "1" : "0");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey("Caps - Num - Scr Lock");
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Caps - Num - Scr Lock", true);
            regkey.SetValue("num", ((CheckBox)sender).Checked ? "1" : "0");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey("Caps - Num - Scr Lock");
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Caps - Num - Scr Lock", true);
            regkey.SetValue("scr", ((CheckBox)sender).Checked ? "1" : "0");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.dogusumit.com");
        }

        private void simgeGoster()
        {
            try
            {
                trayIcon.Visible = false;

                if (gosterKontrol == 111)
                {
                    trayIcon.Text = "Caps - Num - Scr Lock";
                    if (lockKontrol == 111)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (lockKontrol == 110)
                        trayIcon.Icon = Icon.FromHandle(Resources._110.GetHicon());
                    else if (lockKontrol == 101)
                        trayIcon.Icon = Icon.FromHandle(Resources._101.GetHicon());
                    else if (lockKontrol == 100)
                        trayIcon.Icon = Icon.FromHandle(Resources._100.GetHicon());
                    else if (lockKontrol == 011)
                        trayIcon.Icon = Icon.FromHandle(Resources._011.GetHicon());
                    else if (lockKontrol == 010)
                        trayIcon.Icon = Icon.FromHandle(Resources._010.GetHicon());
                    else if (lockKontrol == 001)
                        trayIcon.Icon = Icon.FromHandle(Resources._001.GetHicon());
                    else if (lockKontrol == 000)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else if (gosterKontrol == 110)
                {
                    trayIcon.Text = "Caps - Num Lock";
                    if (lockKontrol == 110)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (lockKontrol == 100)
                        trayIcon.Icon = Icon.FromHandle(Resources._20.GetHicon());
                    else if (lockKontrol == 010)
                        trayIcon.Icon = Icon.FromHandle(Resources._02.GetHicon());
                    else if (lockKontrol == 000)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else if (gosterKontrol == 101)
                {
                    trayIcon.Text = "Caps - Scr Lock";
                    if (lockKontrol == 101)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (lockKontrol == 100)
                        trayIcon.Icon = Icon.FromHandle(Resources._20.GetHicon());
                    else if (lockKontrol == 001)
                        trayIcon.Icon = Icon.FromHandle(Resources._02.GetHicon());
                    else if (lockKontrol == 000)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else if (gosterKontrol == 011)
                {
                    trayIcon.Text = "Num - Scr Lock";
                    if (lockKontrol == 011)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (lockKontrol == 010)
                        trayIcon.Icon = Icon.FromHandle(Resources._20.GetHicon());
                    else if (lockKontrol == 001)
                        trayIcon.Icon = Icon.FromHandle(Resources._02.GetHicon());
                    else if (lockKontrol == 000)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else if (gosterKontrol == 100)
                {
                    trayIcon.Text = "Caps Lock";
                    if (lockKontrol == 100)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (lockKontrol == 000)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else if (gosterKontrol == 010)
                {
                    trayIcon.Text = "Num Lock";
                    if (lockKontrol == 010)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (lockKontrol == 000)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else if (gosterKontrol == 001)
                {
                    trayIcon.Text = "Scr Lock";
                    if (lockKontrol == 001)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (lockKontrol == 000)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else
                {
                    trayIcon.Visible = false;
                    return;
                }
                trayIcon.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("programda hata var :(\n"+e.Message.ToString());
                timer1.Stop();
            }
        }

        private void ac(object sender, EventArgs e)
        {
                Show();
                gizli = false;
        }

        private void ikonKlik(object sender, EventArgs e)
        {
            if (gizli)
            {
                Show();
                gizli = false;
            } else
            {
                Hide();
                gizli = true;
            }
        }

        private void cikis(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            trayIcon.Dispose();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            gizli = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            trayIcon.Dispose();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int tmp1 = 0;
            tmp1 += checkBox1.Checked ? 100 : 0;
            tmp1 += checkBox2.Checked ? 010 : 0;
            tmp1 += checkBox3.Checked ? 001 : 0;
            int tmp2 = 0;
            tmp2 += IsKeyLocked(Keys.CapsLock) ? 100 : 0;
            tmp2 += IsKeyLocked(Keys.NumLock) ? 010 : 0;
            tmp2 += IsKeyLocked(Keys.Scroll) ? 001 : 0;

            if (tmp1 != gosterKontrol || tmp2 != lockKontrol)
            {
                gosterKontrol = tmp1;
                lockKontrol = tmp2;
                simgeGoster();
                labelGuncelle();
            }
        }

        private void labelGuncelle()
        {
            label4.Text = IsKeyLocked(Keys.CapsLock) ? "AÇIK" : "KAPALI";
            label5.Text = IsKeyLocked(Keys.NumLock) ? "AÇIK" : "KAPALI";
            label6.Text = IsKeyLocked(Keys.Scroll) ? "AÇIK" : "KAPALI";
        }

        private void offBaslangic()
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (IsStartupItem())
                regkey.DeleteValue("Caps - Num - Scr Lock", false);
        }
        private void onBaslangic()
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (!IsStartupItem())
                regkey.SetValue("Caps - Num - Scr Lock", Application.ExecutablePath.ToString()+" -hide");
        }
        private bool IsStartupItem()
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (regkey.GetValue("Caps - Num - Scr Lock") == null)
                return false;
            else
                return true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if ( ((CheckBox)sender).Checked) {
                onBaslangic();
            } else
            {
                offBaslangic();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string[] args = Environment.GetCommandLineArgs();
            if (args[0] != null)
            {
                foreach ( string a in args)
                {
                    if (a.Equals("-hide"))
                    {
                        Hide();
                        gizli = true;
                    }
                }
            }
            
            trayMenu = new ContextMenu();
            trayIcon = new NotifyIcon();
            trayMenu.MenuItems.Add("Aç", ac);
            trayMenu.MenuItems.Add("Çıkış", cikis);
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Click += new System.EventHandler(ikonKlik);

            RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Caps - Num - Scr Lock", true);
            if (regkey != null)
            {
                checkBox1.Checked = regkey.GetValue("caps").ToString().Equals("1") ? true : false;
                checkBox2.Checked = regkey.GetValue("num").ToString().Equals("1") ? true : false;
                checkBox3.Checked = regkey.GetValue("scr").ToString().Equals("1") ? true : false;
            }

            checkBox4.Checked = IsStartupItem();
            simgeGoster();
            timer1.Start();
        }
    }
}