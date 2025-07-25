// SPDX-FileCopyrightText: 2023 Leon Friedrich <60421075+ElectroJr@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 Moony <moony@hellomouse.net>
// SPDX-FileCopyrightText: 2023 Visne <39844191+Visne@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 MilenVolf <63782763+MilenVolf@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Pieter-Jan Briers <pieterjan.briers+git@gmail.com>
// SPDX-FileCopyrightText: 2024 Tadeo <td12233a@gmail.com>
// SPDX-FileCopyrightText: 2024 Tayrtahn <tayrtahn@gmail.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

#nullable enable
using System.Collections.Generic;
using Content.IntegrationTests.Pair;
using Content.Server.Administration.Managers;
using Robust.Shared.Network;
using Robust.Shared.Player;
using Robust.Shared.Toolshed;
using Robust.Shared.Toolshed.Errors;
using Robust.Shared.Toolshed.Syntax;
using Robust.UnitTesting;

namespace Content.IntegrationTests.Tests.Toolshed;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public abstract class ToolshedTest : IInvocationContext
{
    protected TestPair Pair = default!;

    protected virtual bool Connected => false;
    protected virtual bool AssertOnUnexpectedError => true;

    protected RobustIntegrationTest.ServerIntegrationInstance Server = default!;
    protected RobustIntegrationTest.ClientIntegrationInstance? Client = null;
    public ToolshedManager Toolshed { get; private set; } = default!;
    public ToolshedEnvironment Environment => Toolshed.DefaultEnvironment;

    protected IAdminManager AdminManager = default!;

    protected IInvocationContext? InvocationContext = null;

    [TearDown]
    public async Task TearDownInternal()
    {
        await Pair.CleanReturnAsync();
        await TearDown();
    }

    protected virtual Task TearDown()
    {
        Assert.That(_expectedErrors, Is.Empty);
        ClearErrors();

        return Task.CompletedTask;
    }

    [SetUp]
    public virtual async Task Setup()
    {
        Pair = await PoolManager.GetServerClient(new PoolSettings { Connected = Connected });
        Server = Pair.Server;

        if (Connected)
        {
            Client = Pair.Client;
            await Client.WaitIdleAsync();
        }

        await Server.WaitIdleAsync();

        Toolshed = Server.ResolveDependency<ToolshedManager>();
        AdminManager = Server.ResolveDependency<IAdminManager>();
    }

    protected bool InvokeCommand(string command, out object? result, ICommonSession? session = null)
    {
        return Toolshed.InvokeCommand(this, command, null, out result);
    }

    protected T InvokeCommand<T>(string command)
    {
        InvokeCommand(command, out var res);
        Assert.That(res, Is.AssignableTo<T>());
        return (T) res!;
    }

    protected void ParseCommand(string command, Type? inputType = null, Type? expectedType = null)
    {
        var parser = new ParserContext(command, Toolshed);
        var success = CommandRun.TryParse(parser, inputType, expectedType, out _);

        if (parser.Error is not null)
            ReportError(parser.Error);

        if (parser.Error is null)
            Assert.That(success, $"Parse failed despite no error being reported. Parsed {command}");
    }

    public bool CheckInvokable(CommandSpec command, out IConError? error)
    {
        if (InvocationContext is not null)
        {
            return InvocationContext.CheckInvokable(command, out error);
        }

        error = null;
        return true;
    }

    protected ICommonSession? InvocationSession { get; set; }
    public NetUserId? User => Session?.UserId;

    public ICommonSession? Session
    {
        get
        {
            if (InvocationContext is not null)
            {
                return InvocationContext.Session;
            }

            return InvocationSession;
        }
    }

    public void WriteLine(string line)
    {
        return;
    }

    private Queue<Type> _expectedErrors = new();

    private List<IConError> _errors = new();

    public void ReportError(IConError err)
    {
        if (_expectedErrors.Count == 0)
        {
            if (AssertOnUnexpectedError)
            {
                Assert.Fail($"Got an error, {err.GetType()}, when none was expected.\n{err.Describe()}");
            }

            goto done;
        }

        var ty = _expectedErrors.Dequeue();

        if (AssertOnUnexpectedError)
        {
            Assert.That(
                    err.GetType().IsAssignableTo(ty),
                    $"The error {err.GetType()} wasn't assignable to the expected type {ty}.\n{err.Describe()}"
                );
        }

    done:
        _errors.Add(err);
    }

    public IEnumerable<IConError> GetErrors()
    {
        return _errors;
    }

    public bool HasErrors => _errors.Count > 0;

    public void ClearErrors()
    {
        _errors.Clear();
    }

    public object? ReadVar(string name)
    {
        return Variables.GetValueOrDefault(name);
    }

    public void WriteVar(string name, object? value)
    {
        Variables[name] = value;
    }

    public IEnumerable<string> GetVars()
    {
        return Variables.Keys;
    }

    public Dictionary<string, object?> Variables { get; } = new();

    protected void ExpectError(Type err)
    {
        _expectedErrors.Enqueue(err);
    }

    protected void ExpectError<T>()
    {
        _expectedErrors.Enqueue(typeof(T));
    }
}
