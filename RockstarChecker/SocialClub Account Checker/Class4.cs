using System;
using System.Reflection;
using System.Windows.Forms;

// Token: 0x02000044 RID: 68
internal static class Class4
{
	// Token: 0x06000149 RID: 329 RVA: 0x00002A59 File Offset: 0x00000C59
	internal static string N3YSa384AUIPG(Assembly assembly)
	{
		if (assembly == typeof(Class4).Assembly)
		{
			return Application.ExecutablePath;
		}
		return assembly.Location;
	}
}
