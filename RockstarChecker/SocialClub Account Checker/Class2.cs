using System;
using System.Reflection;

// Token: 0x02000041 RID: 65
internal class Class2
{
	// Token: 0x06000140 RID: 320 RVA: 0x0000AFE0 File Offset: 0x000091E0
	internal static void OEvSa3ww7Rpkt(int typemdt)
	{
		Type type = Class2.module_0.ResolveType(33554432 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo method = (MethodInfo)Class2.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	// Token: 0x06000141 RID: 321 RVA: 0x00002383 File Offset: 0x00000583
	public Class2()
	{
		Class3.oswSa3wz9mgro();
		base..ctor();
	}

	// Token: 0x06000142 RID: 322 RVA: 0x00002A38 File Offset: 0x00000C38
	static Class2()
	{
		Class3.oswSa3wz9mgro();
		Class2.module_0 = typeof(Class2).Assembly.ManifestModule;
	}

	// Token: 0x040000DB RID: 219
	internal static Module module_0;

	// Token: 0x02000042 RID: 66
	// (Invoke) Token: 0x06000144 RID: 324
	internal delegate void Delegate0(object o);
}
