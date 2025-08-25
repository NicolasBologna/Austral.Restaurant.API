namespace Austral.Restaurant.API.Models.Enum;

[Flags]
public enum Label
{
    None = 0,
    Vegan = 1 << 0,
    Vegetarian = 1 << 1,
    GlutenFree = 1 << 2,
    Spicy = 1 << 3,
    SugarFree = 1 << 4,
    Kids = 1 << 5,
    Shareable = 1 << 6
}