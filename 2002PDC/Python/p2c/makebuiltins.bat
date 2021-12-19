@echo off
gencode /dll /v /w:9 /assembly-keyfile:Python.Builtins.Builtins.key /o:Python.Builtins.Builtins.dll builtins.py \src\python-cvs\lib\string.py /module-name:time builtin_time.py
if not exist Python.Builtins.Builtins.dll goto xit
peverify /IL Python.Builtins.Builtins.dll
if errorlevel 1 goto xit
al -i:Python.Builtins.Builtins.dll
:xit
