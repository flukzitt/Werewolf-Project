﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandEnum = WerewolfClient.WerewolfCommand.CommandEnum;

namespace WerewolfClient
{
    public partial class Login : Form, View
    {
        private WerewolfController controller;
        private Form _mainForm;
        public Login(Form MainForm)
        {
            InitializeComponent();
            _mainForm = MainForm;
        } 

        public void Notify(Model m)
        {
            if (m is WerewolfModel)
            {
                WerewolfModel wm = (WerewolfModel)m;
                switch (wm.Event)
                {
                    case WerewolfModel.EventEnum.SignIn:
                        if (wm.EventPayloads["Success"] == "True")
                        {
                            _mainForm.Visible = true;
                            this.Visible = false;
							
                           // WerewolfCommand wcmd = new WerewolfCommand();
                           // wcmd.Action = CommandEnum.JoinGame;
                           // controller.ActionPerformed(wcmd);
                        }
                        else
                        {
                            MessageBox.Show("Login or password incorrect, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    case WerewolfModel.EventEnum.SignUp:
                        if (wm.EventPayloads["Done"] == "True")
                        {
                            //MessageBox.Show("Sign up successfuly, please login", "Success", MessageBoxButtons.OK, MessageBoxIcon.);
                            MessageBox.Show("Sign Up successfully, Please Login", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            MessageBox.Show("Please Try Another Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                }
            }
        }

        public void setController(Controller c)
        {
            controller = (WerewolfController)c;
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            WerewolfCommand wcmd = new WerewolfCommand();
            wcmd.Action = WerewolfCommand.CommandEnum.SignIn;
            wcmd.Payloads = new Dictionary<string, string>() { { "Login", TbLogin.Text }, { "Password", TbPassword.Text }, { "Server", TBServer.Text } };
            controller.ActionPerformed(wcmd);
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            WerewolfCommand wcmd = new WerewolfCommand();
            wcmd.Action = WerewolfCommand.CommandEnum.SignUp;
            wcmd.Payloads = new Dictionary<string, string>() { { "Login", TbLogin.Text }, { "Password", TbPassword.Text }, { "Server", TBServer.Text } };
            controller.ActionPerformed(wcmd);


        }

        private void TbPassword_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSignIn_Click(sender, e);
            }
        }

        public string GetServer()
        {
            return TBServer.Text;
        }
        
		
		private void BtnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
 

            if (CBServer.SelectedItem.ToString() == "2 Player")
            {
                TBServer.Text = "http://localhost:2343/werewolf/";
                //TBServer.Text = "http://project-ile.net:2342/werewolf/";

            }

           else if (CBServer.SelectedItem.ToString() == "4 Player")
            {
                TBServer.Text = "http://project-ile.net:2344/werewolf/";
            }

            else  if (CBServer.SelectedItem.ToString() == "16 Player")
            {
                TBServer.Text = "http://project-ile.net:23416/werewolf/";
            }
        }

		private void Login_Load(object sender, EventArgs e)
		{

		}

        private void Server_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void TBServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void TbLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
