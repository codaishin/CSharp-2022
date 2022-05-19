static int Power(int @base, int exponent) {
	var power = 1;
	if (exponent < 0) {
		throw new NegativeExponent("exponent must be positive");
	}
	for (int i = 0; i < exponent; ++i) {
		power *= @base;
	}
	return power;
}

var result = Power(4, -1);
Console.WriteLine($"4 ^ 5 = {result}");


class NegativeExponent : Exception {
	public NegativeExponent(string msg) : base(msg) { }
}
