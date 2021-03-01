using System;
using System.Runtime.InteropServices;

namespace SocialClub_Account_Checker
{
	// Token: 0x02000037 RID: 55
	public class RosPatches
	{
		// Token: 0x0600012A RID: 298
		[DllImport("ros-patches.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr check_grand_theft_auto_v(string rosXmlData, out int responseCode);

		// Token: 0x0600012B RID: 299 RVA: 0x00002383 File Offset: 0x00000583
		public RosPatches()
		{
			Class3.oswSa3wz9mgro();
			base..ctor();
		}
	}
}
