#Using the uScoober TestFramework

1. Create a new NETMF console program.
1. Delete contents provided by template.
1. Add the NuGet package(s)
    1. uScoober.TestFramework (required)
    1. uScoober.TestFramework.LedUI (optional, for blinky feedback)
    1. uScoober.TestFramework.TextUI (optional, for character LCD feedback)
    1. uScoober.TestFramework.GraphicUI (optional, for graphical LCD feedback, displays in emulator)
1. Write your tests as xunit inspired facts and theories.
	1. Tests are instance methods that are found based on a naming convention
	1. For each test method found, the framework will:
		1. construct a new instance of the class (setup)
		1. execute the single test method
            1. Facts are run once
            1. Theories are run once for each available input set
		1. dispose the test class instance (teardown)  
	1. Fact Test:
		1. Are public void methods taking zero arguments
		1. Whose name ends with "_fact" (case insensitive)
	1. Theory Test:
		1. Are method pairs, where one is the data provider and the other is the test
		1. Who share the same root name and end in "_data" and "_theory"
        1. The data provider takes no arguments and returns an IEnumerable
        1. The theory takes one argument (data is cast to this type), and returns void
1. Run your tests and stay green.

TODO:
- [ ] Support Task return types on Facts and Theories
- [ ] Include uFact and uTheory Resharper templates.