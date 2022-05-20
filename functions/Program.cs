// static int Power(int @base, int exponent) {
// 	var power = 1;
// 	if (exponent < 0) {
// 		throw new NegativeExponent("exponent must be positive");
// 	}
// 	for (int i = 0; i < exponent; ++i) {
// 		power *= @base;
// 	}
// 	return power;
// }

// var result = Power(4, -1);
// Console.WriteLine($"4 ^ 5 = {result}");


// class NegativeExponent : Exception {
// 	public NegativeExponent(string msg) : base(msg) { }
// }


var people = new List<Person>();

AddPerson(people, 42, "Hugo");
AddPerson(people, 33, "Henriette");

foreach (var person in people) {
	Console.WriteLine(person.name);
	Console.WriteLine(person.age);
}

static void AddPerson(List<Person> personList, int age, string name) {
	var person = new Person {
		name = name,
		age = age,
	};
	// var person = new Person();
	// person.age = age;
	// person.name = name;
	personList.Add(person);
}

struct Person {
	public string name;
	public int age;
}
