using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SocialClub_Account_Checker
{
	// Token: 0x02000008 RID: 8
	internal class AuthGG
	{
		// Token: 0x0600001D RID: 29 RVA: 0x000023A3 File Offset: 0x000005A3
		public static bool Check(string license)
		{
			return true;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002383 File Offset: 0x00000583
		public AuthGG()
		{
			Class3.oswSa3wz9mgro();
			base..ctor();
		}

		// Token: 0x02000009 RID: 9
		internal class App
		{
			// Token: 0x0600001F RID: 31 RVA: 0x00002383 File Offset: 0x00000583
			public App()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}

			// Token: 0x06000020 RID: 32 RVA: 0x000023A6 File Offset: 0x000005A6
			static App()
			{
				Class3.oswSa3wz9mgro();
				AuthGG.App.Variables = new Dictionary<string, string>();
			}

			// Token: 0x04000015 RID: 21
			public static Dictionary<string, string> Variables;
		}

		// Token: 0x0200000A RID: 10
		internal class ApplicationSettings
		{
			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000021 RID: 33 RVA: 0x000023B7 File Offset: 0x000005B7
			// (set) Token: 0x06000022 RID: 34 RVA: 0x000023BE File Offset: 0x000005BE
			public static bool Status { get; set; }

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x06000023 RID: 35 RVA: 0x000023C6 File Offset: 0x000005C6
			// (set) Token: 0x06000024 RID: 36 RVA: 0x000023CD File Offset: 0x000005CD
			public static bool DeveloperMode { get; set; }

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000025 RID: 37 RVA: 0x000023D5 File Offset: 0x000005D5
			// (set) Token: 0x06000026 RID: 38 RVA: 0x000023DC File Offset: 0x000005DC
			public static string Hash { get; set; }

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x06000027 RID: 39 RVA: 0x000023E4 File Offset: 0x000005E4
			// (set) Token: 0x06000028 RID: 40 RVA: 0x000023EB File Offset: 0x000005EB
			public static string Version { get; set; }

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x06000029 RID: 41 RVA: 0x000023F3 File Offset: 0x000005F3
			// (set) Token: 0x0600002A RID: 42 RVA: 0x000023FA File Offset: 0x000005FA
			public static string Update_Link { get; set; }

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x0600002B RID: 43 RVA: 0x00002402 File Offset: 0x00000602
			// (set) Token: 0x0600002C RID: 44 RVA: 0x00002409 File Offset: 0x00000609
			public static bool Freemode { get; set; }

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x0600002D RID: 45 RVA: 0x00002411 File Offset: 0x00000611
			// (set) Token: 0x0600002E RID: 46 RVA: 0x00002418 File Offset: 0x00000618
			public static bool Login { get; set; }

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x0600002F RID: 47 RVA: 0x00002420 File Offset: 0x00000620
			// (set) Token: 0x06000030 RID: 48 RVA: 0x00002427 File Offset: 0x00000627
			public static string Name { get; set; }

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000031 RID: 49 RVA: 0x0000242F File Offset: 0x0000062F
			// (set) Token: 0x06000032 RID: 50 RVA: 0x00002436 File Offset: 0x00000636
			public static bool Register { get; set; }

			// Token: 0x06000033 RID: 51 RVA: 0x00002383 File Offset: 0x00000583
			public ApplicationSettings()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}
		}

		// Token: 0x0200000B RID: 11
		internal class Security
		{
			// Token: 0x06000034 RID: 52 RVA: 0x000034EC File Offset: 0x000016EC
			public static string Signature(string value)
			{
				string result;
				using (MD5 md = MD5.Create())
				{
					byte[] bytes = Encoding.UTF8.GetBytes(value);
					result = BitConverter.ToString(md.ComputeHash(bytes)).Replace("-", "");
				}
				return result;
			}

			// Token: 0x06000035 RID: 53 RVA: 0x0000243E File Offset: 0x0000063E
			private static string Session(int length)
			{
				return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz", length)
				select s[AuthGG.Constants.RandomInt(s.Length)]).ToArray<char>());
			}

			// Token: 0x06000036 RID: 54 RVA: 0x00002479 File Offset: 0x00000679
			public static string Obfuscate(int length)
			{
				return new string((from s in Enumerable.Repeat<string>("gd8JQ57nxXzLLMPrLylVhxoGnWGCFjO4knKTfRE6mVvdjug2NF/4aptAsZcdIGbAPmcx0O+ftU/KvMIjcfUnH3j+IMdhAW5OpoX3MrjQdf5AAP97tTB5g1wdDSAqKpq9gw06t3VaqMWZHKtPSuAXy0kkZRsc+DicpcY8E9+vWMHXa3jMdbPx4YES0p66GzhqLd/heA2zMvX8iWv4wK7S3QKIW/a9dD4ALZJpmcr9OOE=", length)
				select s[AuthGG.Constants.RandomInt(s.Length)]).ToArray<char>());
			}

			// Token: 0x06000037 RID: 55 RVA: 0x00003544 File Offset: 0x00001744
			public static void Start()
			{
				string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
				if (AuthGG.Constants.Started)
				{
					MessageBox.Show("A session has already been started, please end the previous one!\nError code: 254", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Process.GetCurrentProcess().Kill();
					return;
				}
				using (StreamReader streamReader = new StreamReader(pathRoot + "Windows\\System32\\drivers\\etc\\hosts"))
				{
					if (streamReader.ReadToEnd().Contains("api.auth.gg"))
					{
						AuthGG.Constants.Breached = true;
						MessageBox.Show("DNS redirecting has been detected!\nError code: 266", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						Process.GetCurrentProcess().Kill();
					}
				}
				new AuthGG.InfoManager().StartListener();
				AuthGG.Constants.Token = Guid.NewGuid().ToString();
				ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback(AuthGG.Security.PinPublicKey));
				AuthGG.Constants.APIENCRYPTKEY = Convert.ToBase64String(Encoding.Default.GetBytes(AuthGG.Security.Session(32)));
				AuthGG.Constants.APIENCRYPTSALT = Convert.ToBase64String(Encoding.Default.GetBytes(AuthGG.Security.Session(16)));
				AuthGG.Constants.IV = Convert.ToBase64String(Encoding.Default.GetBytes(AuthGG.Constants.RandomString(16)));
				AuthGG.Constants.Key = Convert.ToBase64String(Encoding.Default.GetBytes(AuthGG.Constants.RandomString(32)));
				AuthGG.Constants.Started = true;
			}

			// Token: 0x06000038 RID: 56 RVA: 0x00003698 File Offset: 0x00001898
			public static void End()
			{
				if (!AuthGG.Constants.Started)
				{
					MessageBox.Show("No session has been started, closing for security reasons!\nError code: 287", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Process.GetCurrentProcess().Kill();
					return;
				}
				AuthGG.Constants.Token = null;
				ServicePointManager.ServerCertificateValidationCallback = ((object <p0>, X509Certificate <p1>, X509Chain <p2>, SslPolicyErrors <p3>) => true);
				AuthGG.Constants.APIENCRYPTKEY = null;
				AuthGG.Constants.APIENCRYPTSALT = null;
				AuthGG.Constants.IV = null;
				AuthGG.Constants.Key = null;
				AuthGG.Constants.Started = false;
			}

			// Token: 0x06000039 RID: 57 RVA: 0x000024B4 File Offset: 0x000006B4
			private static bool PinPublicKey(object sender, X509Certificate certificate, object chain, SslPolicyErrors sslPolicyErrors)
			{
				return certificate != null && certificate.GetPublicKeyString() == "046EECD33E469E9E1958D6BEEDE0A71843202724A5758BD1723F6C340C5E98EDE06FF5C21B35F359C65B850744729B3AA999B0B6392DA69EDB278EB31DBCE85774";
			}

			// Token: 0x0600003A RID: 58 RVA: 0x00003714 File Offset: 0x00001914
			public static string Integrity(string filename)
			{
				string result;
				using (SHA1 sha = SHA1.Create())
				{
					using (FileStream fileStream = File.OpenRead(filename))
					{
						result = BitConverter.ToString(sha.ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
					}
				}
				return result;
			}

			// Token: 0x0600003B RID: 59 RVA: 0x00003784 File Offset: 0x00001984
			public static bool MaliciousCheck(string date)
			{
				DateTime d = DateTime.Parse(date);
				DateTime now = DateTime.Now;
				TimeSpan timeSpan = d - now;
				if (Convert.ToInt32(timeSpan.Seconds.ToString().Replace("-", "")) < 5 && Convert.ToInt32(timeSpan.Minutes.ToString().Replace("-", "")) < 1)
				{
					return false;
				}
				AuthGG.Constants.Breached = true;
				return true;
			}

			// Token: 0x0600003C RID: 60 RVA: 0x00002383 File Offset: 0x00000583
			public Security()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}
		}

		// Token: 0x0200000D RID: 13
		internal class Constants
		{
			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000042 RID: 66 RVA: 0x000024EF File Offset: 0x000006EF
			// (set) Token: 0x06000043 RID: 67 RVA: 0x000024F6 File Offset: 0x000006F6
			public static string Token { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x06000044 RID: 68 RVA: 0x000024FE File Offset: 0x000006FE
			// (set) Token: 0x06000045 RID: 69 RVA: 0x00002505 File Offset: 0x00000705
			public static string Date { get; set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x06000046 RID: 70 RVA: 0x0000250D File Offset: 0x0000070D
			// (set) Token: 0x06000047 RID: 71 RVA: 0x00002514 File Offset: 0x00000714
			public static string APIENCRYPTKEY { get; set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000048 RID: 72 RVA: 0x0000251C File Offset: 0x0000071C
			// (set) Token: 0x06000049 RID: 73 RVA: 0x00002523 File Offset: 0x00000723
			public static string APIENCRYPTSALT { get; set; }

			// Token: 0x0600004A RID: 74 RVA: 0x0000252B File Offset: 0x0000072B
			public static string RandomString(int length)
			{
				return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
				select s[AuthGG.Constants.random.Next(s.Length)]).ToArray<char>());
			}

			// Token: 0x0600004B RID: 75 RVA: 0x00002566 File Offset: 0x00000766
			public static int RandomInt(int length)
			{
				return AuthGG.Constants.random.Next(length);
			}

			// Token: 0x0600004C RID: 76 RVA: 0x000037FC File Offset: 0x000019FC
			public static string HWID()
			{
				if (AuthGG.Constants._hwid != null)
				{
					return AuthGG.Constants._hwid;
				}
				using (SHA256 sha = SHA256.Create())
				{
					byte[] array = sha.ComputeHash(Encoding.UTF8.GetBytes("test"));
					StringBuilder stringBuilder = new StringBuilder();
					foreach (byte b in array)
					{
						stringBuilder.Append(b.ToString("x2"));
					}
					AuthGG.Constants._hwid = stringBuilder.ToString();
				}
				return AuthGG.Constants._hwid;
			}

			// Token: 0x0600004D RID: 77 RVA: 0x0000388C File Offset: 0x00001A8C
			private static string Identifier(string wmiClass, string wmiProperty)
			{
				string text = null;
				foreach (ManagementBaseObject managementBaseObject in new ManagementClass(wmiClass).GetInstances())
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					if (text == null && managementObject[wmiProperty] != null)
					{
						try
						{
							text = managementObject[wmiProperty].ToString();
							break;
						}
						catch
						{
						}
					}
				}
				return text;
			}

			// Token: 0x0600004E RID: 78 RVA: 0x0000390C File Offset: 0x00001B0C
			private static string CpuId()
			{
				return string.Concat(new string[]
				{
					AuthGG.Constants.Identifier("Win32_Processor", "UniqueId"),
					AuthGG.Constants.Identifier("Win32_Processor", "ProcessorId"),
					AuthGG.Constants.Identifier("Win32_Processor", "Name"),
					AuthGG.Constants.Identifier("Win32_Processor", "Manufacturer"),
					AuthGG.Constants.Identifier("Win32_Processor", "MaxClockSpeed")
				});
			}

			// Token: 0x0600004F RID: 79 RVA: 0x00003980 File Offset: 0x00001B80
			private static string BiosId()
			{
				return string.Concat(new string[]
				{
					AuthGG.Constants.Identifier("Win32_BIOS", "Manufacturer"),
					AuthGG.Constants.Identifier("Win32_BIOS", "SMBIOSBIOSVersion"),
					AuthGG.Constants.Identifier("Win32_BIOS", "IdentificationCode"),
					AuthGG.Constants.Identifier("Win32_BIOS", "SerialNumber"),
					AuthGG.Constants.Identifier("Win32_BIOS", "ReleaseDate"),
					AuthGG.Constants.Identifier("Win32_BIOS", "Version")
				});
			}

			// Token: 0x06000050 RID: 80 RVA: 0x00003A04 File Offset: 0x00001C04
			private static string DiskId()
			{
				return AuthGG.Constants.Identifier("Win32_DiskDrive", "Model") + AuthGG.Constants.Identifier("Win32_DiskDrive", "Manufacturer") + AuthGG.Constants.Identifier("Win32_DiskDrive", "Signature") + AuthGG.Constants.Identifier("Win32_DiskDrive", "TotalHeads");
			}

			// Token: 0x06000051 RID: 81 RVA: 0x00003A54 File Offset: 0x00001C54
			private static string BaseId()
			{
				return AuthGG.Constants.Identifier("Win32_BaseBoard", "Model") + AuthGG.Constants.Identifier("Win32_BaseBoard", "Manufacturer") + AuthGG.Constants.Identifier("Win32_BaseBoard", "Name") + AuthGG.Constants.Identifier("Win32_BaseBoard", "SerialNumber");
			}

			// Token: 0x06000052 RID: 82 RVA: 0x00002383 File Offset: 0x00000583
			public Constants()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}

			// Token: 0x06000053 RID: 83 RVA: 0x00002573 File Offset: 0x00000773
			static Constants()
			{
				Class3.oswSa3wz9mgro();
				AuthGG.Constants.ApiUrl = "https://api.auth.gg/csharp/";
				AuthGG.Constants.random = new Random();
			}

			// Token: 0x04000027 RID: 39
			public static bool Breached;

			// Token: 0x04000028 RID: 40
			public static bool Started;

			// Token: 0x04000029 RID: 41
			public static string IV;

			// Token: 0x0400002A RID: 42
			public static string Key;

			// Token: 0x0400002B RID: 43
			public static string ApiUrl;

			// Token: 0x0400002C RID: 44
			public static bool Initialized;

			// Token: 0x0400002D RID: 45
			public static Random random;

			// Token: 0x0400002E RID: 46
			private static string _hwid;
		}

		// Token: 0x0200000F RID: 15
		internal class OnProgramStart
		{
			// Token: 0x06000057 RID: 87 RVA: 0x00003AA4 File Offset: 0x00001CA4
			public static void Initialize(string name, string aid, string secret, string version)
			{
				AuthGG.Constants.HWID();
				if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(aid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
				{
					MessageBox.Show("Invalid application information!\nError code: 398", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Process.GetCurrentProcess().Kill();
				}
				AuthGG.OnProgramStart.AID = aid;
				AuthGG.OnProgramStart.Secret = secret;
				AuthGG.OnProgramStart.Version = version;
				AuthGG.OnProgramStart.Name = name;
				using (WebClient webClient = new WebClient
				{
					Proxy = null
				})
				{
					try
					{
						AuthGG.Security.Start();
						Encoding @default = Encoding.Default;
						WebClient webClient2 = webClient;
						string apiUrl = AuthGG.Constants.ApiUrl;
						NameValueCollection nameValueCollection = new NameValueCollection();
						nameValueCollection["token"] = AuthGG.Encryption.EncryptService(AuthGG.Constants.Token);
						nameValueCollection["timestamp"] = AuthGG.Encryption.EncryptService(DateTime.Now.ToString(CultureInfo.CurrentCulture));
						nameValueCollection["aid"] = AuthGG.Encryption.smethod_0(AuthGG.OnProgramStart.AID);
						nameValueCollection["session_id"] = AuthGG.Constants.IV;
						nameValueCollection["api_id"] = AuthGG.Constants.APIENCRYPTSALT;
						nameValueCollection["api_key"] = AuthGG.Constants.APIENCRYPTKEY;
						nameValueCollection["session_key"] = AuthGG.Constants.Key;
						nameValueCollection["secret"] = AuthGG.Encryption.smethod_0(AuthGG.OnProgramStart.Secret);
						nameValueCollection["type"] = AuthGG.Encryption.smethod_0("start");
						string[] array = AuthGG.Encryption.DecryptService(@default.GetString(webClient2.UploadValues(apiUrl, nameValueCollection))).Split("|".ToCharArray());
						if (AuthGG.Security.MaliciousCheck(array[1]))
						{
							MessageBox.Show("Possible malicious activity detected!\nError code: 428", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							Process.GetCurrentProcess().Kill();
						}
						if (AuthGG.Constants.Breached)
						{
							MessageBox.Show("Possible malicious activity detected!\nError code: 434", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							Process.GetCurrentProcess().Kill();
						}
						if (array[0] != AuthGG.Constants.Token)
						{
							MessageBox.Show("Security error has been triggered!\nError code: 440", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							Process.GetCurrentProcess().Kill();
						}
						string text = array[2];
						if (text != null)
						{
							if (!(text == "success"))
							{
								if (text == "binderror")
								{
									MessageBox.Show("Unable to connect to the server.\nError code: 516", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand);
									Process.GetCurrentProcess().Kill();
									return;
								}
								if (text == "banned")
								{
									MessageBox.Show("Internal server error, please contact support!\nError code: 520", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand);
									Process.GetCurrentProcess().Kill();
									return;
								}
							}
							else
							{
								AuthGG.Constants.Initialized = true;
								if (array[3] == "Enabled")
								{
									AuthGG.ApplicationSettings.Status = true;
								}
								if (array[4] == "Enabled")
								{
									AuthGG.ApplicationSettings.DeveloperMode = false;
								}
								AuthGG.ApplicationSettings.Hash = array[5];
								AuthGG.ApplicationSettings.Version = array[6];
								AuthGG.ApplicationSettings.Update_Link = array[7];
								if (array[8] == "Enabled")
								{
									AuthGG.ApplicationSettings.Freemode = true;
								}
								if (array[9] == "Enabled")
								{
									AuthGG.ApplicationSettings.Login = true;
								}
								AuthGG.ApplicationSettings.Name = array[10];
								if (array[11] == "Enabled")
								{
									AuthGG.ApplicationSettings.Register = true;
								}
								if (AuthGG.ApplicationSettings.DeveloperMode)
								{
									MessageBox.Show("Application is in Developer Mode, bypassing integrity and update check!", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
									File.Create(Environment.CurrentDirectory + "/integrity.log").Close();
									ProcessModule mainModule = Process.GetCurrentProcess().MainModule;
									string contents = AuthGG.Security.Integrity((mainModule != null) ? mainModule.FileName : null);
									File.WriteAllText(Environment.CurrentDirectory + "/integrity.log", contents);
									MessageBox.Show("Your applications hash has been saved to integrity.txt, please refer to this when your application is ready for release!", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
								if (!AuthGG.ApplicationSettings.Status)
								{
									MessageBox.Show("Looks like this application is disabled, please try again later!\nError code: 510", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand);
									Process.GetCurrentProcess().Kill();
								}
							}
						}
						AuthGG.Security.End();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message + "\nError code: 529", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						Process.GetCurrentProcess().Kill();
					}
				}
			}

			// Token: 0x06000058 RID: 88 RVA: 0x00002383 File Offset: 0x00000583
			public OnProgramStart()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}

			// Token: 0x06000059 RID: 89 RVA: 0x000025B7 File Offset: 0x000007B7
			static OnProgramStart()
			{
				Class3.oswSa3wz9mgro();
			}

			// Token: 0x04000031 RID: 49
			public static string AID;

			// Token: 0x04000032 RID: 50
			public static string Secret;

			// Token: 0x04000033 RID: 51
			public static string Version;

			// Token: 0x04000034 RID: 52
			public static string Name;

			// Token: 0x04000035 RID: 53
			public static object Salt;
		}

		// Token: 0x02000010 RID: 16
		internal class Encryption
		{
			// Token: 0x0600005A RID: 90 RVA: 0x00003EAC File Offset: 0x000020AC
			public static string smethod_0(string value)
			{
				string @string = Encoding.Default.GetString(Convert.FromBase64String(AuthGG.Constants.APIENCRYPTKEY));
				byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string));
				byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(AuthGG.Constants.APIENCRYPTSALT)));
				return AuthGG.Encryption.EncryptString(value, key, bytes);
			}

			// Token: 0x0600005B RID: 91 RVA: 0x00003F0C File Offset: 0x0000210C
			public static string EncryptService(string value)
			{
				string @string = Encoding.Default.GetString(Convert.FromBase64String(AuthGG.Constants.APIENCRYPTKEY));
				byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string));
				byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(AuthGG.Constants.APIENCRYPTSALT)));
				string str = AuthGG.Encryption.EncryptString(value, key, bytes);
				int length = int.Parse(AuthGG.OnProgramStart.AID.Substring(0, 2));
				return str + AuthGG.Security.Obfuscate(length);
			}

			// Token: 0x0600005C RID: 92 RVA: 0x00003F88 File Offset: 0x00002188
			public static string DecryptService(string value)
			{
				string @string = Encoding.Default.GetString(Convert.FromBase64String(AuthGG.Constants.APIENCRYPTKEY));
				byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string));
				byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(AuthGG.Constants.APIENCRYPTSALT)));
				return AuthGG.Encryption.DecryptString(value, key, bytes);
			}

			// Token: 0x0600005D RID: 93 RVA: 0x00003FE8 File Offset: 0x000021E8
			public static string EncryptString(string plainText, byte[] key, byte[] iv)
			{
				Aes aes = Aes.Create();
				aes.Mode = CipherMode.CBC;
				aes.Key = key;
				aes.IV = iv;
				MemoryStream memoryStream = new MemoryStream();
				ICryptoTransform transform = aes.CreateEncryptor();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
				byte[] bytes = Encoding.ASCII.GetBytes(plainText);
				cryptoStream.Write(bytes, 0, bytes.Length);
				cryptoStream.FlushFinalBlock();
				byte[] array = memoryStream.ToArray();
				memoryStream.Close();
				cryptoStream.Close();
				return Convert.ToBase64String(array, 0, array.Length);
			}

			// Token: 0x0600005E RID: 94 RVA: 0x00004064 File Offset: 0x00002264
			public static string DecryptString(string cipherText, byte[] key, byte[] iv)
			{
				Aes aes = Aes.Create();
				aes.Mode = CipherMode.CBC;
				aes.Key = key;
				aes.IV = iv;
				MemoryStream memoryStream = new MemoryStream();
				ICryptoTransform transform = aes.CreateDecryptor();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
				string @string;
				try
				{
					byte[] array = Convert.FromBase64String(cipherText);
					cryptoStream.Write(array, 0, array.Length);
					cryptoStream.FlushFinalBlock();
					byte[] array2 = memoryStream.ToArray();
					@string = Encoding.ASCII.GetString(array2, 0, array2.Length);
				}
				finally
				{
					memoryStream.Close();
					cryptoStream.Close();
				}
				return @string;
			}

			// Token: 0x0600005F RID: 95 RVA: 0x000040FC File Offset: 0x000022FC
			public static string Decode(string text)
			{
				text = text.Replace('_', '/').Replace('-', '+');
				int num = text.Length % 4;
				if (num != 2)
				{
					if (num == 3)
					{
						text += "=";
					}
				}
				else
				{
					text += "==";
				}
				return Encoding.UTF8.GetString(Convert.FromBase64String(text));
			}

			// Token: 0x06000060 RID: 96 RVA: 0x00002383 File Offset: 0x00000583
			public Encryption()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}
		}

		// Token: 0x02000011 RID: 17
		private class InfoManager
		{
			// Token: 0x06000061 RID: 97 RVA: 0x000025BE File Offset: 0x000007BE
			public InfoManager()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
				this.lastGateway = AuthGG.InfoManager.GetGatewayMAC();
			}

			// Token: 0x06000062 RID: 98 RVA: 0x000025D6 File Offset: 0x000007D6
			public void StartListener()
			{
				this.timer = new System.Threading.Timer(delegate(object _)
				{
					this.OnCallBack();
				}, null, 5000, -1);
			}

			// Token: 0x06000063 RID: 99 RVA: 0x00004160 File Offset: 0x00002360
			private void OnCallBack()
			{
				this.timer.Dispose();
				if (AuthGG.InfoManager.GetGatewayMAC() != this.lastGateway)
				{
					AuthGG.Constants.Breached = true;
					MessageBox.Show("ARP Cache poisoning has been detected!\nError code: 669", AuthGG.OnProgramStart.Name, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Process.GetCurrentProcess().Kill();
				}
				else
				{
					this.lastGateway = AuthGG.InfoManager.GetGatewayMAC();
				}
				this.timer = new System.Threading.Timer(delegate(object _)
				{
					this.OnCallBack();
				}, null, 5000, -1);
			}

			// Token: 0x06000064 RID: 100 RVA: 0x000041D8 File Offset: 0x000023D8
			private static IPAddress GetDefaultGateway()
			{
				return (from n in NetworkInterface.GetAllNetworkInterfaces()
				where n.OperationalStatus == OperationalStatus.Up
				where n.NetworkInterfaceType != NetworkInterfaceType.Loopback
				select n).SelectMany(delegate(NetworkInterface n)
				{
					IPInterfaceProperties ipproperties = n.GetIPProperties();
					if (ipproperties == null)
					{
						return null;
					}
					return ipproperties.GatewayAddresses;
				}).Select(delegate(GatewayIPAddressInformation g)
				{
					if (g == null)
					{
						return null;
					}
					return g.Address;
				}).FirstOrDefault((IPAddress a) => a != null);
			}

			// Token: 0x06000065 RID: 101 RVA: 0x000042A0 File Offset: 0x000024A0
			private static string GetArpTable()
			{
				string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
				string result;
				using (Process process = Process.Start(new ProcessStartInfo
				{
					FileName = pathRoot + "Windows\\System32\\arp.exe",
					Arguments = "-a",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				}))
				{
					using (StreamReader streamReader = (process != null) ? process.StandardOutput : null)
					{
						result = ((streamReader != null) ? streamReader.ReadToEnd() : null);
					}
				}
				return result;
			}

			// Token: 0x06000066 RID: 102 RVA: 0x00004344 File Offset: 0x00002544
			private static string GetGatewayMAC()
			{
				string str = AuthGG.InfoManager.GetDefaultGateway().ToString();
				return new Regex("(" + str + " [\\W]*) ([a-z0-9-]*)").Match(AuthGG.InfoManager.GetArpTable()).Groups[2].ToString();
			}

			// Token: 0x04000036 RID: 54
			private System.Threading.Timer timer;

			// Token: 0x04000037 RID: 55
			private string lastGateway;
		}

		// Token: 0x02000013 RID: 19
		internal class User
		{
			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000070 RID: 112 RVA: 0x0000264F File Offset: 0x0000084F
			// (set) Token: 0x06000071 RID: 113 RVA: 0x00002656 File Offset: 0x00000856
			public static string ID { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000072 RID: 114 RVA: 0x0000265E File Offset: 0x0000085E
			// (set) Token: 0x06000073 RID: 115 RVA: 0x00002665 File Offset: 0x00000865
			public static string Username { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000074 RID: 116 RVA: 0x0000266D File Offset: 0x0000086D
			// (set) Token: 0x06000075 RID: 117 RVA: 0x00002674 File Offset: 0x00000874
			public static string Password { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000076 RID: 118 RVA: 0x0000267C File Offset: 0x0000087C
			// (set) Token: 0x06000077 RID: 119 RVA: 0x00002683 File Offset: 0x00000883
			public static string Email { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x06000078 RID: 120 RVA: 0x0000268B File Offset: 0x0000088B
			// (set) Token: 0x06000079 RID: 121 RVA: 0x00002692 File Offset: 0x00000892
			public static string HWID { get; set; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x0600007A RID: 122 RVA: 0x0000269A File Offset: 0x0000089A
			// (set) Token: 0x0600007B RID: 123 RVA: 0x000026A1 File Offset: 0x000008A1
			public static string IP { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x0600007C RID: 124 RVA: 0x000026A9 File Offset: 0x000008A9
			// (set) Token: 0x0600007D RID: 125 RVA: 0x000026B0 File Offset: 0x000008B0
			public static string UserVariable { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x0600007E RID: 126 RVA: 0x000026B8 File Offset: 0x000008B8
			// (set) Token: 0x0600007F RID: 127 RVA: 0x000026BF File Offset: 0x000008BF
			public static string Rank { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x06000080 RID: 128 RVA: 0x000026C7 File Offset: 0x000008C7
			// (set) Token: 0x06000081 RID: 129 RVA: 0x000026CE File Offset: 0x000008CE
			public static string Expiry { get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x06000082 RID: 130 RVA: 0x000026D6 File Offset: 0x000008D6
			// (set) Token: 0x06000083 RID: 131 RVA: 0x000026DD File Offset: 0x000008DD
			public static string LastLogin { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x06000084 RID: 132 RVA: 0x000026E5 File Offset: 0x000008E5
			// (set) Token: 0x06000085 RID: 133 RVA: 0x000026EC File Offset: 0x000008EC
			public static string RegisterDate { get; set; }

			// Token: 0x06000086 RID: 134 RVA: 0x00002383 File Offset: 0x00000583
			public User()
			{
				Class3.oswSa3wz9mgro();
				base..ctor();
			}
		}
	}
}
