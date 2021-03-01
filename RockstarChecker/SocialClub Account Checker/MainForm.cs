using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace SocialClub_Account_Checker
{
	// Token: 0x0200002E RID: 46
	public partial class MainForm : Form
	{
		// Token: 0x0600010A RID: 266
		[DllImport("kernel32.dll")]
		private static extern bool AllocConsole();

		// Token: 0x0600010B RID: 267
		[DllImport("kernel32.dll")]
		private static extern IntPtr GetConsoleWindow();

		// Token: 0x0600010C RID: 268
		[DllImport("user32.dll")]
		private static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

		// Token: 0x0600010D RID: 269
		[DllImport("user32.dll")]
		private static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

		// Token: 0x0600010E RID: 270
		[DllImport("user32.dll")]
		private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		// Token: 0x0600010F RID: 271
		[DllImport("user32.dll")]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		// Token: 0x06000110 RID: 272 RVA: 0x0000A378 File Offset: 0x00008578
		public MainForm()
		{
			Class3.oswSa3wz9mgro();
			base..ctor();
			this.InitializeComponent();
			this.browser.LifeSpanHandler = new MainForm.BrowserLifeSpanHandler();
			this.browser.MenuHandler = new MainForm.BrowserContextMenuHandler();
			this.browser.LoadingStateChanged += this.Browser_LoadingStateChanged;
			this.browser.JavascriptObjectRepository.Register("Auth", new Auth(), true, BindingOptions.DefaultBinder);
			this.browser.JavascriptObjectRepository.Register("Checker", new Checker(), true, BindingOptions.DefaultBinder);
			this.browser.JavascriptObjectRepository.Register("TwoCaptcha", new TwoCaptcha(), true, BindingOptions.DefaultBinder);
			this.browser.JavascriptObjectRepository.Register("CapMonsterCloud", new CapMonsterCloud(), true, BindingOptions.DefaultBinder);
			this.browser.JavascriptObjectRepository.Register("Utils", new Utils(), true, BindingOptions.DefaultBinder);
			this.browser.Load((!File.Exists("license.txt") || !AuthGG.Check(File.ReadAllLines("license.txt")[0])) ? string.Format("http://{0}:{1}/auth", IPAddress.Loopback, Program.Port) : string.Format("http://{0}:{1}/initialize", IPAddress.Loopback, Program.Port));
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000296B File Offset: 0x00000B6B
		private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
		{
			if (e.IsLoading)
			{
				return;
			}
			base.Invoke(new MethodInvoker(delegate()
			{
				base.WindowState = FormWindowState.Normal;
				base.ShowInTaskbar = true;
				MainForm.AllocConsole();
				IntPtr consoleWindow = MainForm.GetConsoleWindow();
				MainForm.SetParent(consoleWindow, this.panel.Handle);
				MainForm.SetWindowLong(consoleWindow, -16, new IntPtr((long)((ulong)MainForm.GetWindowLong(consoleWindow, -16) & 18446744073696968703UL & 18446744073709027327UL & 18446744073709289471UL & 18446744073172680703UL & 18446744073709486079UL)));
				MainForm.SetWindowPos(consoleWindow, IntPtr.Zero, 0, 0, this.panel.Width, this.panel.Height, 0U);
				this.browser.LoadingStateChanged -= this.Browser_LoadingStateChanged;
			}));
		}

		// Token: 0x0200002F RID: 47
		private class BrowserLifeSpanHandler : ILifeSpanHandler
		{
			// Token: 0x06000115 RID: 277 RVA: 0x000023A3 File Offset: 0x000005A3
			public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
			{
				return true;
			}

			// Token: 0x06000116 RID: 278 RVA: 0x000029A8 File Offset: 0x00000BA8
			public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
			{
			}

			// Token: 0x06000117 RID: 279 RVA: 0x000029A8 File Offset: 0x00000BA8
			public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
			{
			}

			// Token: 0x06000118 RID: 280 RVA: 0x000029AA File Offset: 0x00000BAA
			public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
			{
				Process.Start(targetUrl);
				newBrowser = null;
				return true;
			}

			// Token: 0x06000119 RID: 281 RVA: 0x00002383 File Offset: 0x00000583
			public BrowserLifeSpanHandler()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}
		}

		// Token: 0x02000030 RID: 48
		private class BrowserContextMenuHandler : IContextMenuHandler
		{
			// Token: 0x0600011A RID: 282 RVA: 0x000029B9 File Offset: 0x00000BB9
			public void OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
			{
				model.Clear();
			}

			// Token: 0x0600011B RID: 283 RVA: 0x000029C3 File Offset: 0x00000BC3
			public bool OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
			{
				return false;
			}

			// Token: 0x0600011C RID: 284 RVA: 0x000029A8 File Offset: 0x00000BA8
			public void OnContextMenuDismissed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
			{
			}

			// Token: 0x0600011D RID: 285 RVA: 0x000029C3 File Offset: 0x00000BC3
			public bool RunContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
			{
				return false;
			}

			// Token: 0x0600011E RID: 286 RVA: 0x00002383 File Offset: 0x00000583
			public BrowserContextMenuHandler()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}
		}
	}
}
