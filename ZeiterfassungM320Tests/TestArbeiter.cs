using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Zeiterfassungsprogramm;

namespace ZeiterfassungsprogrammTests {

	[TestFixture]
	class TestArbeiter {

		// Ferien
		[Test]
		public void TestSetFerien_Valid() {
			//Arrange
			Arbeiter a = new Arbeiter("tester","test",100,null,null,40);
			//Act
			a.SetFerienguthaben(35);
			//Assert
			Assert.AreEqual(35,a.GetFerienguthaben());
		}

		[Test]
		public void TestSetFerien_Invalid() {
			//Arrange
			Arbeiter a = new Arbeiter("tester","test",100,null,null,30);
			//Act
			a.SetFerienguthaben(0);
			//Assert
			Assert.AreEqual(30,a.GetFerienguthaben());
		}

		// Lohnzuschlag
		[Test]
		public void TestSetLohnzuschlag_Valid() {
			//Arrange
			Arbeiter a = new Arbeiter("tester","test",100,null,null);
			//Act
			a.SetLohnZuschlag(100);
			//Assert
			Assert.AreEqual(100,a.GetLohnZuschlag());
		}

		[Test]
		public void TestSetLohnzuschlag_Invalid() {
			//Arrange
			Arbeiter a = new Arbeiter("tester","test",100,null,null);
			//Act
			a.SetLohnZuschlag(-100);
			//Assert
			Assert.AreEqual(0,a.GetLohnZuschlag());
		}

	}
}
