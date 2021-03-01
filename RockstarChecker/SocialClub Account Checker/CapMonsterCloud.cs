using System;
using System.Threading;
using System.Threading.Tasks;
using Leaf.xNet;
using Newtonsoft.Json;

namespace SocialClub_Account_Checker
{
	// Token: 0x02000014 RID: 20
	internal class CapMonsterCloud
	{
		// Token: 0x06000087 RID: 135 RVA: 0x0000438C File Offset: 0x0000258C
		public void Start(string key)
		{
			if (this.IsStarted)
			{
				return;
			}
			for (int i = 0; i < 10; i++)
			{
				Variables.CapMonsterCloudSources.Add(new CancellationTokenSource());
				CancellationToken token = Variables.CapMonsterCloudSources[i].Token;
				Task.Factory.StartNew(delegate()
				{
					while (!token.IsCancellationRequested)
					{
						try
						{
							Thread.Sleep(1000);
							using (HttpRequest httpRequest = new HttpRequest())
							{
								string text = httpRequest.Get("https://api.capmonster.cloud/in.php?key=" + key + "&method=funcaptcha&publickey=C63F8033-E94A-40EF-9D56-34726FCB7416&surl=https://client-api.arkoselabs.com&pageurl=https://socialclub.rockstargames.com&header_acao=1", null).ToString();
								if (text.StartsWith("OK|"))
								{
									string str = text.Remove(0, 3);
									for (;;)
									{
										text = httpRequest.Get("https://api.capmonster.cloud/res.php?key=" + key + "&action=get&id=" + str, null).ToString();
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

		// Token: 0x06000088 RID: 136 RVA: 0x00004418 File Offset: 0x00002618
		public void Stop()
		{
			if (!this.IsStarted)
			{
				return;
			}
			foreach (CancellationTokenSource cancellationTokenSource in Variables.CapMonsterCloudSources)
			{
				cancellationTokenSource.Cancel();
			}
			Variables.CapMonsterCloudSources.Clear();
			this.IsStarted = false;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00002383 File Offset: 0x00000583
		public CapMonsterCloud()
		{
			Class3.oswSa3wz9mgro();
			base..ctor();
		}

		// Token: 0x04000049 RID: 73
		private bool IsStarted;

		// Token: 0x02000015 RID: 21
		private class CreateTaskResponse
		{
			// Token: 0x17000026 RID: 38
			// (get) Token: 0x0600008A RID: 138 RVA: 0x000026F4 File Offset: 0x000008F4
			// (set) Token: 0x0600008B RID: 139 RVA: 0x000026FC File Offset: 0x000008FC
			[JsonProperty("errorId")]
			public int ErrorId { get; set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x0600008C RID: 140 RVA: 0x00002705 File Offset: 0x00000905
			// (set) Token: 0x0600008D RID: 141 RVA: 0x0000270D File Offset: 0x0000090D
			[JsonProperty("taskId")]
			public long TaskId { get; set; }

			// Token: 0x0600008E RID: 142 RVA: 0x00002383 File Offset: 0x00000583
			public CreateTaskResponse()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}
		}

		// Token: 0x02000016 RID: 22
		private class GetTaskResponse
		{
			// Token: 0x17000028 RID: 40
			// (get) Token: 0x0600008F RID: 143 RVA: 0x00002716 File Offset: 0x00000916
			// (set) Token: 0x06000090 RID: 144 RVA: 0x0000271E File Offset: 0x0000091E
			[JsonProperty("errorId")]
			public int ErrorId { get; set; }

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x06000091 RID: 145 RVA: 0x00002727 File Offset: 0x00000927
			// (set) Token: 0x06000092 RID: 146 RVA: 0x0000272F File Offset: 0x0000092F
			[JsonProperty("status")]
			public string Status { get; set; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x06000093 RID: 147 RVA: 0x00002738 File Offset: 0x00000938
			// (set) Token: 0x06000094 RID: 148 RVA: 0x00002740 File Offset: 0x00000940
			[JsonProperty("solution")]
			public CapMonsterCloud.GetTaskResponseSolution Solution { get; set; }

			// Token: 0x06000095 RID: 149 RVA: 0x00002383 File Offset: 0x00000583
			public GetTaskResponse()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}
		}

		// Token: 0x02000017 RID: 23
		public class GetTaskResponseSolution
		{
			// Token: 0x1700002B RID: 43
			// (get) Token: 0x06000096 RID: 150 RVA: 0x00002749 File Offset: 0x00000949
			// (set) Token: 0x06000097 RID: 151 RVA: 0x00002751 File Offset: 0x00000951
			[JsonProperty("token")]
			public string Token { get; set; }

			// Token: 0x06000098 RID: 152 RVA: 0x00002383 File Offset: 0x00000583
			public GetTaskResponseSolution()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}
		}
	}
}
