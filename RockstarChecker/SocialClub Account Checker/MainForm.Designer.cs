namespace SocialClub_Account_Checker
{
	// Token: 0x0200002E RID: 46
	public partial class MainForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000112 RID: 274 RVA: 0x00002989 File Offset: 0x00000B89
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000A4CC File Offset: 0x000086CC
		private void InitializeComponent()
		{
			this.browser = new global::CefSharp.WinForms.ChromiumWebBrowser();
			this.panel = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			this.browser.ActivateBrowserOnCreation = false;
			this.browser.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.browser.Location = new global::System.Drawing.Point(0, 0);
			this.browser.Name = "browser";
			this.browser.Size = new global::System.Drawing.Size(776, 623);
			this.browser.TabIndex = 0;
			this.panel.Location = new global::System.Drawing.Point(777, 0);
			this.panel.Name = "panel";
			this.panel.Size = new global::System.Drawing.Size(457, 623);
			this.panel.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.WindowFrame;
			base.ClientSize = new global::System.Drawing.Size(776, 623);
			base.Controls.Add(this.panel);
			base.Controls.Add(this.browser);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.Name = "MainForm";
			base.ShowInTaskbar = false;
			this.Text = "Social Club Checker | Alko Community Cracked by Eternity#3333 discord.gg/YqMsv5Xtdb";
			base.WindowState = global::System.Windows.Forms.FormWindowState.Minimized;
			base.ResumeLayout(false);
		}

		// Token: 0x040000B3 RID: 179
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000B4 RID: 180
		internal global::CefSharp.WinForms.ChromiumWebBrowser browser;

		// Token: 0x040000B5 RID: 181
		internal global::System.Windows.Forms.Panel panel;
	}
}
