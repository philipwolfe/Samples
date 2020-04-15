This is a very simple Windows Service application that beeps once
every five seconds. To install this, you have to open a command
prompt in the BeepService\bin directory and type:

    InstallUtil beepservice.exe

Then go into the Services MMC console and start the BeepService.
To uninstall type:

    InstallUtil /u beepservice.exe

from the same directory. It must be stopped before you can uninstall.