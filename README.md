# CLSS.ExtensionMethods.IDictionary.RemoveAndProcess

### Problem

It's common to find situations where removing an object from a collection means you also want to do something with it, such as disposing of it. In a barebone .NET application, you can count on the .NET Garbage Collector to clean up the removed object, but in many domains, disposing of an unused object requires an additional manual call, as the framework still keep references to it. These 2 operations are each done in a separate line of code and therefore not very friendly to a functional syntax.

```csharp
var NumberSpellings = new Dictionary<int, string>();
Hide(NumberSpellings[4]);
NumberSpellings.Remove(4);
```

### Solution

`RemoveAndProcess` is an extension method for all `IDictionary<TKey, TValue>` types that combines these 2 steps into 1 method.

```csharp
using CLSS;

var NumberSpellings = new Dictionary<int, string>();
NumberSpellings.RemoveAndProcess(4, Hide);
// using a lambda expression
NumberSpellings.RemoveAndProcess(4, str => { PlayFadeAnimation(str); AddScore(str); });
```

`RemoveAndProcess` takes the value associated with the key specified by the first argument, removes the key from the source collection and passes that value to the delegate in the second argument.

Non-void methods are also accepted as the second argument.

```csharp
using CLSS;

bool TryDispose(ResourceHandler handler) { ... };

var FileResourceMappings = new Dictionary<int, ResourceHandler>();
FileResourceMappings.RemoveAndProcess(4, TryDispose);
```

`RemoveAndProcess` returns the source `IDictionary<TKey, TValue>` to be friendly to a functional-style call chain. The exact return type will be determined by the invocation syntax of `RemoveAndProcess`. With an implicit type invocation, it returns an `IDictionary<TKey, TValue>`. With an explicit type invocation, it returns the original collection type.

```csharp
using CLSS;

var NumberSpellings = new Dictionary<int, string>();
NumberSpellings.RemoveAndProcess(2, str => { ... }); // returns IDictionary<int, string>
NumberSpellings.RemoveAndProcess<Dictionary<int, string>, int, string>(2,
  str => { ... }); // returns Dictionary<int, string>
```

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).