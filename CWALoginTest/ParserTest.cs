﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleWebAppLogin;
using System.Drawing;

namespace CWALoginTest
{
	[TestClass]
	public class ParserTest
	{
		public static CommandLineOptions options = new CommandLineOptions()
		{
			Name = "TestApp",
			URL = "https://google.nl",
			Username = "TestUser",
			Password = "Password",
			UsernameFieldName = "TestUField",
			PasswordFieldName = "TestPField",
			IconPath = "test.ico"
		};

		[TestMethod]
		public void TestValidInput()
		{
			DataModel data = ParseInput.Parse(options);
			Assert.AreEqual(data.AppName, "TestApp");
			Assert.AreEqual(data.Url, "https://google.nl");
			Assert.AreEqual(data.Username, "TestUser");
			Assert.AreNotEqual(data.Password, "Password");
			Assert.AreEqual(options.Password, "");
			Assert.AreEqual(ConvertSecureString.ToUnsecureString(data.Password), "Password");
			Assert.AreEqual(data.UserFieldName, "TestUField");
			Assert.AreEqual(data.PasswordFieldName, "TestPField");
			Assert.AreEqual(data.Icon.GetType(), typeof(Icon));
		}

		[TestMethod]
		[ExpectedException(typeof(System.IO.FileNotFoundException))]
		public void TestInvalidIconPath()
		{
			options.IconPath = "C:\\somefiles.ico";
			ParseInput.Parse(options);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestInvalidIconFileType()
		{
			options.IconPath = "C:\\somefile.png";
			ParseInput.Parse(options);
		}

		[TestMethod]
		[ExpectedException(typeof(UriFormatException))]
		public void TestInvalidUrl()
		{
			options.URL = "www.google.nl";
			ParseInput.Parse(options);
		}
	}
}
