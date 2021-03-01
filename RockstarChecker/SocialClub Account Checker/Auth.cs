using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SocialClub_Account_Checker
{
	// Token: 0x02000006 RID: 6
	internal class Auth
	{
		// Token: 0x06000019 RID: 25 RVA: 0x00003444 File Offset: 0x00001644
		public bool Check(string license)
		{
			bool isAuthenticated = true;
			Program.MainForm.Invoke(new MethodInvoker(delegate()
			{
				isAuthenticated = AuthGG.Check(license);
			}));
			if (!isAuthenticated)
			{
				return isAuthenticated;
			}
			using (FileStream fileStream = new FileStream("license.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
			{
				using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Unicode))
				{
					streamWriter.WriteLine(license);
				}
			}
			return isAuthenticated;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002383 File Offset: 0x00000583
		public Auth()
		{
			Class3.oswSa3wz9mgro();
			base..ctor();
		}
	}
}
