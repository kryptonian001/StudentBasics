// Student.cs — Defines the Student data model used throughout the app.
// A model is a plain C# class that represents the shape of our data.

namespace StudentBasics.Models;

public class Student
{
    // Each student gets a unique ID (assigned by the service, not by the user).
    public int Id { get; set; }

    // Name is required — we enforce this in the form with validation.
    public string Name { get; set; } = string.Empty;

    // Age must be between 5 and 100 — validated in the Add Student form.
    public int Age { get; set; }

    // Letter grade, e.g. "A", "B+", "C".
    public string Grade { get; set; } = string.Empty;

    // The student's main subject of study.
    public string Subject { get; set; } = string.Empty;
}
