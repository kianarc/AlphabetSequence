# AlphabetSequence Library

A C# .NET 8 library for working with alphabetical sequences like "AAA", "AAB", "AAC", etc. Perfect for scenarios where you need Excel-like column naming, sequence generation, or alphabetical progression instead of numeric counters.

## Features

- ✅ Generate next/previous alphabetical sequences
- ✅ Variable length support (user-defined character count)
- ✅ Automatic length expansion/reduction
- ✅ Min/Max comparison operations
- ✅ Number to alphabet conversion and vice versa
- ✅ Input validation and error handling
- ✅ Zero dependencies
- ✅ .NET 8 compatible

## Installation

### Option 1: Copy the Class
Simply copy the `AlphabetSequence.cs` file into your project.

### Option 2: Clone Repository
```bash
git clone https://github.com/yourusername/alphabet-sequence.git
```

## Quick Start

```csharp
using System;

// Get the next sequence
string next = AlphabetSequence.GetNext("AAA");  // Returns "AAB"

// Get the previous sequence
string prev = AlphabetSequence.GetPrevious("AAB");  // Returns "AAA"

// Find minimum and maximum
string min = AlphabetSequence.GetMinimum("ABC", "ABD");  // Returns "ABC"
string max = AlphabetSequence.GetMaximum("ABC", "ABD");  // Returns "ABD"

// Create sequences of specific length
string first = AlphabetSequence.GetFirst(3);  // Returns "AAA"
string last = AlphabetSequence.GetLast(3);   // Returns "ZZZ"
```

## API Reference

### Core Functions

#### `GetNext(string current)`
Returns the next alphabetical sequence.

```csharp
AlphabetSequence.GetNext("AAA");  // "AAB"
AlphabetSequence.GetNext("AAZ");  // "ABA"
AlphabetSequence.GetNext("AZZ");  // "BAA"
AlphabetSequence.GetNext("ZZZ");  // "AAAA" (auto-expands length)
```

#### `GetPrevious(string current)`
Returns the previous alphabetical sequence.

```csharp
AlphabetSequence.GetPrevious("AAB");   // "AAA"
AlphabetSequence.GetPrevious("ABA");   // "AAZ"
AlphabetSequence.GetPrevious("BAA");   // "AZZ"
AlphabetSequence.GetPrevious("AAAA");  // "ZZZ" (auto-reduces length)
```

**Note:** Cannot get previous of "A" (throws exception).

#### `GetMinimum(string first, string second)`
Returns the lexicographically smaller sequence.

```csharp
AlphabetSequence.GetMinimum("ABC", "ABD");  // "ABC"
AlphabetSequence.GetMinimum("AA", "AAA");   // "AA"
AlphabetSequence.GetMinimum("Z", "AA");     // "AA"
```

#### `GetMaximum(string first, string second)`
Returns the lexicographically larger sequence.

```csharp
AlphabetSequence.GetMaximum("ABC", "ABD");  // "ABD"
AlphabetSequence.GetMaximum("AA", "AAA");   // "AAA"
AlphabetSequence.GetMaximum("Z", "AA");     // "Z"
```

### Utility Functions

#### `GetFirst(int length)`
Creates the first sequence of specified length.

```csharp
AlphabetSequence.GetFirst(1);  // "A"
AlphabetSequence.GetFirst(3);  // "AAA"
AlphabetSequence.GetFirst(5);  // "AAAAA"
```

#### `GetLast(int length)`
Creates the last sequence of specified length.

```csharp
AlphabetSequence.GetLast(1);  // "Z"
AlphabetSequence.GetLast(3);  // "ZZZ"
AlphabetSequence.GetLast(5);  // "ZZZZZ"
```

#### `FromNumber(long number)`
Converts a number to alphabetical sequence (0-based indexing).

