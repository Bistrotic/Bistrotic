namespace Fiveforty.Module.Units.Domain.Tests
{
    using System;
    using System.Threading.Tasks;

    using Fiveforty.Domain;
    using Fiveforty.Module.Units.Domain.Events;

    using Moq;

    using Xunit;

    public class UnitTest
    {
        [Theory]
        [InlineData("JohnDoe", "L", "Liter", "Metric unit of capacity equal to one cubic decimeter.")]
        [InlineData("DonaldDuck", "M", "Meter", null)]
        public async Task AddNewUnit(string userName, string id, string name, string? description)
        {
            var unitRepositoryMock = new Mock<IRepository<UnitState>>();
            unitRepositoryMock
                .Verify(p =>
                    p.Save(
                        It.Is<NewUnitAdded>(v =>
                            v.Id == id &&
                            v.Name == name &&
                            v.Description == description &&
                            v.DateTime != DateTime.MinValue &&
                            v.UserName == userName &&
                            !string.IsNullOrEmpty(v.Etag)
                        ),
                        It.Is<UnitState>(v =>
                            v.Id == id &&
                            v.Name == name &&
                            v.Description == description &&
                            v.CreatedDate != DateTime.MinValue &&
                            v.CreatedBy == userName &&
                            !string.IsNullOrEmpty(v.Etag))),
                    Times.Once
                );
            var unitRepository = unitRepositoryMock.Object;
            Unit unit = new Unit(unitRepository);
            await unit.AddNew(userName, id, name, description);
            unitRepositoryMock.Verify();
        }
    }
}