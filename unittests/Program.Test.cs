using NUnit.Framework;

class TestSum {
	[Test]
	public void Sum4and4Is8() {
		var result = Tools.Sum(4, 4);
		Assert.AreEqual(8, result);
	}
	[Test]
	public void Sum3and39Is42() {
		var result = Tools.Sum(3, 39);
		Assert.AreEqual(42, result);
	}
}
