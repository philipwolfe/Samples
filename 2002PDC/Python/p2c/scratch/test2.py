import string
print "string is", string
print string.zfill("foo", 5)

def foo():
	print a
	if 1:
		a=1
	else:
		a=2

assert 1==1, "Arfe teh same"
assert 1==0, "oops"

class dispatcher:
	def send (self, data):
		return 321
	
class Foo2(dispatcher):
	def initiate_send (self):
		num_sent = dispatcher.send (self, "whatever")
		return num_sent

	def send(self):
		return 0x1

def t():
    o = Foo2()
    print o.initiate_send()
    print o.send()

t()

##def f( (a, (b,c)), d):
##    return a+b+c+d
##
##assert f( (1,(2,3)), 4)==10
##arg = 1,(2,3)
##assert f(arg, 4)==10

##import time
##def glob_func(a,b):
##	return a+b
##
##class Foo:
##	def __init__(self, *args):
##		pass
##	def bar(self):
##		print "self is", self
##		return glob_func(1,2)
##
##class Foo2:
##	def bar(self):
##		print "self is", self
##		return glob_func(1,2)
##
##def t():
##    print Foo().bar()
##    print Foo2().bar()
##
##    args = (1,)
##    fn = lambda a: a
##
##    args_ob = COR.Python.Converters.PyTuple_AsArray(args)
##    return COR.Python.Runtime.PyObject_Call(fn, args_ob, None)
##    
###t()
##
### Some pure-python classes
##class PurePython:
##	def __init__(self, **args): # Will force no COM+ base-class
##		self.args = args
##	def getarg(self, name):
##		return self.args[name]
##
##class PurePythonChild(PurePython):
##	def __init__(self, **args):
##		PurePython.__init__(self, **args)
##
##	def getarg(self, name):
##		return "child " + str(PurePython.getarg(self, name))
##
##def TestPurePython():
##	b = PurePython(hello="hello", number=1)
##	print PurePython.getarg(b, "hello")
##	if b.getarg("hello") != "hello" or b.getarg("number") != 1:
##		raise RuntimeError("Can't get the properties")
##
##	print "Testing child"
##	b = PurePythonChild(hello="hello", number=1)
##	print "class is", b.__class__
##	print "bases are", b.__class__.__bases__, type(b.__class__.__bases__)
##	if b.getarg("hello") != "child hello" or b.getarg("number") != "child 1":
##		raise RuntimeError("Can't get the properties from the child.")
##	print "Pure-python class tests worked."
##	
##TestPurePython()
# XXX - THIS STILL FAILS :-(
##def t():
##    lst = []
##    for i in lst:
##        if 0:
##            raise RuntimeError, "looping over range failed?"
##    else:
##        print "else"
##    for j in lst:
##        break
##    print "for loop tests passed"
##    
##t()
