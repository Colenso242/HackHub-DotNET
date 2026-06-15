using HackHub_DotNET.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HackHub_DotNET.Infrastructure.Persistence.Converters;

// Stores the Url value object as its underlying string, re-validating on read.
public sealed class UrlConverter() : ValueConverter<Url, string>(
    url => url.Value,
    value => new Url(value));
