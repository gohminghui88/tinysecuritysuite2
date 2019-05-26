/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 19/05/2019
 * Time: 11:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TinySecuritySuite
{
	/// <summary>
	/// Description of LoginPasswordsForm.
	/// </summary>
	public partial class LoginPasswordsForm : Form
	{
		public LoginPasswordsForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			if(textBox1.Text == textBox2.Text) {
				StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\parameters.ini");
				sw.WriteLine(encryptStringAES(textBox1.Text, textBox1.Text));
				sw.Close();
				
				MessageBox.Show("Passwords Modified. ");
			}
		}
		
		public string encryptStringAES(string plainText, string passPhrase) {
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
		
		public string decryptStringAES(string encryptedText, string passPhrase) {
			
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
	}
}