```csharp
AlphabetSequence.FromNumber(0);   // "A"
AlphabetSequence.FromNumber(25);  // "Z"
AlphabetSequence.FromNumber(26);  // "AA"
AlphabetSequence.FromNumber(701); // "ZZ"
AlphabetSequence.FromNumber(702); // "AAA"
```

#### `ToNumber(string sequence)`
Converts alphabetical sequence to its numeric equivalent (0-based).

```csharp
AlphabetSequence.ToNumber("A");   // 0
AlphabetSequence.ToNumber("Z");   // 25
AlphabetSequence.ToNumber("AA");  // 26
AlphabetSequence.ToNumber("ZZ");  // 701
AlphabetSequence.ToNumber("AAA"); // 702
```

## Usage Examples

### Excel Column Naming
```csharp
// Generate Excel-like column names
for (int i = 0; i < 30; i++)
{
    Console.WriteLine($"Column {i}: {AlphabetSequence.FromNumber(i)}");
}
// Output: A, B, C, ..., Z, AA, AB, AC, AD
```

### Sequence Iteration
```csharp
string current = "AAA";
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(current);
    current = AlphabetSequence.GetNext(current);
}
// Output: AAA, AAB, AAC, AAD, AAE, AAF, AAG, AAH, AAI, AAJ
```

### Range Operations
```csharp
string start = "AAA";
string end = "AAZ";
string current = start;

while (string.Compare(current, end) <= 0)
{
    Console.WriteLine(current);
    if (current == end) break;
    current = AlphabetSequence.GetNext(current);
}
```

### Custom Length Sequences
```csharp
// Work with 5-character sequences
string seq = AlphabetSequence.GetFirst(5);  // "AAAAA"
seq = AlphabetSequence.GetNext(seq);        // "AAAAB"
seq = AlphabetSequence.GetNext(seq);        // "AAAAC"
```

## Error Handling

The library provides comprehensive error handling:

```csharp
try
{
    // This will throw ArgumentException
    AlphabetSequence.GetNext("123");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); // "Input must contain only uppercase letters A-Z"
}

try
{
    // This will throw ArgumentException
    AlphabetSequence.GetPrevious("A");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); // "Cannot get previous of 'A'"
}
```

### Common Exceptions
- `ArgumentException`: Invalid input (null, empty, or contains non-alphabetic characters)
- `ArgumentException`: Attempting to get previous of "A"
- `ArgumentException`: Invalid length (≤ 0) for GetFirst/GetLast

## Performance Considerations

- **Memory Efficient**: Uses minimal memory allocation
- **String Operations**: Optimized for string manipulation
- **No External Dependencies**: Zero overhead from external libraries
- **Thread Safe**: All methods are static and thread-safe

## Technical Details

### How It Works
The library treats alphabetical sequences as a base-26 numbering system:
- A = 0, B = 1, ..., Z = 25
- AA = 26, AB = 27, ..., AZ = 51
- BA = 52, BB = 53, ..., ZZ = 701
- AAA = 702, AAB = 703, and so on...

### Lexicographical Ordering
Sequences are compared lexicographically, meaning:
- Shorter sequences come before longer ones: "Z" < "AA"
- Same length sequences are compared character by character: "AB" < "AC"

## Requirements

- .NET 7.0 or higher
- No external dependencies

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Changelog

### v1.0.0
- Initial release
- Core functionality for next/previous sequences
- Min/max comparison operations
- Number conversion utilities
- Comprehensive error handling

## Support

If you encounter any issues or have questions:
1. Check the [Issues](https://github.com/yourusername/alphabet-sequence/issues) page
2. Create a new issue if your problem isn't already reported
3. Provide a clear description and code example

## Roadmap

- [ ] Support for lowercase sequences
- [ ] Custom alphabet support (beyond A-Z)
- [ ] Performance optimizations for very long sequences
- [ ] NuGet package distribution
- [ ] Benchmark suite

---

⭐ **Star this repository if you find it useful!**
