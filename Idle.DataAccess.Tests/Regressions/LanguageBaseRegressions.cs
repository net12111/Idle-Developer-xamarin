﻿using Idle.DataAccess.Fields;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idle.DataAccess.Tests.Regressions
{
	[TestClass]
	// Every concretion of language base has to override the virtual properties. This is a workeraound. normally we would use abstract base classes
	// but we cannot create tables using abstract types. this regression tests validates that all members which would be astract are overriden now
	public class LanguageBaseRegressions
	{
		[TestMethod]
		public void RegressFor_AllVirtualMethods_ShouldBeOverriden()
		{
			try
			{
				var assembly = typeof(LanguageBase).Assembly;
				var types = assembly.GetTypes();
				var concreteLanguageTypes = types.Where(t => t.IsClass && t.IsSubclassOf(typeof(LanguageBase)));

				var languages = concreteLanguageTypes.Select(t => (LanguageBase)Activator.CreateInstance(t));

				foreach (var lang in languages)
				{
					var name = lang.Name;
					var desc = lang.Description;
					var diff = lang.Difficulty;

					var xpCost = lang.XPCost;
					var xpIncome = lang.XPIncome;
				}
			}
			catch (Exception)
			{
				Assert.Fail("One concretion of 'LanguageBase' did not override virtual members!");
				throw;
			}

		}

	}
}
