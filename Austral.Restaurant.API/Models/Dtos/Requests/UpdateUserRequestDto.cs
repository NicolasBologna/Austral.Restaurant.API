namespace Austral.Restaurant.API.Models.Dtos.Requests;

public class UpdateUserRequestDto
{
    public string RestaurantName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}