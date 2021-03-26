namespace Bistrotic.Application.Abstractions.Tests
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Application.Abstractions.Tests.Fixtures;
    using Bistrotic.Application.Repositories;

    using FluentAssertions;

    public abstract class RepositoryTestBase
    {
        protected NewDummyAdded new1 = new() { Value1 = true, Value2 = 10, Value3 = "Hello" };
        protected NewDummyAdded new2 = new() { Value1 = false, Value2 = 99, Value3 = "Cake" };
        protected NewDummyAdded new3 = new() { Value1 = true, Value2 = 1010, Value3 = "Sunday" };
        protected NewDummyAdded new4 = new() { Value1 = false, Value2 = 10900, Value3 = "June" };
        protected DummyState state1 = new() { Value1 = true, Value2 = 10, Value3 = "Hello" };
        protected DummyState state2 = new() { Value1 = false, Value2 = 99, Value3 = "Cake" };
        protected DummyState state3 = new() { Value1 = true, Value2 = 1010, Value3 = "Sunday" };
        protected DummyState state4 = new() { Value1 = false, Value2 = 10900, Value3 = "June" };

        protected virtual async Task Check_save_state()
        {
            var repository = CreateNewRepository();
            await repository.Save(
                nameof(state1),
                new RepositoryData<DummyState>("cor1", "cause1", "harold", DateTimeOffset.Now, state1)
                );
            await repository.Save(
                nameof(state2),
                new RepositoryData<DummyState>("cor2", "cause2", "jean", DateTimeOffset.Now, state2)
                );
            await repository.Save(
                nameof(state3),
                new RepositoryData<DummyState>("cor3", "cause3", "michel", DateTimeOffset.Now, state3)
                );
            await repository.Save(
                nameof(state4),
                new RepositoryData<DummyState>("cor4", "cause4", "pierre", DateTimeOffset.Now, state4)
                );
            DummyState state = (DummyState)await repository.GetState(typeof(DummyState), nameof(state1));
            state.Value1.Should().Be(state1.Value1);
            state.Value2.Should().Be(state1.Value2);
            state.Value3.Should().Be(state1.Value3);
            state = (DummyState)await repository.GetState(typeof(DummyState), nameof(state2));
            state.Value1.Should().Be(state2.Value1);
            state.Value2.Should().Be(state2.Value2);
            state.Value3.Should().Be(state2.Value3);
            state = (DummyState)await repository.GetState(typeof(DummyState), nameof(state3));
            state.Value1.Should().Be(state3.Value1);
            state.Value2.Should().Be(state3.Value2);
            state.Value3.Should().Be(state3.Value3);
            state = (DummyState)await repository.GetState(typeof(DummyState), nameof(state4));
            state.Value1.Should().Be(state4.Value1);
            state.Value2.Should().Be(state4.Value2);
            state.Value3.Should().Be(state4.Value3);
        }

        protected virtual async Task Check_save_state_to_stream()
        {
            var repository = CreateNewRepository();
            await repository.Save(
                nameof(state1),
                new RepositoryData<DummyState>("cor1", "cause1", "harold", DateTimeOffset.Now, new[] { new1 })
                );

            await repository.Save(
                nameof(state2),
                new RepositoryData<DummyState>("cor2", "cause2", "jean", DateTimeOffset.Now, new[] { new2 })
                );
            await repository.Save(
                nameof(state3),
                new RepositoryData<DummyState>("cor3", "cause3", "michel", DateTimeOffset.Now, new[] { new3 })
                );
            await repository.Save(
                nameof(state4),
                new RepositoryData<DummyState>("cor4", "cause4", "pierre", DateTimeOffset.Now, new[] { new4 })
                );
            DummyState state = (DummyState)await repository.GetState(typeof(DummyState), nameof(state1));
            state.Value1.Should().Be(state1.Value1);
            state.Value2.Should().Be(state1.Value2);
            state.Value3.Should().Be(state1.Value3);
            state = (DummyState)await repository.GetState(typeof(DummyState), nameof(state2));
            state.Value1.Should().Be(state2.Value1);
            state.Value2.Should().Be(state2.Value2);
            state.Value3.Should().Be(state2.Value3);
            state = (DummyState)await repository.GetState(typeof(DummyState), nameof(state3));
            state.Value1.Should().Be(state3.Value1);
            state.Value2.Should().Be(state3.Value2);
            state.Value3.Should().Be(state3.Value3);
            state = (DummyState)await repository.GetState(typeof(DummyState), nameof(state4));
            state.Value1.Should().Be(state4.Value1);
            state.Value2.Should().Be(state4.Value2);
            state.Value3.Should().Be(state4.Value3);
        }

        protected abstract IRepository CreateNewRepository();

        protected virtual Task Save_state_throws_not_supported()
        {
            CreateNewRepository()
                .Invoking(async y => await y.Save(
                    nameof(state1),
                    new RepositoryData<DummyState>("cor1", "cause1", "harold", DateTimeOffset.Now, state1)
                    ))
                    .Should().Throw<NotSupportedException>();
            return Task.CompletedTask;
        }

        protected virtual Task Save_stream_throws_not_supported()
        {
            CreateNewRepository()
                .Invoking(async y => await y.Save(
                    nameof(state1),
                    new RepositoryData<DummyState>("cor1", "cause1", "harold", DateTimeOffset.Now, new[] { new1 })
                    ))
                    .Should().Throw<NotSupportedException>();
            return Task.CompletedTask;
        }
    }
}