﻿import { dotnet } from './dotnet.js'

const isBrowser = typeof window != 'undefined';
if (!isBrowser) {
    throw new Error(`Expected to be running in a browser`);
}

const dotnetRuntime = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

const config = dotnetRuntime.getConfig();

await dotnetRuntime.runMainAndExit(config.mainAssemblyName, [window.location.search]);