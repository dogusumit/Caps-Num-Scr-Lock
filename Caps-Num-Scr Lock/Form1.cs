using Caps_Num_Scr_Lock.Properties;
using Microsoft.Win32;
using System;
using System.Diagnostics;
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
        private bool ilkCalisma = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                trayMenu = new ContextMenu();
                trayIcon = new NotifyIcon();
                trayMenu.MenuItems.Add("Aç", ac);
                trayMenu.MenuItems.Add("Çıkış", cikis);
                trayIcon.ContextMenu = trayMenu;
                trayIcon.Click += new EventHandler(ikonKlik);

                RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Caps - Num - Scr Lock", true);
                if (regkey != null)
                {
                    if (regkey.GetValue("caps") != null)
                        checkBox1.Checked = regkey.GetValue("caps").ToString().Equals("1") ? true : false;
                    if (regkey.GetValue("num") != null)
                        checkBox2.Checked = regkey.GetValue("num").ToString().Equals("1") ? true : false;
                    if (regkey.GetValue("scr") != null)
                        checkBox3.Checked = regkey.GetValue("scr").ToString().Equals("1") ? true : false;
                }

                checkBox4.Checked = IsStartupItem();
            }
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
            }
        }
        
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            try
            {
                if (ilkCalisma)
                {
                    string[] args = Environment.GetCommandLineArgs();
                    if (args != null)
                    {
                        foreach (string a in args)
                        {
                            if (a.Equals("-hide"))
                            {
                                Hide();
                                gizli = true;
                                ilkCalisma = false;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Registry.CurrentUser.CreateSubKey("Caps - Num - Scr Lock");
                RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Caps - Num - Scr Lock", true);
                regkey.SetValue("caps", ((CheckBox)sender).Checked ? "1" : "0");
            }
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Registry.CurrentUser.CreateSubKey("Caps - Num - Scr Lock");
                RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Caps - Num - Scr Lock", true);
                regkey.SetValue("num", ((CheckBox)sender).Checked ? "1" : "0");
            }
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Registry.CurrentUser.CreateSubKey("Caps - Num - Scr Lock");
                RegistryKey regkey = Registry.CurrentUser.OpenSubKey("Caps - Num - Scr Lock", true);
                regkey.SetValue("scr", ((CheckBox)sender).Checked ? "1" : "0");
            }
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (((CheckBox)sender).Checked)
                {
                    onBaslangic();
                }
                else
                {
                    offBaslangic();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("www.dogusumit.com");
            }
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Hide();
                gizli = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                trayIcon.Visible = false;
                trayIcon.Dispose();
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
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
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
            }
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
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
                timer1.Stop();
            }
        }

        private void ac(object sender, EventArgs e)
        {
            try
            {
                Show();
                gizli = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
            }
        }

        private void ikonKlik(object sender, EventArgs e)
        {
            try
            {
                if (gizli)
                {
                    Show();
                    gizli = false;
                }
                else
                {
                    Hide();
                    gizli = true;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
            }
        }

        private void cikis(object sender, EventArgs e)
        {
            try
            {
                trayIcon.Visible = false;
                trayIcon.Dispose();
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
            }
        }

        private void labelGuncelle()
        {
            try
            {
                label4.Text = IsKeyLocked(Keys.CapsLock) ? "AÇIK" : "KAPALI";
                label5.Text = IsKeyLocked(Keys.NumLock) ? "AÇIK" : "KAPALI";
                label6.Text = IsKeyLocked(Keys.Scroll) ? "AÇIK" : "KAPALI";
            }
            catch (Exception e)
            {
                MessageBox.Show("programda hata var :(\n" + e.Message.ToString());
            }
        }

        private void offBaslangic()
        {
            try
            {
                RegistryKey regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (IsStartupItem())
                    regkey.DeleteValue("Caps - Num - Scr Lock", false);
            }
            catch (Exception e)
            {
                MessageBox.Show("programda hata var :(\n" + e.Message.ToString());
            }
        }

        private void onBaslangic()
        {
            try
            {
                RegistryKey regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (!IsStartupItem())
                    regkey.SetValue("Caps - Num - Scr Lock", Application.ExecutablePath.ToString() + " -hide");
            }
            catch (Exception e)
            {
                MessageBox.Show("programda hata var :(\n" + e.Message.ToString());
            }
        }

        private bool IsStartupItem()
        {
            try
            {
                RegistryKey regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (regkey.GetValue("Caps - Num - Scr Lock") == null)
                    return false;
                else
                    return true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("programda hata var :(\n" + exc.Message.ToString());
                return false;
            }
        }

    }
}