using StudentBasics.Models;

namespace StudentBasics.Services;

/// <summary>
/// In-memory data service for managing students.
/// Registered as a Singleton in Program.cs so all components share the same data.
/// In a real app this would talk to a database or API.
/// </summary>
public class StudentService
{
    // Private list — the single source of truth for all student data
    private readonly List<Student> _students = new()
    {
        new Student { Id = 1, FirstName = "Alice",   LastName = "Johnson", Grade = 10, Email = "alice@school.edu",   IsEnrolled = true  },
        new Student { Id = 2, FirstName = "Bob",     LastName = "Smith",   Grade = 11, Email = "bob@school.edu",     IsEnrolled = true  },
        new Student { Id = 3, FirstName = "Carol",   LastName = "Davis",   Grade = 9,  Email = "carol@school.edu",   IsEnrolled = false },
        new Student { Id = 4, FirstName = "David",   LastName = "Wilson",  Grade = 12, Email = "david@school.edu",   IsEnrolled = true  },
        new Student { Id = 5, FirstName = "Eve",     LastName = "Martinez",Grade = 10, Email = "eve@school.edu",     IsEnrolled = true  },
    };

    // Auto-increment ID counter
    private int _nextId = 6;

    /// <summary>Returns a copy of all students.</summary>
    public List<Student> GetAll() => new(_students);

    /// <summary>Returns a single student by ID, or null if not found.</summary>
    public Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

    /// <summary>Adds a new student and assigns a unique ID.</summary>
    public void Add(Student student)
    {
        student.Id = _nextId++;
        _students.Add(student);
    }

    /// <summary>Updates an existing student matched by ID.</summary>
    public void Update(Student student)
    {
        var existing = _students.FirstOrDefault(s => s.Id == student.Id);
        if (existing is null) return;

        existing.FirstName  = student.FirstName;
        existing.LastName   = student.LastName;
        existing.Grade      = student.Grade;
        existing.Email      = student.Email;
        existing.IsEnrolled = student.IsEnrolled;
    }

    /// <summary>Removes a student by ID.</summary>
    public void Delete(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student is not null)
            _students.Remove(student);
    }
}
