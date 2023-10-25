﻿using OptoMMP6;
using System.CommandLine;

Option<string> hostOption = new(
    name: "--host",
    description: "The IP of the Epic")
{
    IsRequired = true
};
Option<int> durationOption = new(
    name: "--duration",
    description: "How long in milliseconds to maintain the beep")
{
    IsRequired = true
};

RootCommand rootCommand = new(
    "Beep the Sonalert on the learning center of the Epic at the given IP for the given duration."
);
rootCommand.AddOption(hostOption);
rootCommand.AddOption(durationOption);

rootCommand.SetHandler(async (host, duration) =>
{
    int i32Port = 2001;
    int i32TimeoutMs = 1000;
    OptoMMP mmp = new();
    int connectResult = mmp.Open(host, i32Port, OptoMMP.Connection.Tcp, i32TimeoutMs, true);
    int writeResult = mmp.EpicWriteDigitalState(1, 1, true);
    await Task.Delay(duration).ContinueWith(t =>
    {
        mmp.EpicWriteDigitalState(1, 1, false);
    });
},
hostOption, durationOption);

await rootCommand.InvokeAsync(args);