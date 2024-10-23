![GitHub Tag](https://img.shields.io/github/v/tag/TJC-Tools/TJC.Priority)
[![GitHub Release](https://img.shields.io/github/v/release/TJC-Tools/TJC.Priority)](https://github.com/TJC-Tools/TJC.Priority/releases/latest)
[![NuGet Version](https://img.shields.io/nuget/v/TJC.Priority)](https://www.nuget.org/packages/TJC.Priority)

[![NuGet Downloads](https://img.shields.io/nuget/dt/TJC.Priority)](https://www.nuget.org/packages/TJC.Priority)
![Size](https://img.shields.io/github/repo-size/TJC-Tools/TJC.Priority)
[![License](https://img.shields.io/github/license/TJC-Tools/TJC.Priority.svg)](LICENSE)

[![codecov](https://codecov.io/gh/TJC-Tools/TJC.Priority/graph/badge.svg?token=O4IL178PR6)](https://codecov.io/gh/TJC-Tools/TJC.Priority)

The [Priority](TJC.Priority/Priority.cs) class is used to create prioritization of items in a list.

### Examples
#### Example - Prioritizing items
```csharp
var priority1 = new Priority();
var priority2 = new Priority();
var priority3 = new Priority();

priority1.Then(priority2).Then(priority3); // 1, 2, 3
priority3.Before(priority1); // 3, 1, 2
priority2.After(priority3); // 3, 2, 1
priority1.Remove(); // 3, 2
```

#### Example - Getting a list of items in priority order
```csharp
void List<T> GetPriorities<T>(List<T> items)
{
	return items.OrderBy(x => x.Priority).ToList();
}
```
