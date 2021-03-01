using System;
using System.Threading;
using System.Threading.Tasks;
using Leaf.xNet;

namespace SocialClub_Account_Checker
{
	// Token: 0x02000038 RID: 56
	internal class TwoCaptcha
	{
		// Token: 0x0600012C RID: 300 RVA: 0x0000ACF4 File Offset: 0x00008EF4
		public void Start(string key)
		{
			if (this.IsStarted)
			{
				return;
			}
			for (int i = 0; i < 10; i++)
			{
				Variables.TwoCaptchaSources.Add(new CancellationTokenSource());
				CancellationToken token = Variables.TwoCaptchaSources[i].Token;
				Task.Factory.StartNew(delegate()
				{
					while (!token.IsCancellationRequested)
					{
						try
						{
							Thread.Sleep(1000);
							using (HttpRequest httpRequest = new HttpRequest())
							{
								string text = httpRequest.Get("https://2captcha.com/in.php?key=" + key + "&method=funcaptcha&publickey=C63F8033-E94A-40EF-9D56-34726FCB7416&surl=https://client-api.arkoselabs.com&pageurl=https://socialclub.rockstargames.com&header_acao=1", null).ToString();
								if (text.StartsWith("OK|"))
								{
									string str = text.Remove(0, 3);
									for (;;)
									{
										text = httpRequest.Get("https://2captcha.com/res.php?key=" + key + "&action=get&id=" + str, null).ToString();
										if (!text.Equals("CAPCHA_NOT_READY"))
										{
											break;
										}
										Thread.Sleep(1000);
									}
									if (text.StartsWith("OK|"))
									{
										Variables.TokenQueue.Enqueue(text.Remove(0, 3));
									}
								}
							}
						}
						catch
						{
						}
					}
				}, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
			}
			this.IsStarted = true;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000AD80 File Offset: 0x00008F80
		public void Stop()
		{
			if (!this.IsStarted)
			{
				return;
			}
			foreach (CancellationTokenSource cancellationTokenSource in Variables.TwoCaptchaSources)
			{
				cancellationTokenSource.Cancel();
			}
			Variables.TwoCaptchaSources.Clear();
			this.IsStarted = false;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00002383 File Offset: 0x00000583
		public TwoCaptcha()
		{
			Class3.oswSa3wz9mgro();
			base..ctor();
		}

		// Token: 0x040000BD RID: 189
		private bool IsStarted;
	}
}
