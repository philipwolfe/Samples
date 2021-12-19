##class TestClass:
##    def TestMethod(self, a):
##        return a

##def test():
##    pass
ass = None #= test()
print ass
##print "local result is", TestClass().TestMethod(1)
##import test2
##print "Result is", test2.TestClass().TestMethod(1)

##import COR.System
##domain = COR.System.Thread.GetDomain()
##ass1 = domain.LoadAssembly("TestAssembly.dll")
##print "ass is", ass1
##for mod in ass1.GetModules():
##    print "Have runtime module", mod
##print "domain is", domain
##ass = domain.LoadAssembly("test2")
##for mod in ass.GetModules():
##    print "Have module", mod
##
##t = ass.GetType("TestClass")
##i = t()
##i.TestMethod("Hellp")
##
##import test2
##print "module is", test2
##print "type is ", test2.TestClass
##print "other class instance is", test2.TestClass()
#test2.TestClass().TestMethod("Hi from the other side")