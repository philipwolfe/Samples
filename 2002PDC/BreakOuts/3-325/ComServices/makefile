!IF "$(OS)" == "Windows_NT"
NULL=
!ELSE 
NULL=nul
!ENDIF 

common=common
output=output
csharpbank=csharpbank
vb7bank=vb7bank


all: $(output) $(output)\csharpbank.dll $(output)\vb7bank.dll
	al /i:$(output)\adodb.dll
	al /i:$(output)\account.dll
	al /i:$(output)\vb7bank.dll
	al /i:$(output)\csharpbank.dll
	RegSvcs $(output)\vb7bank.dll BankApp
	RegSvcs $(output)\csharpbank.dll BankApp

$(output):
    if not exist "$(output)/$(NULL)" mkdir "$(output)"

$(common)\testkey.snk:
  sn -k $(common)\testkey.snk

$(output)\adodb.dll:	$(common)\testkey.snk 
	tlbimp $(common)\msado15.dll /keyfile:$(common)\testkey.snk /out:$(output)\adodb.dll

$(output)\account.dll:	$(common)\testkey.snk $(common)\accountcom.dll
	regsvr32 /s $(common)\accountcom.dll
	tlbimp $(common)\accountcom.dll /keyfile:$(common)\testkey.snk /out:$(output)\account.dll


$(output)\CSharpBank.dll:	\
				$(common)\testkey.snk \
				$(output)\adodb.dll  \
				$(output)\account.dll \
				$(csharpbank)\Account.cs  \
				$(csharpbank)\MoveMoney.cs \
				$(csharpbank)\GetReceipt.cs \
				$(csharpbank)\UpdateReceipt.cs \
				$(csharpbank)\CreateTable.cs
	csc /a.keyfile:$(common)\Testkey.snk /t:library /out:$(output)\csharpbank.dll $(csharpbank)\*.cs /r:$(output)\adodb.dll /r:$(output)\account.dll /r:Microsoft.ComServices.dll 

$(output)\vb7bank.dll:		\
				$(common)\testkey.snk \
				$(output)\adodb.dll  \
				$(output)\account.dll \
				$(vb7bank)\account.vb	\
				$(vb7bank)\movemoney.vb \
				$(vb7bank)\getreceipt.vb \
				$(vb7bank)\updatereceipt.vb \
				$(vb7bank)\createtable.vb
	vbc /a.keyfile:$(common)\Testkey.snk /t:library /out:$(output)\vb7bank.dll $(vb7bank)\*.vb /r:$(output)\adodb.dll /r:$(output)\account.dll /r:$(output)\csharpbank.dll /r:Microsoft.ComServices.dll


