﻿using Application.Handlers.AuthenticatePerson;
using AutoFixture;
using Bogus;
using Domain.Interfaces;
using Domain.Validators;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonTest.Application.Validators;

public class CpfValidatorTest : IDisposable
{
    protected readonly Fixture Fixture;
    protected readonly Faker Faker;
    protected readonly CpfValidator CpfValidator;

    public CpfValidatorTest()
    {
        Fixture = new Fixture();
        Faker = new Faker();

        CpfValidator = new CpfValidator();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    [Fact]
    public async Task ValidateCPF_WithInvalid_WhenReturnTrue()
    {
        var result = CpfValidator.Validate("07140933944");

        result.Should().BeTrue();
    }

    [Fact]
    public async Task ValidateCPF_WithValid_WhenReturnFalse()
    {
        var result = CpfValidator.Validate(Faker.Random.AlphaNumeric(10));

        result.Should().BeFalse();
    }
}

