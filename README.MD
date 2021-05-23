# OptionalType

C# null safe implementation of an Optional type

## Basic How To Use

### Create a Optional

```C#
using System.Optional;

...

var op = Option.Some<string>("value");

op.TryGetValue(out var value); // true, "value"
```

### Use static import to simplify it

```C#
using static System.Optional.Option;

...

string nullStr = null;

var op1 = Some(nullStr);
var op2 = None<string>();

op1.TryGetValue(out string value); // false
op2.TryGetValue(out string value); // false
```

### Supports C# 8 null reference

```C#
string? maybeNull = "my text";

var op = Some(maybeNull);

op.TryGetValue(out string value); // true, "my text"
```

### Is type safe
```C#
object value = 10;
var op = Option.Some(value);

op.ToType<string>.TryGetValue(out int value); // false
op.ToType<int>.TryGetValue(out int value); // true, 10

```


## Helper Methods

### Unsafe value read

```C#
string myValue = null;
var op = Some(myValue);

op.ValueOr("") // returns "" if null
op.ValueOrFail() // Throws an exception when null
```

### Map to other option

```C#
var op = Some(24.2345m);

var newOp = op.Map(
    some: v => (int)Math.Floor(v),
    none: () => 0
); // Option<int>
```