# Service Locator

This Service Locator Allows you to resolve dependencies on small projects for rapid prototyping

## Installation
- You can add this package in Unity Package Manager by GIT URL (recommended) https://github.com/dizikkk/ServiceLocator.git
- Also you can download .unitypackage file from Releases

## How to use
Interface `IServiceLocator` has 2 methods:
````c#
public interface IServiceLocator
{
  public void Add<T>(T obj);
  public T Get<T>();
}
````
Also we have implementation of `IServiceLocator` - `ServiceLocator`. You can use this class like singleton by `Instance`.

## Demo
````C#
ISomeService someService = new ISomeService(); // Mock service
ServiceLocator.Instance.Add(someService); // Add SomeService into Service Locator

ISomeService service = ServiceLocator.Instance.Get<ISomeService>(); // Get SomeService from Service Locator
````
