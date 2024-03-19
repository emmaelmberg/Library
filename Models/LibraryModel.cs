using System.ComponentModel.DataAnnotations;
namespace Library.Models;

public class LibraryModel {
// Properties
public int Id { get; set; }

[Required]
public string? BookName { get; set; }
}