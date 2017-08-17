using System;
using System.Runtime.InteropServices;
using System.Security;

namespace ConsoleWebAppLogin
{
	public static class ConvertSecureString
	{
		/// <summary>
		/// Zet een normale string om naar een "SecureString"
		/// </summary>
		/// <param name="unsecureString">Waarde van de noramle string</param>
		/// <returns>Een "SecureString"</returns>
		public static SecureString ToSecureString(string unsecureString)
		{
			SecureString secureString = new SecureString();
			foreach (char c in unsecureString)
			{
				secureString.AppendChar(c);
			}
			return secureString;
		}

		/// <summary>
		/// Zet een "SecureString" om naar een normale string
		/// </summary>
		/// <param name="secureString">De "SecureString" die teruggezet moet worden</param>
		/// <returns>Een normale string</returns>
		public static string ToUnsecureString(SecureString secureString)
		{
			IntPtr unmanagedString = IntPtr.Zero;
			try
			{
				unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
				return Marshal.PtrToStringUni(unmanagedString);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
			}
		}
	}
}
