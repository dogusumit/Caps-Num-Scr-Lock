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

        public Form1()
        {
            InitializeComponent();

            string[] args = Environment.GetCommandLineArgs();
            if (args[0] != null)
            {
                if (args[0].Equals("hide"))
                {
                    Hide();
                }
            }

            trayMenu = new ContextMenu();
            trayIcon = new NotifyIcon();
            trayMenu.MenuItems.Add("Aç", ac);
            trayMenu.MenuItems.Add("Çıkış", cikis);

            RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Caps - Num - Scr Lock", true);
            if (regkey != null)
            {
                checkBox1.Checked = regkey.GetValue("caps").ToString() == "1" ? true : false;
                checkBox2.Checked = regkey.GetValue("num").ToString() == "1" ? true : false;
                checkBox3.Checked = regkey.GetValue("scr").ToString() == "1" ? true : false;
            }

            checkBox4.Checked = IsStartupItem();
        }

        protected override void OnLoad(EventArgs e)
        {
            //Hide();
            ShowInTaskbar = false;
            simgeGoster();

            timer1.Start();
            base.OnLoad(e);
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
                trayIcon.ContextMenu = trayMenu;
                int sayac = 0;
                sayac += checkBox1.Checked ? 300 : 0;
                sayac += checkBox2.Checked ? 30 : 0;
                sayac += checkBox3.Checked ? 3 : 0;
                if (sayac == 333)
                {
                    trayIcon.Text = "Caps - Num - Scr Lock";
                    int kontrol = 0;
                    kontrol += IsKeyLocked(Keys.CapsLock) ? 100 : 0;
                    kontrol += IsKeyLocked(Keys.NumLock) ? 10 : 0;
                    kontrol += IsKeyLocked(Keys.Scroll) ? 1 : 0;
                    if (kontrol == 111)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (kontrol == 110)
                        trayIcon.Icon = Icon.FromHandle(Resources._110.GetHicon());
                    else if (kontrol == 101)
                        trayIcon.Icon = Icon.FromHandle(Resources._101.GetHicon());
                    else if (kontrol == 100)
                        trayIcon.Icon = Icon.FromHandle(Resources._100.GetHicon());
                    else if (kontrol == 011)
                        trayIcon.Icon = Icon.FromHandle(Resources._011.GetHicon());
                    else if (kontrol == 010)
                        trayIcon.Icon = Icon.FromHandle(Resources._010.GetHicon());
                    else if (kontrol == 001)
                        trayIcon.Icon = Icon.FromHandle(Resources._001.GetHicon());
                    else if (kontrol == 000)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else if (sayac == 330)
                {
                    trayIcon.Text = "Caps - Num Lock";
                    int kontrol = 0;
                    kontrol += IsKeyLocked(Keys.CapsLock) ? 20 : 0;
                    kontrol += IsKeyLocked(Keys.NumLock) ? 2 : 0;
                    if (kontrol == 22)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (kontrol == 20)
                        trayIcon.Icon = Icon.FromHandle(Resources._20.GetHicon());
                    else if (kontrol == 02)
                        trayIcon.Icon = Icon.FromHandle(Resources._02.GetHicon());
                    else if (kontrol == 00)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else if (sayac == 303)
                {
                    trayIcon.Text = "Caps - Scr Lock";
                    int kontrol = 0;
                    kontrol += IsKeyLocked(Keys.CapsLock) ? 20 : 0;
                    kontrol += IsKeyLocked(Keys.Scroll) ? 2 : 0;
                    if (kontrol == 22)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (kontrol == 20)
                        trayIcon.Icon = Icon.FromHandle(Resources._20.GetHicon());
                    else if (kontrol == 02)
                        trayIcon.Icon = Icon.FromHandle(Resources._02.GetHicon());
                    else if (kontrol == 00)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else if (sayac == 033)
                {
                    trayIcon.Text = "Num - Scr Lock";
                    int kontrol = 0;
                    kontrol += IsKeyLocked(Keys.NumLock) ? 20 : 0;
                    kontrol += IsKeyLocked(Keys.Scroll) ? 2 : 0;
                    if (kontrol == 22)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (kontrol == 20)
                        trayIcon.Icon = Icon.FromHandle(Resources._20.GetHicon());
                    else if (kontrol == 02)
                        trayIcon.Icon = Icon.FromHandle(Resources._02.GetHicon());
                    else if (kontrol == 00)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else if (sayac == 300)
                {
                    trayIcon.Text = "Caps Lock";
                    int kontrol = 0;
                    kontrol += IsKeyLocked(Keys.CapsLock) ? 1 : 0;
                    if (kontrol == 1)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (kontrol == 0)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else if (sayac == 030)
                {
                    trayIcon.Text = "Num Lock";
                    int kontrol = 0;
                    kontrol += IsKeyLocked(Keys.NumLock) ? 1 : 0;
                    if (kontrol == 1)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (kontrol == 0)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else if (sayac == 003)
                {
                    trayIcon.Text = "Scr Lock";
                    int kontrol = 0;
                    kontrol += IsKeyLocked(Keys.Scroll) ? 1 : 0;
                    if (kontrol == 1)
                        trayIcon.Icon = Icon.FromHandle(Resources._111.GetHicon());
                    else if (kontrol == 0)
                        trayIcon.Icon = Icon.FromHandle(Resources._000.GetHicon());
                }
                else
                {
                    trayIcon.Visible = false;
                    return;
                }
                trayIcon.Click += new System.EventHandler(ac);
                trayIcon.Visible = true;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message.ToString());
            }
        }

        private void ac(object sender, EventArgs e)
        {
            Show();
        }

        private void cikis(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            simgeGoster();
            labelGuncelle();
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
                regkey.SetValue("Caps - Num - Scr Lock", Application.ExecutablePath.ToString()+" /hide");
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
    }
}