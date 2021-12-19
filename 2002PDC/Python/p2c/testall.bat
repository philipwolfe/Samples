@echo off
call make suite\test_misc
call make suite\test_builtins
call make suite\test_methods
call make suite\test_exceptions
call make suite\test_signatures
call make suite\com_imports

call make suite\pystone
echo ***** pystone known to fail with verification errors - bug in compiler.
echo *****
echo ***** Running pystone.exe anyway - this may take a while...
suite\pystone.exe

call make suite\test_func
call make suite\test_cor_conversions

echo All tests done!