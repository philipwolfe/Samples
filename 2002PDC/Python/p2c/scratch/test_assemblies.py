# Some domain tests
import COR.System
domain = COR.System.Thread.GetDomain()
print "domain is", domain
ass1 = domain.LoadAssembly("Python.Runtime.dll")
ass = domain.LoadAssembly("test2.dll")
print "assembly is", ass
t = ass.GetType("TestClass")
print "type is", t
i = t()
i.TestMethod("foo")

