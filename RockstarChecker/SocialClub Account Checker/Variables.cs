using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace SocialClub_Account_Checker
{
	// Token: 0x0200003D RID: 61
	internal class Variables
	{
		// Token: 0x06000138 RID: 312 RVA: 0x00002383 File Offset: 0x00000583
		public Variables()
		{
			Class3.oswSa3wz9mgro();
			base..ctor();
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000AF60 File Offset: 0x00009160
		static Variables()
		{
			Class3.oswSa3wz9mgro();
			Variables.string_0 = "3082010A0282010100ABF63EE1CE76B59952830EC230B543AA38BC59D090DA8FC22E76DE1FD28F8D52E3219C7828DE05290F46476C496F0E8D3C41CCC829A234E1E9640F6E1A14410F370D6C64E6499AA76F62DFF48E58A48DBA10FDCC11758CC7C0536E5947B40EC2B0EBEAB825C53EF15FD57C703EFB3A48111D33B3480271EDD580B294C9A72880F70E46F2146C89FBAF0F16EEB53F4243BE9F8FA6AA70CE0A723D180A15CEF1FEB200B0A9EE63C0B1E69CEE33E88435DC98583953EBBA65020612791547BD3AA25EE791D509EA2824F482C0E137DE4821C5B5114A8EC40535DC61D673F8308A769468B34F67FF67E901CF655109D3CDB0FD04DD0FBD19F9649705393B84423D030203010001";
			Variables.Version = "2.0.8";
			Variables.Locker = new object();
			Variables.Random = new Random();
			Variables.ProxyList = new List<string>();
			Variables.ComboQueue = new AsyncQueue<string>();
			Variables.TokenQueue = new AsyncQueue<string>();
			Variables.CPMTimer = new System.Timers.Timer(1000.0);
			Variables.TwoCaptchaSources = new List<CancellationTokenSource>();
			Variables.CapMonsterCloudSources = new List<CancellationTokenSource>();
		}

		// Token: 0x040000C3 RID: 195
		public static readonly string string_0;

		// Token: 0x040000C4 RID: 196
		public static readonly string Version;

		// Token: 0x040000C5 RID: 197
		public static int Checked;

		// Token: 0x040000C6 RID: 198
		public static int PreviousChecked;

		// Token: 0x040000C7 RID: 199
		public static int Remaining;

		// Token: 0x040000C8 RID: 200
		public static int Good;

		// Token: 0x040000C9 RID: 201
		public static int Bad;

		// Token: 0x040000CA RID: 202
		public static int CPM;

		// Token: 0x040000CB RID: 203
		public static int Errors;

		// Token: 0x040000CC RID: 204
		public static int Threads;

		// Token: 0x040000CD RID: 205
		public static int Timeout;

		// Token: 0x040000CE RID: 206
		public static string ProxyType;

		// Token: 0x040000CF RID: 207
		public static string ResultsDirectory;

		// Token: 0x040000D0 RID: 208
		public static readonly object Locker;

		// Token: 0x040000D1 RID: 209
		public static readonly Random Random;

		// Token: 0x040000D2 RID: 210
		public static readonly List<string> ProxyList;

		// Token: 0x040000D3 RID: 211
		public static readonly AsyncQueue<string> ComboQueue;

		// Token: 0x040000D4 RID: 212
		public static readonly AsyncQueue<string> TokenQueue;

		// Token: 0x040000D5 RID: 213
		public static System.Timers.Timer CPMTimer;

		// Token: 0x040000D6 RID: 214
		public static readonly List<CancellationTokenSource> TwoCaptchaSources;

		// Token: 0x040000D7 RID: 215
		public static readonly List<CancellationTokenSource> CapMonsterCloudSources;
	}
}
