using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Zeiterfassungsprogramm;

namespace ZeiterfassungsprogrammTests {

	[TestFixture]
	class TestLernender {

		// Ferien
		[TestCase(35, 40, ExpectedResult =40)]
		[TestCase(20, 45, ExpectedResult =45)]
		[TestCase(50, 20, ExpectedResult =35)]
		public int TestSetFerien(int nA, int nB) {
			//Arrange
			Lernender l = new Lernender("tester","test",16,null,null,nA);
			//Act
			l.SetFerienguthaben(nB);
			//Assert
			return l.GetFerienguthaben();
		}

		// Arbeitsstunden
		[TestCase(5, ExpectedResult =5)]
		[TestCase(15, ExpectedResult =10)]
		public int TestSetArbeitsstunden(int nA) {
			//Arrange
			Lernender l = new Lernender("tester","test",16,null,null);
			//Act
			l.SetArbeitsstunden(nA);
			//Assert
			return l.GetArbeitsstunden();
		}

	}
}
