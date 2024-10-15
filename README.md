<a href="https://github.com/TJC-Tools/TJC.Priority/tags">
  <img alt="GitHub Tag" src="https://img.shields.io/github/v/tag/TJC-Tools/TJC.Priority?style=for-the-badge&logo=tag&logoColor=white&labelColor=24292f&color=blue" />
</a>

<a href="https://github.com/TJC-Tools/TJC.Priority/releases/latest">
  <img alt="GitHub Release" src="https://img.shields.io/github/v/release/TJC-Tools/TJC.Priority?style=for-the-badge&logo=starship&logoColor=D9E0EE&labelColor=302D41&&color=green&include_prerelease&sort=semver" />
</a>

<a href="https://www.nuget.org/packages/TJC.Priority">
  <img alt="NuGet Version" src="https://img.shields.io/nuget/v/TJC.Priority?style=for-the-badge&logo=nuget&logoColor=white&labelColor=004880&color=blue" />
</a>

<br/>

<a href="https://www.nuget.org/packages/TJC.Priority">
  <img alt="NuGet Downloads" src="https://img.shields.io/nuget/dt/TJC.Priority?style=for-the-badge&logo=nuget&logoColor=white&labelColor=004880&color=yellow" />
</a>

<a href="https://github.com/TJC-Tools/TJC.Priority">
  <img alt="Repository Size" src="https://img.shields.io/github/repo-size/TJC-Tools/TJC.Priority?style=for-the-badge&logo=files&logoColor=white&labelColor=24292f&color=orange" />
</a>

<br/>

<a href="https://www.nuget.org/packages/TJC.Priority">
  <img alt="Last commit" src="https://img.shields.io/github/last-commit/TJC-Tools/TJC.Priority?style=for-the-badge&logo=git&logoColor=D9E0EE&labelColor=302D41&color=mediumpurple"/>
</a>

<a href="LICENSE">
  <img alt="License" src="https://img.shields.io/github/license/TJC-Tools/TJC.Priority.svg?style=for-the-badge&logo=balance-scale&logoColor=white&labelColor=333333&color=blueviolet" />
</a>

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
