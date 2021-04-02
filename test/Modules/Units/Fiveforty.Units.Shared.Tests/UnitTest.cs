namespace Bistrotic.Module.Units.Domain.Tests
{
    using System.Linq;

    using Bistrotic.Units.Domain;
    using Bistrotic.Units.Domain.Events;
    using Bistrotic.Units.Domain.ValueTypes;

    using FluentAssertions;

    using Xunit;

    public class UnitTest
    {
        [Theory]
        [InlineData("L", "Liter", "Metric unit of capacity equal to one cubic decimeter.")]
        [InlineData("M", "Meter", null)]
        public void AddNewUnit(string id, string name, string description)
        {
            var events = Unit.AddNew(new UnitId(id), name, description, out Unit unit);
            unit.Should().NotBeNull();
            unit.State.Name.Should().Be(name);
            unit.State.Description.Should().Be(description);
            unit.AggregateId.Should().Be(id);
            events.Should().HaveCount(1);
            var @event = events.First();
            @event.Should().BeOfType<NewUnitAdded>();
            var newUnitAdded = (NewUnitAdded)@event;
            newUnitAdded.Name.Should().Be(name);
            newUnitAdded.Description.Should().Be(description);
            newUnitAdded.Id.Should().Be(new UnitId(id));
        }
    }
}