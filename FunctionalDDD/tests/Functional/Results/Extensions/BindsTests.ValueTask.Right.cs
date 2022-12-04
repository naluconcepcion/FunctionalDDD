﻿namespace FunctionalDDD.Tests.ResultTests.Extensions;

public class BindTests_ValueTask_Right : BindTestsBase
{
    [Fact]
    public async ValueTask Bind_ValueTask_Right_T_K_returns_failure_and_does_not_execute_func()
    {
        Result<K> output = await Failure_T().BindAsync(Func_T_ValueTask_Success_K);

        AssertFailure(output);
    }

    [Fact]
    public async ValueTask Bind_ValueTask_Right_T_K_selects_new_result()
    {
        Result<K> output = await Success_T(T.Value).BindAsync(Func_T_ValueTask_Success_K);

        FuncParam.Should().Be(T.Value);
        AssertSuccess(output);
    }

    [Fact]
    public async ValueTask Bind_ValueTask_Right_T_E_selects_new_UnitResult()
    {
        UnitResult output = await Success_T_E().BindAsync(Func_T_ValueTask_UnitResult_E);

        FuncParam.Should().Be(T.Value);
        AssertSuccess(output);
    }

    [Fact]
    public async ValueTask Bind_ValueTask_RightT_E__returns_failure_and_does_not_execute_func()
    {
        UnitResult output = await Failure_T_E().BindAsync(Func_T_ValueTask_UnitResult_E);

        AssertFailure(output);
    }

    [Fact]
    public async ValueTask Bind_ValueTask_Right_E_selects_new_UnitResult()
    {
        UnitResult output = await UnitResult_Success_E().BindAsync(ValueTask_UnitResult_Success_E);

        AssertSuccess(output);
    }

    [Fact]
    public async ValueTask Bind_ValueTask_Right_E_returns_UnitResult_failure_and_does_not_execute_func()
    {
        UnitResult output = await UnitResult_Failure_E().BindAsync(ValueTask_UnitResult_Success_E);

        AssertFailure(output);
    }

    [Fact]
    public async ValueTask Bind_ValueTask_Right_E_selects_new_result()
    {
        UnitResult output = await UnitResult_Success_E().BindAsync(Func_ValueTask_Success_T_E);

        AssertSuccess(output);
    }

    [Fact]
    public async ValueTask Bind_ValueTask_Right_E_returns_failure_and_does_not_execute_func()
    {
        UnitResult output = await UnitResult_Failure_E().BindAsync(Func_ValueTask_Success_T_E);

        AssertFailure(output);
    }
}
