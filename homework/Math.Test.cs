using NUnit.Framework;

class MathSumTests {
	[Test]
	public void Sum1And2Is3() {
		var result = Math.Sum(1, 2);
		Assert.AreEqual(3, result);
	}

	[Test]
	public void Sum39And3Is42() {
		var result = Math.Sum(39, 3);
		Assert.AreEqual(42, result);
	}
}
