using System.Text.Json.Serialization;

namespace product.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DepartmentEnum
{
    Pottery,
    Metal,
    Carpentry,
    Textile,
    Decor,
    Leather
}