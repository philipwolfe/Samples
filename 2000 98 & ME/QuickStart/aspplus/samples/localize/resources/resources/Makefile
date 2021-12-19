.SUFFIXES: .txt .resources

TARGETS= 	articles.resources \
		articles.de.resources \
		articles.en-us.resources \
		articles.ja.resources \

#issuing "nmake" will all resource files
all: $(TARGETS) 

articles.resources: articles.en-us.txt
	resgen articles.en-us.txt articles.resources

clean:
	del /q *.resources

#simple rule to call resgen.exe
.txt.resources:
	resgen $*.txt $*.resources







