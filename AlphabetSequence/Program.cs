namespace AlphabetSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestAlphabetSequence();
        }
        public static void TestAlphabetSequence()
        {
            // Example usage
            Console.WriteLine("=== Alphabetical Sequence Functions Demo ===\n");

            // Test GetNext
            Console.WriteLine("GetNext Examples:");
            Console.WriteLine($"AAA -> {AlphabetSequence.GetNext("AAA")}"); // AAB
            Console.WriteLine($"AAZ -> {AlphabetSequence.GetNext("AAZ")}"); // ABA
            Console.WriteLine($"AZZ -> {AlphabetSequence.GetNext("AZZ")}"); // BAA
            Console.WriteLine($"ZZZ -> {AlphabetSequence.GetNext("ZZZ")}"); // AAAA
            Console.WriteLine();

            // Test GetPrevious
            Console.WriteLine("GetPrevious Examples:");
            Console.WriteLine($"AAB -> {AlphabetSequence.GetPrevious("AAB")}"); // AAA
            Console.WriteLine($"ABA -> {AlphabetSequence.GetPrevious("ABA")}"); // AAZ
            Console.WriteLine($"BAA -> {AlphabetSequence.GetPrevious("BAA")}"); // AZZ
            Console.WriteLine($"AAAA -> {AlphabetSequence.GetPrevious("AAAA")}"); // ZZZ
            Console.WriteLine();

            // Test Min/Max
            Console.WriteLine("Min/Max Examples:");
            Console.WriteLine($"Min(ABC, ABD) = {AlphabetSequence.GetMinimum("ABC", "ABD")}"); // ABC
            Console.WriteLine($"Max(ABC, ABD) = {AlphabetSequence.GetMaximum("ABC", "ABD")}"); // ABD
            Console.WriteLine($"Min(AA, AAA) = {AlphabetSequence.GetMinimum("AA", "AAA")}"); // AA
            Console.WriteLine();

            // Test First/Last
            Console.WriteLine("First/Last Examples:");
            Console.WriteLine($"First(3) = {AlphabetSequence.GetFirst(3)}"); // AAA
            Console.WriteLine($"Last(3) = {AlphabetSequence.GetLast(3)}"); // ZZZ
            Console.WriteLine();

            // Test Number conversion
            Console.WriteLine("Number Conversion Examples:");
            Console.WriteLine($"ToSequence(0) = {AlphabetSequence.ToSequence(0)}"); // A
            Console.WriteLine($"ToSequence(25) = {AlphabetSequence.ToSequence(25)}"); // Z
            Console.WriteLine($"ToSequence(26) = {AlphabetSequence.ToSequence(26)}"); // AA
            Console.WriteLine($"ToNumber(A) = {AlphabetSequence.ToNumber("A")}"); // 0
            Console.WriteLine($"ToNumber(Z) = {AlphabetSequence.ToNumber("Z")}"); // 25
            Console.WriteLine($"ToNumber(AA) = {AlphabetSequence.ToNumber("AA")}"); // 26
        }
    }
}
