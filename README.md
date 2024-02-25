# Flaresolverr Windows Service
It will work right out of the box as long as the `flaresolverr` folder resides in the system drive directory `e.g. c:/flaresolverr`.  The service will set the hostname environment variable to `127.0.0.1` so apps like Jackett can interact with it `e.g. http://127.0.0.1:8191`. Alternatively, you can modify the commands from the source code to your liking and rebuild the solution.

Instructions to install this service: <br>
1.) Open cmd with administrative privileges <br>
2.) `cd C:\Windows\Microsoft.NET\Framework64\[latest folder version]` (32-bit version is in the `..\Framework\..` folder) <br>
3.) `InstallUtil.exe [service exe path]` `e.g. C:\flaresolverr\service\FlaresolverrService.exe` <be>
