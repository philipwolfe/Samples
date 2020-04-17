@echo off
net stop WeatherOrblingService
installutil /u bin\WeatherService.exe
