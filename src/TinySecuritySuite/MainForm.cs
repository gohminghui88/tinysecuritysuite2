/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 19/05/2019
 * Time: 2:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TinySecuritySuite
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		string curPAsswords;
		//Login
		void MainFormLoad(object sender, EventArgs e)
		{
			try {
			button1.Enabled = false;
			button2.Enabled = false;
			button3.Enabled = false;
			button4.Enabled = false;
			button5.Enabled = false;
			button6.Enabled = false;
			button21.Enabled = false;
			
			button7.Enabled = false;
			button8.Enabled = false;
			button10.Enabled = false;
			
			button22.Enabled = false;
			button23.Enabled = false;
			button24.Enabled = false;
			button25.Enabled = false;
			
			button9.Enabled = false;
			button20.Enabled = false;
			
			
			tabControl2.Enabled = false;
			tabControl3.Enabled = false;
			
			encryptionToolStripMenuItem.Enabled = false;
			shredderToolStripMenuItem.Enabled = false;
			secureFolderToolStripMenuItem.Enabled = false;
			vPNToolStripMenuItem.Enabled = false;
			torBrowserToolStripMenuItem.Enabled = false;
			firewallToolStripMenuItem.Enabled = false;
			loginPasswordsToolStripMenuItem.Enabled = false;
			
			if(File.Exists(Directory.GetCurrentDirectory() + "\\parameters.ini")) {
				tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabPage9);
			}
			else {
				
				LoginPasswordsForm lpFo = new LoginPasswordsForm();
				lpFo.Show();
				
				MessageBox.Show("This is your first time using this software. You need to create a passwords. ");
				
				tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(tabPage9);
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
			
		}	
		void Button21Click(object sender, EventArgs e)
		{
			try {
			LoginPasswordsForm lpFo = new LoginPasswordsForm();
			lpFo.Show();
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button26Click(object sender, EventArgs e)
		{
			try {
			List<string> res = new List<string>();
			StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\parameters.ini");
			string line = "";
			while((line = sr.ReadLine()) != null) {
				res.Add(line);
			}
			sr.Close();
			
			string tmp = textBox11.Text;
			string p = decryptStringAES(res[0], tmp);
			
			if(p == textBox11.Text) {
				MessageBox.Show("Login Progress Completed. ");
				
				button1.Enabled = true;
				button2.Enabled = true;
				button3.Enabled = true;
				button4.Enabled = true;
				button5.Enabled = true;
				button6.Enabled = true;
				button21.Enabled = true;
			
				button7.Enabled = true;
				button8.Enabled = true;
				button10.Enabled = true;
			
				button22.Enabled = true;
				button23.Enabled = true;
				button24.Enabled = true;
				button25.Enabled = true;
			
				button9.Enabled = true;
				button20.Enabled = true;
			
			
				tabControl2.Enabled = true;
				tabControl3.Enabled = true;
				
				encryptionToolStripMenuItem.Enabled = true;
				shredderToolStripMenuItem.Enabled = true;
				secureFolderToolStripMenuItem.Enabled = true;
				vPNToolStripMenuItem.Enabled = true;
				torBrowserToolStripMenuItem.Enabled = true;
				firewallToolStripMenuItem.Enabled = true;
				loginPasswordsToolStripMenuItem.Enabled = true;
				
				curPAsswords = textBox11.Text;
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show("Passwords wrong. ");
			}
		}
		
		
		
		//Menu Buttons
		void Button1Click(object sender, EventArgs e)
		{
			try {
			tabControl1.SelectedIndex = 0;
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button2Click(object sender, EventArgs e)
		{
			
			try {
			tabControl1.SelectedIndex = 1;
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button3Click(object sender, EventArgs e)
		{
			try {
			tabControl1.SelectedIndex = 2;
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button4Click(object sender, EventArgs e)
		{
			try {
			tabControl1.SelectedIndex = 3;
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button6Click(object sender, EventArgs e)
		{
			try {
			System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "/PapiFirewall/FirewallPApi.exe");
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}	
		void Button5Click(object sender, EventArgs e)
		{
			try {
			System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "/TorBrowser/TorBrowserPortable.exe");
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		
		
		//VPN
		void Button17Click(object sender, EventArgs e)
		{
			try {
			System.Diagnostics.Process.Start("C:/Program Files/OpenVPN/bin/openvpn.exe", "--config \"" + textBox10.Text + "\"");
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button19Click(object sender, EventArgs e)
		{
			try {
			System.Diagnostics.Process.Start("C:/Windows/System32/rasdial.exe", textBox7.Text + " " + textBox8.Text + " " + textBox9.Text);
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button18Click(object sender, EventArgs e)
		{
			try {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Open VPN file (*.ovpn)|*.ovpn";
			
			string res;
			if(ofd.ShowDialog() == DialogResult.OK) {
				textBox10.Text = ofd.FileName;
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		
		
		//Shredder
		void Button7Click(object sender, EventArgs e)
		{
			try {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "All | *.*";
			
			if(ofd.ShowDialog() == DialogResult.OK) {
				richTextBox1.Text += "\n" + ofd.FileName;
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button8Click(object sender, EventArgs e)
		{
			try {
			richTextBox1.Text = "";
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button10Click(object sender, EventArgs e)
		{
			try {
			string[] files = richTextBox1.Text.Split('\n');
			
			foreach(string s in files) {
				Random random = new Random();
				if(s != "") {
					if(radioButton1.Checked) shred7pass(s, random);
					else if(radioButton2.Checked) shred35pass(s, random);
				}
			}
			
			MessageBox.Show("Shred completed. ");
			richTextBox1.Text = "";
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
			
		}
		void shred7pass(string path, Random random) {
			
			try {
			for(int i = 0; i < 7; i++) {
				shred(path, random);
			}
			File.Delete(path);
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
			
		}
		void shred35pass(string path, Random random) {
			
			try {
			for(int i = 0; i < 35; i++)
			{
				shred(path, random);
			}
			File.Delete(path);
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
			
		}
		void shred1pass(string path, Random random) {
			
			try {
			shred(path, random);
			File.Delete(path);
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
			
		}
		//Reference: http://forums.devshed.com/net-development-87/secure-file-deleting-shredding-459483.html
		void shred(string path, Random random) {
			
			try {
			using(FileStream stream = File.Open(path, FileMode.Open, FileAccess.Write)) {
				Byte[] buffer = new byte[8];
				long length = stream.Length;
				for(long index = 0; index < length; index += buffer.Length) {
					random.NextBytes(buffer);
					stream.Write(buffer, 0, buffer.Length);
				}
				stream.Flush();
				
				stream.Seek(0, SeekOrigin.Begin);
				Array.Clear(buffer, 0, buffer.Length);
				for(long index = 0; index < length; index += buffer.Length) {
					stream.Write(buffer, 0, buffer.Length);
				}
				stream.Flush();
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
			
		}
		
		
		
		//Encryption
		
		void Button11Click(object sender, EventArgs e)
		{
			try {
			string res;
			if(textBox1.Text == textBox2.Text) {
				switch(comboBox1.Text) {
						case "AES": richTextBox3.Text = encryptStringAES(richTextBox2.Text, textBox1.Text);
									break;
						
						case "Triple DES": richTextBox3.Text = encryptStringTripleDES(richTextBox2.Text, textBox1.Text);
										   break;
						
						case "DES": richTextBox3.Text = encryptStringDES(richTextBox2.Text, textBox1.Text);
						            break;
						
						
						default: richTextBox3.Text = encryptStringAES(richTextBox2.Text, textBox1.Text);
								break;
				}
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}	
		void Button12Click(object sender, EventArgs e)
		{
			try {
			if(textBox1.Text == textBox2.Text) {
				switch(comboBox1.Text) {
						case "AES": richTextBox2.Text = decryptStringAES(richTextBox3.Text, textBox1.Text);
						            break;
						
						case "Triple DES": richTextBox2.Text = decryptTripleDES(richTextBox3.Text, textBox1.Text);
						                   break;
						
						case "DES": richTextBox2.Text = decryptStringDES(richTextBox3.Text, textBox1.Text);
						            break;
						
						
						default: richTextBox2.Text = decryptStringAES(richTextBox3.Text, textBox1.Text);
						         break;
				}
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		//Reference: https://tekeye.uk/visual_studio/encrypt-decrypt-c-sharp-string
		public string encryptStringAES(string plainText, string passPhrase) {
			
			try {
			int keysize = 256;
			string initVector = "qwertyuiopasdfgh";
			
			byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			
			PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
			byte[] keyBytes = password.GetBytes(keysize / 8);
			
			RijndaelManaged symmetricKey = new RijndaelManaged();
			symmetricKey.Mode = CipherMode.CBC;
			ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
			
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptostream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
			cryptostream.Write(plainTextBytes, 0, plainTextBytes.Length);
			cryptostream.FlushFinalBlock();
			byte[] cipherTextBytes = memoryStream.ToArray();
			memoryStream.Close();
			cryptostream.Close();
			
			string result = Convert.ToBase64String(cipherTextBytes);
			
			return result;
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
				return "";
			}
		}
		public string decryptStringAES(string encryptedText, string passPhrase) {
			
			try {
				
				if(encryptedText != "") {
			int keysize = 256;
			string initVector = "qwertyuiopasdfgh";
			
			byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
			byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
			
			PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
			byte[] keyBytes = password.GetBytes(keysize / 8);
			
			RijndaelManaged symmetricKey = new RijndaelManaged();
			symmetricKey.Mode = CipherMode.CBC;
			ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
			
			MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
			CryptoStream cryptostream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
			
			byte[] plainTextBytes = new byte[cipherTextBytes.Length];
			int decryptedByteCount = cryptostream.Read(plainTextBytes, 0, plainTextBytes.Length);
			
			memoryStream.Close();
			cryptostream.Close();
			
			return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
			
				}
				
				return "";
			}
			
			catch(Exception ex) {
				MessageBox.Show("Passwords wrong. ");
				return "";
			}
		}
		//Reference: https://www.codeguru.com/csharp/csharp/cs_misc/security/triple-des-encryption-and-decryption-in-c.html
		public string encryptStringTripleDES(string plainText, string passPhrase) {
			
			try {
			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			
			MD5CryptoServiceProvider md5Crypto = new MD5CryptoServiceProvider();
			byte[] key = md5Crypto.ComputeHash(UTF8Encoding.UTF8.GetBytes(passPhrase));
			md5Crypto.Clear();
			

			TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
			tripleDES.Key = key;
			tripleDES.Mode = CipherMode.ECB;
			tripleDES.Padding = PaddingMode.PKCS7;
			
			ICryptoTransform encryptor = tripleDES.CreateEncryptor();
			
			byte[] resultByte = encryptor.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
			tripleDES.Clear();
			
			return Convert.ToBase64String(resultByte, 0, resultByte.Length);
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
				return "";
			}
			                                   
		}
		public string decryptTripleDES(string encryptedText, string passPhrase) {
			
			try {
			byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);
			
			MD5CryptoServiceProvider md5Crypto = new MD5CryptoServiceProvider();
			byte[] key = md5Crypto.ComputeHash(UTF8Encoding.UTF8.GetBytes(passPhrase));
			md5Crypto.Clear();
			

			TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
			tripleDES.Key = key;
			tripleDES.Mode = CipherMode.ECB;
			tripleDES.Padding = PaddingMode.PKCS7;
			
			ICryptoTransform decryptor = tripleDES.CreateDecryptor();
			
			byte[] resultByte = decryptor.TransformFinalBlock(encryptedTextBytes, 0, encryptedTextBytes.Length);
			tripleDES.Clear();
			
			return UTF8Encoding.UTF8.GetString(resultByte);
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
				return "";
			}
		}
		public string encryptStringDES(string plainText, string passPhrase) {
			
			try {
			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			
			MD5CryptoServiceProvider md5Crypto = new MD5CryptoServiceProvider();
			byte[] key = md5Crypto.ComputeHash(UTF8Encoding.UTF8.GetBytes(passPhrase));
			md5Crypto.Clear();
			
			DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
			DES.Key = key;
			
			ICryptoTransform encryptor = DES.CreateEncryptor();
			
			byte[] resultByte = encryptor.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
			DES.Clear();
			
			return Convert.ToBase64String(resultByte, 0, resultByte.Length);
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
				return "";
			}
		}
		public string decryptStringDES(string encryptedText, string passPhrase) {
			
			try {
			byte[] encryptedTextBytes = Encoding.UTF8.GetBytes(encryptedText);
			
			MD5CryptoServiceProvider md5Crypto = new MD5CryptoServiceProvider();
			byte[] key = md5Crypto.ComputeHash(UTF8Encoding.UTF8.GetBytes(passPhrase));
			md5Crypto.Clear();
			
			DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
			DES.Key = key;
			
			ICryptoTransform decryptor = DES.CreateDecryptor();
			
			byte[] resultByte = decryptor.TransformFinalBlock(encryptedTextBytes, 0, encryptedTextBytes.Length);
			DES.Clear();
			
			return UTF8Encoding.UTF8.GetString(resultByte);
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
				return "";
			}
		}
		
		void Button15Click(object sender, EventArgs e)
		{
			try {
			if(textBox3.Text == textBox4.Text) {
				if(comboBox2.Text == "AES") {
					encryptAESFile(textBox5.Text, textBox6.Text, textBox3.Text);
					
					MessageBox.Show("Encryption Completed. ");
				}
				
				if(comboBox2.Text == "Triple DES") {
					encryptTDESFile(textBox5.Text, textBox6.Text, textBox3.Text);
					
					MessageBox.Show("Encryption Completed. ");
				}
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button16Click(object sender, EventArgs e)
		{
			try {
			if(textBox3.Text == textBox4.Text) {
				if(comboBox2.Text == "AES") {
					decryptAESFile(textBox5.Text, textBox6.Text, textBox3.Text);
					
					MessageBox.Show("Decryption Completed. ");
				}
				
				if(comboBox2.Text == "Triple DES") {
					decryptTDESFile(textBox5.Text, textBox6.Text, textBox3.Text);
					
					MessageBox.Show("Decryption Completed. ");
				}
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
	
		}
		void Button13Click(object sender, EventArgs e)
		{
			try {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "All | *.*";
			
			if(ofd.ShowDialog() == DialogResult.OK) {
				textBox5.Text = ofd.FileName;
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button14Click(object sender, EventArgs e)
		{
			try {
			SaveFileDialog ofd = new SaveFileDialog();
			ofd.Filter = "All | *.*";
			
			if(ofd.ShowDialog() == DialogResult.OK) {
				textBox6.Text = ofd.FileName;
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
	
		}
		//Reference: https://www.fluxbytes.com/csharp/encrypt-and-decrypt-files-in-c/
		void encryptTDESFile(string inputFile, string outputFile, string skey) {
			
			try {
			using(TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider()) {
				
				byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
				byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);
				
				tripleDES.Key = key;
				tripleDES.Mode = CipherMode.ECB;
				tripleDES.Padding = PaddingMode.PKCS7;
				
				using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create)) {
					
					using(ICryptoTransform encryptor = tripleDES.CreateEncryptor()) {
						
						using(CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write)) {
							
							using (FileStream fsIn = new FileStream(inputFile, FileMode.Open)) {
								int data;
								while((data = fsIn.ReadByte()) != -1) {
									cs.WriteByte((byte) data);
								}
							}
						}
					}
				}
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void decryptTDESFile(string inputFile, string outputFile, string skey) {
			
			try {
			using(TripleDESCryptoServiceProvider  tripleDES = new TripleDESCryptoServiceProvider()) {
				
				byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
				byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);
				
				tripleDES.Key = key;
				tripleDES.Mode = CipherMode.ECB;
				tripleDES.Padding = PaddingMode.PKCS7;
				
				using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open)) {
					using(FileStream fsOut = new FileStream(outputFile, FileMode.Create)) {
						using (ICryptoTransform decryptor = tripleDES.CreateDecryptor(key, IV)) {
							using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read)) {
								int data;
								while((data = cs.ReadByte()) != -1) {
									fsOut.WriteByte((byte) data);
								}
							}
						}
					}
				}
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void encryptAESFile(string inputFile, string outputFile, string skey) {
			
			try {
			using(RijndaelManaged aes = new RijndaelManaged()) {
				
				string initVector = "HR$2pIjHR$2pIj12";
				byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
				byte[] IV = ASCIIEncoding.UTF8.GetBytes(initVector);
				
				
				using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create)) {
					
					using(ICryptoTransform encryptor = aes.CreateEncryptor(key, IV)) {
						
						using(CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write)) {
							
							using (FileStream fsIn = new FileStream(inputFile, FileMode.Open)) {
								int data;
								while((data = fsIn.ReadByte()) != -1) {
									cs.WriteByte((byte) data);
								}
							}
						}
					}
				}
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void decryptAESFile(string inputFile, string outputFile, string skey) {
			
			try {
			using(RijndaelManaged aes = new RijndaelManaged()) {
				
				string initVector = "HR$2pIjHR$2pIj12";
				byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
				byte[] IV = ASCIIEncoding.UTF8.GetBytes(initVector);
				
				using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open)) {
					using(FileStream fsOut = new FileStream(outputFile, FileMode.Create)) {
						using (ICryptoTransform decryptor = aes.CreateDecryptor(key, IV)) {
							using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read)) {
								int data;
								while((data = cs.ReadByte()) != -1) {
									fsOut.WriteByte((byte) data);
								}
							}
						}
					}
				}
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		
		
		
		//Folder File Hide
		void Button22Click(object sender, EventArgs e)
		{
			try {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "All | *.*";
			
			if(ofd.ShowDialog() == DialogResult.OK) {
				if(!listBox1.Items.Contains(ofd.FileName + "|" + "Unhidden")) listBox1.Items.Add(ofd.FileName + "|" + "Unhidden");
				exportLIstBoxItems();
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button24Click(object sender, EventArgs e)
		{
			try {
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			DialogResult res = fbd.ShowDialog();
			
			if(res == DialogResult.OK) {
				if(!listBox1.Items.Contains(fbd.SelectedPath + "|" + "Unhidden")) listBox1.Items.Add(fbd.SelectedPath + "|" + "Unhidden");
				exportLIstBoxItems();
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button9Click(object sender, EventArgs e)
		{
			try {
			string path = listBox1.GetItemText(listBox1.SelectedItem);
			FileAttributes attr = File.GetAttributes(path.Split('|')[0]);
			
			if((attr & FileAttributes.Directory) == FileAttributes.Directory) {
				DirectoryInfo ch = new DirectoryInfo(path.Split('|')[0]);
				ch.Attributes = FileAttributes.Hidden;
				
				int pos = listBox1.Items.IndexOf(listBox1.GetItemText(listBox1.SelectedItem));
 				if(pos != -1) listBox1.Items[pos] = path.Split('|')[0] + "|Hidden";
 				
 				MessageBox.Show("Hidden Directory and Folder");
			}
			
			else {
				File.SetAttributes(path.Split('|')[0], FileAttributes.Hidden);
				
				int pos = listBox1.Items.IndexOf(listBox1.GetItemText(listBox1.SelectedItem));
 				if(pos != -1) listBox1.Items[pos] = path.Split('|')[0] + "|Hidden";
 				
				MessageBox.Show("Hidden File");
			}
			
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button20Click(object sender, EventArgs e)
		{
			
			try {
			string path = listBox1.GetItemText(listBox1.SelectedItem);
			FileAttributes attr = File.GetAttributes(path.Split('|')[0]);
			
			if((attr & FileAttributes.Directory) == FileAttributes.Directory) {
				DirectoryInfo ch = new DirectoryInfo(path.Split('|')[0]);
				ch.Attributes = FileAttributes.Normal;
				
				MessageBox.Show("UnHidden Directory and Folder");
				
				int pos = listBox1.Items.IndexOf(listBox1.GetItemText(listBox1.SelectedItem));
 				if(pos != -1) listBox1.Items[pos] = path.Split('|')[0] + "|UnHidden";
			}
			
			else {
				File.SetAttributes(path.Split('|')[0], FileAttributes.Normal);
				MessageBox.Show("UnHidden File");
				
				int pos = listBox1.Items.IndexOf(listBox1.GetItemText(listBox1.SelectedItem));
 				if(pos != -1) listBox1.Items[pos] = path.Split('|')[0] + "|UnHidden";
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button25Click(object sender, EventArgs e)
		{
			try {
			listBox1.Items.Clear();
			exportLIstBoxItems();
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button23Click(object sender, EventArgs e)
		{
			try {
			listBox1.Items.Remove(listBox1.SelectedItems[0]);
			exportLIstBoxItems();
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		public void exportLIstBoxItems() {
			StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\foldersfiles.ini");
			foreach(var item in listBox1.Items) {
				sw.WriteLine(encryptStringAES(item.ToString(), "12367889123123"));
			}
			sw.Close();
		}
		public void loadLIstBoxItems() {
			
			if(!File.Exists(Directory.GetCurrentDirectory() + "\\foldersfiles.ini"))
				File.Create(Directory.GetCurrentDirectory() + "\\foldersfiles.ini");
				
			List<String> res = new List<string>();
			
			StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\foldersfiles.ini");
			string line = "";
			
			while((line = sr.ReadLine()) != null) {
				
				res.Add(decryptStringAES(line, "12367889123123"));
			}
			sr.Close();
			
			foreach(string s in res) {
				
				if(s != "") {
				string path = s;
				FileAttributes attr = File.GetAttributes(path.Split('|')[0]);
				
				string isHi = "";
			
				if((attr & FileAttributes.Directory) == FileAttributes.Directory) {
					
					isHi = "Unhidden";
					
					DirectoryInfo FolderInfo = new DirectoryInfo(path.Split('|')[0]);
                	if ((FolderInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                	{
                		isHi = "Hidden";
                	}
				}
			
				else {
					
					isHi = "Unhidden";
					
					FileInfo f = new FileInfo(path.Split('|')[0]);
					if(f.Attributes.HasFlag(FileAttributes.Hidden)) {
						isHi = "Hidden";
					}
					
					
				}
				
				
				if(!listBox1.Items.Contains(path.Split('|')[0] + "|" + isHi)) listBox1.Items.Add(path.Split('|')[0] + "|" + isHi);
			
				}
				}
			
			
			
		}
		
		void TabControl1SelectedIndexChanged(object sender, EventArgs e)
		{
			loadLIstBoxItems();
		}
		void TabControl1DrawItem(object sender, DrawItemEventArgs e)
		{
			
		}
		
		
		void MainFormResize(object sender, EventArgs e)
		{
			if(FormWindowState.Minimized == WindowState) {
				Hide();
				notifyIcon1.Visible = true;  
			}
		}
		void NotifyIcon1MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
			notifyIcon1.Visible = false;  
			
		}
		
		
		
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void LoginToolStripMenuItemClick(object sender, EventArgs e)
		{
			try {
				this.Show();
    			this.WindowState = FormWindowState.Normal;
    			this.ShowInTaskbar = true;
			tabControl1.SelectedIndex = 4;
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void EncryptionToolStripMenuItemClick(object sender, EventArgs e)
		{
			try {
				this.Show();
    			this.WindowState = FormWindowState.Normal;
    			this.ShowInTaskbar = true;
			tabControl1.SelectedIndex = 0;
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void ShredderToolStripMenuItemClick(object sender, EventArgs e)
		{
			try {
				this.Show();
    			this.WindowState = FormWindowState.Normal;
    			this.ShowInTaskbar = true;
			tabControl1.SelectedIndex = 1;
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void SecureFolderToolStripMenuItemClick(object sender, EventArgs e)
		{
			try {
				this.Show();
    			this.WindowState = FormWindowState.Normal;
    			this.ShowInTaskbar = true;
			tabControl1.SelectedIndex = 2;
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void VPNToolStripMenuItemClick(object sender, EventArgs e)
		{
			try {
				this.Show();
    			this.WindowState = FormWindowState.Normal;
    			this.ShowInTaskbar = true;
			tabControl1.SelectedIndex = 3;
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void TorBrowserToolStripMenuItemClick(object sender, EventArgs e)
		{
			try {
			System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "/TorBrowser/TorBrowserPortable.exe");
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void FirewallToolStripMenuItemClick(object sender, EventArgs e)
		{
			try {
			System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "/PapiFirewall/FirewallPApi.exe");
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void LoginPasswordsToolStripMenuItemClick(object sender, EventArgs e)
		{
			try {
				this.Show();
    			this.WindowState = FormWindowState.Normal;
    			this.ShowInTaskbar = true;
			LoginPasswordsForm lpFo = new LoginPasswordsForm();
			lpFo.Show();
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button27Click(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = 5;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}
}
