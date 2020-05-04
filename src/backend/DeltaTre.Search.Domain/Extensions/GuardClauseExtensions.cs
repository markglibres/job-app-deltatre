using System;
using System.Reflection;
using System.Globalization;
using Ardalis.GuardClauses;
using DeltaTre.Search.Domain.Seedwork;

namespace DeltaTre.Search.Domain.Extensions
{
    public static class GuardClauseExtensions
    {
        public static void Empty<T>(this IGuardClause guardClause, string input, string parameterName)
            where T: DomainException
        {
            if (!string.IsNullOrWhiteSpace(input)) return;

            var message = $"{parameterName} cannot be null or empty";
            ThrowError<T>(message);
        }

        public static void Empty<T>(this IGuardClause guardClause, Guid input, string parameterName)
            where T : DomainException
        {
            if (!Guid.Empty.Equals(input)) return;

            var message = $"{parameterName} cannot be an empty GUID";
            ThrowError<T>(message);
        }

        private static void ThrowError<T>(string message)
            where T : DomainException
        {
            throw
            //this was throwing the following expction because of the optional parameters you have in WordsException:
            // System.MissingMethodException: Constructor on type 'DeltaTre.Search.Domain.Words.WordsException' not found.
            //(T)Activator.CreateInstance(typeof(T), new object[] { message });
            (T)Activator.CreateInstance(typeof(T),
                BindingFlags.CreateInstance |
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.OptionalParamBinding, null, new object[] { message, Type.Missing, Type.Missing , Type.Missing }, CultureInfo.CurrentCulture);
        }
    }
}
