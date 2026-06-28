// StudentService.cs — An in-memory "database" for students.
// In a real app you would query a database here, but for learning purposes
// we keep everything in a simple List<Student> stored in memory.
//
// This service is registered as a SCOPED service in Program.cs, which means
// each browser session gets its own instance — data is not shared between users.

using StudentBasics.Models;

namespace StudentBasics.Services;

public class StudentService
{
    // In-memory list that acts as our data store.
    // Pre-populated with sample students so the Student List page is not empty.
    private readonly List<Student> _students =
    [
        new Student { Id = 1, Name = "Alice Johnson",  Age = 20, Grade = "A",  Subject = "Mathematics" },
        new Student { Id = 2, Name = "Bob Smith",      Age = 22, Grade = "B+", Subject = "Physics"      },
        new Student { Id = 3, Name = "Carol White",    Age = 19, Grade = "A-", Subject = "Chemistry"    },
        new Student { Id = 4, Name = "David Brown",    Age = 21, Grade = "B",  Subject = "Biology"      },
        new Student { Id = 5, Name = "Eva Martinez",   Age = 23, Grade = "A+", Subject = "Computer Science" },
    ];

    // Returns a copy of the full student list.
    public List<Student> GetAll() => [.. _students];

    // Adds a new student, auto-assigning the next available ID.
    public void Add(Student student)
    {
        student.Id = _students.Count > 0 ? _students.Max(s => s.Id) + 1 : 1;
        _students.Add(student);
    }

    // Removes a student by ID. Returns true if a student was found and removed.
    public bool Remove(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student is null) return false;
        _students.Remove(student);
        return true;
    }
}
