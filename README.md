# Statistics
A project is .NET library for statitistic calculations. The calculation includes following: arithmetic mean; standard deviation; percentiles; binominal, normal and T Student distributions; correlation.
## Getting Started
The project was created in Visual Studio Community 2015 using .NET Framework 4.0
## Running the tests
A code includes series of unit tests created in Visual Studio.
## Versioning
Release sequence, release time and version number are defined by author. 
## Author
Andriy Shyrokoryadov.
## License
This project is licensed under the MIT License - see the LICENSE.md file for details.
## Hints
### Implementations namespace
A namespace where different types of calcualtions are implemented defined. All classes are derived from StatisticsBase class. Each calcualtion handles decimal, double, float arrays. Most of the calcualtions handles int arrays as well. Internally, a "factory" design pattern has been used.
### Interfaces namespace
A single interface IGetResult is defined here.
### Statistics namespace
Two abstract classes (CalculationBase and StatisticsBase) defined here.
### Details of implementation and adding new calcualtions
Each class to be used in Statistic library derives from StatisticBase class. Each class has a property of CalculationBase type. Each calculation has several implemetations depending on data type. Depending on passed parameters the property of CalculationBase type decides what calculation type to invoke ("factory" design pattern).
### Details of implementation / calcualtion
Where an integral calculaus was required, a Simpson method was used.
### Obsolete methods
Documentation was created one year after the library had been created, that's why I was not sure where and what for certain methods suppose to be used. I marked these methods as obsolete.
