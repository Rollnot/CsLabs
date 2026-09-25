namespace tests;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using lab_02;
using NUnit.Framework;

public class Tests
{
    [Test]
    public void CheckConfiguration_ValidConfiguration_ServerIsReady()
    {
        var result = Program.CheckConfiguration(8, 50, true, false);

        Assert.That(result, Is.EqualTo("[INFO] Сервер запущен."));
    }

    [Test]
    public void CheckConfiguration_ZeroPlayers_LaunchIsImpossible()
    {
        var result = Program.CheckConfiguration(8, 0, true, false);

        Assert.That(
            result,
            Is.EqualTo("[ERROR] Количество игроков должно быть больше нуля."));
    }

    [Test]
    public void CheckConfiguration_NotEnoughMemory_LaunchIsImpossible()
    {
        var result = Program.CheckConfiguration(1, 50, true, false);

        Assert.That(
            result,
            Is.EqualTo("[ERROR] Серверу недостаточно оперативной памяти."));
    }

    // [Test]
    // public void CheckConfiguration_PublicServerWithPassword_LaunchWithWarning()
    // {
    //     var result = Program.CheckConfiguration(8, 50, true, true);
// 
//     //     Assert.That(
//     //         result,
//     //         Is.EqualTo("[WARNING] Сервер защищён паролем."));
//     // }
// 
//     // [Test]
//     // public void CheckConfiguration_TooManyPlayersForAvailableMemory_LaunchWithWarning()
//     // {
//     //     var result = Program.CheckConfiguration(4, 32, true, false);
// 
//     //     Assert.That(
    //         result,
    //         Is.EqualTo(
    //             "[WARNING] Для такого количества игроков рекомендуется больше оперативной памяти."));
    // }

    [Test]
    public void CheckConfiguration_InvalidPlayersAndPublicServerWithPassword_LaunchIsImpossible()
    {
        var result = Program.CheckConfiguration(8, 0, true, true);

        Assert.That(
            result,
            Is.EqualTo("[ERROR] Количество игроков должно быть больше нуля."));
    }
}