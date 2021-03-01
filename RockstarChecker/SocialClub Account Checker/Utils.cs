using System;
using System.Windows.Forms;

namespace SocialClub_Account_Checker
{
	// Token: 0x0200003B RID: 59
	internal class Utils
	{
		// Token: 0x06000132 RID: 306 RVA: 0x000029C6 File Offset: 0x00000BC6
		public string GetVersion()
		{
			return Variables.Version;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x000029CD File Offset: 0x00000BCD
		public string GetStatus()
		{
			return "Working";
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000AEEC File Offset: 0x000090EC
		public string OpenFileDialog(string filter)
		{
			string result = null;
			Program.MainForm.Invoke(new MethodInvoker(delegate()
			{
				OpenFileDialog openFileDialog = new OpenFileDialog
				{
					Filter = filter
				};
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					result = openFileDialog.FileName;
				}
			}));
			return result;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00002383 File Offset: 0x00000583
		public Utils()
		{
			Class3.oswSa3wz9mgro();
			base..ctor();
		}
	}
}
