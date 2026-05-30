# Checkout-Kata
My solution to the Checkout Kata, in a TDD approach. Implemented in C# (.NET 10.0), using NUnit for testing, and Coverlet for code coverage.

## Code Coverage
Used the following CLI commands to run test coverage:

```bash
dotnet tool install --global dotnet-reportgenerator-globaltool 
dotnet test --collect:"XPlat Code Coverage" --results-directory ./TestResults
reportgenerator -reports:./TestResults/*/coverage.cobertura.xml -targetdir:./TestResults/CoverageReport
```

Here is the current test coverage report:
<img width="1358" height="661" alt="Image" src="https://github.com/user-attachments/assets/84742bf1-e957-4790-a558-16b231f963ad" />