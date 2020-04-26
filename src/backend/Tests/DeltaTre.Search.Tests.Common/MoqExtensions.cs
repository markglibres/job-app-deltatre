using AutoFixture;
using Moq;

namespace DeltaTre.Search.Tests.Common
{
    public static class MoqExtensions
    {
        public static Mock<T> FreezeMoq<T>(this IFixture fixture)
            where T : class
        {
            var td = new Mock<T>();
            fixture.Inject(td.Object);
            return td;
        }
    }
}