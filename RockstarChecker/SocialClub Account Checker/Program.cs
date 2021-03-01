using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace SocialClub_Account_Checker
{
	// Token: 0x02000031 RID: 49
	internal static class Program
	{
		// Token: 0x0600011F RID: 287 RVA: 0x0000A6F8 File Offset: 0x000088F8
		[STAThread]
		private static void Main()
		{
			CefSharpSettings.LegacyJavascriptBindingEnabled = true;
			Cef.Initialize(new CefSettings
			{
				CachePath = null,
				LogSeverity = LogSeverity.Disable,
				CefCommandLineArgs = 
				{
					{
						"disable-gpu",
						"1"
					},
					{
						"disable-extensions",
						"1"
					},
					{
						"disable-pdf-extension",
						"1"
					},
					{
						"disable-application-cache",
						"1"
					},
					{
						"disable-gpu-shader-disk-cache",
						"1"
					},
					{
						"disable-session-storage",
						"1"
					},
					{
						"disable-web-security",
						"1"
					},
					{
						"ignore-certificate-errors",
						"1"
					}
				}
			});
			Program.Port = Variables.Random.Next(49152, 65535);
			HttpListener listener = new HttpListener
			{
				Prefixes = 
				{
					string.Format("http://{0}:{1}/", IPAddress.Loopback, Program.Port)
				}
			};
			listener.Start();
			Task.Factory.StartNew(delegate()
			{
				string text = Path.Combine(Environment.CurrentDirectory, "clientui");
				for (;;)
				{
					HttpListenerContext context = listener.GetContext();
					using (HttpListenerResponse response = context.Response)
					{
						string path = text + context.Request.Url.AbsolutePath.Replace("/", "\\");
						if (File.Exists(path))
						{
							byte[] bytes = Encoding.UTF8.GetBytes(File.ReadAllText(path));
							response.ContentLength64 = (long)bytes.Length;
							response.OutputStream.Write(bytes, 0, bytes.Length);
						}
						else
						{
							byte[] bytes2 = Encoding.UTF8.GetBytes(File.ReadAllText(Path.Combine(text, "index.html")));
							response.ContentLength64 = (long)bytes2.Length;
							response.OutputStream.Write(bytes2, 0, bytes2.Length);
						}
					}
				}
			});
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Class3.oswSa3wz9mgro();
			Program.MainForm = new MainForm();
			Application.Run(Program.MainForm);
		}

		// Token: 0x040000B6 RID: 182
		public static MainForm MainForm;

		// Token: 0x040000B7 RID: 183
		public static int Port;
	}
}
