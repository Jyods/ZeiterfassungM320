using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Zeiterfassungsprogramm;

namespace ZeiterfassungsprogrammTests {

	[TestFixture]
	class TestLernender {

		// Ferien
		[Test]
		public void TestSetFerien_Valid() {
			//Arrange
			Lernender l = new Lernender("tester","test",10,null,null,35);
			//Act
			l.SetFerienguthaben(40);
			//Assert
			Assert.AreEqual(40,l.GetFerienguthaben());
		}

		[Test]
		public void TestSetFerien_Invalid() {
			//Arrange
			Lernender l = new Lernender("tester","test",10,null,null,40);
			//Act
			l.SetFerienguthaben(20);
			//Assert
			Assert.AreEqual(40,l.GetFerienguthaben());
		}

		// Arbeitsstunden
		[Test]
		public void TestSetArbeitsstunden_Valid() {
			//Arrange
			Lernender l = new Lernender("tester","test",10,null,null);
			//Act
			l.SetArbeitsstunden(5);
			//Assert
			Assert.AreEqual(5,l.GetArbeitsstunden());
		}

		[Test]
		public void TestSetArbeitsstunden_Invalid() {
			//Arrange
			Lernender l = new Lernender("tester","test",10,null,null);
			//Act
			l.SetArbeitsstunden(15);
			//Assert
			Assert.AreEqual(0,l.GetArbeitsstunden());
		}

	}
}
