using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Kyle Green", "Essay");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment assignment2 = new MathAssignment("Kyle Green", "Long Division", "4", "26-52");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());

        WritingAssignment assignment3 = new WritingAssignment("Kyle Green", "Change Essay", "Who I Am Now");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}