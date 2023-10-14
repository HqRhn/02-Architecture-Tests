using FluentAssertions;
using NetArchTest.Rules;
using static System.Net.Mime.MediaTypeNames;

namespace ArchitectureTests
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "OrderManagement.Domain";
        private const string ApplicationNamespace = "OrderManagement.Application";
        private const string InfrastructureNamespace = "OrderManagement.Infrastructure";
        private const string PresentationNamespace = "OrderManagementAPI";

        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(OrderManagement.Domain.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
            ApplicationNamespace,
            InfrastructureNamespace,
            PresentationNamespace
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Application_Should_Not_HaveDependencyOn_InfrastructureAndPresentation_Projects()
        {
            // Arrange
            var assembly = typeof(OrderManagement.Application.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
            InfrastructureNamespace,
            PresentationNamespace
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Handlers_Should_Have_DependencyOnDomain()
        {
            // Arrange
            var assembly = typeof(OrderManagement.Application.AssemblyReference).Assembly;

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Handler")
                .Should()
                .HaveDependencyOn(DomainNamespace)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Infrastructure_Should_Not_HaveDependencyOn_PresentationAndApplication_Projects()
        {
            // Arrange
            var assembly = typeof(OrderManagement.Infrastrcture.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
             PresentationNamespace,ApplicationNamespace
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Presentation_Should_Not_HaveDependencyOn_Infrastructure_Projects()
        {
            // Arrange
            var assembly = typeof(OrderManagementAPI.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
            InfrastructureNamespace
            };

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAny(otherProjects)
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void Controllers_Should_HaveDependencyOnMediatR()
        {
            // Arrange
            var assembly = typeof(OrderManagementAPI.AssemblyReference).Assembly;

            // Act
            var testResult = Types
                .InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Controller")
                .Should()
                .HaveDependencyOn("MediatR")
                .GetResult();

            // Assert
            testResult.IsSuccessful.Should().BeTrue();
        }
    }
}
