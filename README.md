# UnoDebug
For debugging Uno issues

Uno is the best framework targeting multiple platforms (Windows, Android, iOS, webt).  It harnesses the power of multiple technologies( UWP, .Net, Xamarin, Mono, WebAssmebly...) and makes app development with IDE king Visual Studio a fun and highly prodctive.  

Current issues (all on iOS):

https://github.com/nventive/Uno/issues/1009 (related to https://github.com/nventive/Uno/pull/1014)

https://github.com/nventive/Uno/issues/1018 



MenuFlyoutItem clicking does not invoke the specified event handler.
https://github.com/nventive/Uno/pull/1064

CreationCollisionOption.ReplaceExisting is treated as CreationCollisionOption.OpenIfExists
https://github.com/nventive/Uno/issues/1067

`OpenStreamForWriteAsync("foo.txt", CreationCollisionOption.ReplaceExisting)` throws
`Exception: System.IO.FileNotFoundException: Could not find file ".../Library/Developer/CoreSimulator/Devices/E86F6ABD-3120-41F6-A850-7527F82D11E2/data/Containers/Data/Application/55ACE83E-F2B2-4F7F-9001-ACA4E03801B2/Library/Data/foo.txt"`
instead of creating the file.
https://github.com/nventive/Uno/issues/1077
