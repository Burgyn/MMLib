// Guids.cs
// MUST match guids.h
using System;

namespace MinoMartiniak.SearchingShortcut
{
    static class GuidList
    {
        public const string guidSearchingShortcutPkgString = "e2e3f0f9-2dce-47f2-a9a5-c447c6b43da7";
        public const string guidSearchingShortcutCmdSetString = "f9f83702-7fb3-4e84-913c-747381ced034";

        public static readonly Guid guidSearchingShortcutCmdSet = new Guid(guidSearchingShortcutCmdSetString);
    };
}