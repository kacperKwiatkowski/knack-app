using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace product.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GenderEnum
{
    Male,
    Female,
    Unisex
}