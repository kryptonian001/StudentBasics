using System.ComponentModel.DataAnnotations;

namespace StudentBasics.Models;

/// <summary>
/// Represents a student in the system.
/// Data annotations are used by Blazor's EditForm for validation.
/// </summary>
public class Student
{
    // Unique identifier for each student
    public int Id { get; set; }

    // [Required] means the field cannot be empty — Blazor's validator will enforce this
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
    public string LastName { get; set; } = string.Empty;

    // [Range] restricts the value to a specific numeric range
    [Range(1, 12, ErrorMessage = "Grade must be between 1 and 12.")]
    public int Grade { get; set; } = 1;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    // Whether the student is currently enrolled (used for conditional rendering)
    public bool IsEnrolled { get; set; } = true;

    // Computed property: full name used throughout the UI
    public string FullName => $"{FirstName} {LastName}";
}
