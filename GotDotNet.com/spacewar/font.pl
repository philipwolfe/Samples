open(FILE, "font.dat");

open(CSFILE, ">font.cs");

print CSFILE "class VectorFontData\n{\n";

print CSFILE "\tpublic static float[] Vectors = {\n";

while (<FILE>)
{
	$Letter = substr($_, 0, 1);

	print "Letter: ", $Letter, "\n";
	push(@Chars, $Letter);

	$LastX = 0.0;
	$LastY = 0.0;
	$LineCount = 0;
	while (length($_) > 1)
	{
		print "Line: ", $_;
		if (/(.+),(.+) (.+),(.+)/)
		{
			print CSFILE "\t\t\t".$1."F,".$2."F,".$3."F,".$4."F,\n";
			#print "L$1,$2 to $3,$4\n";
			$LastX = $3;
			$LastY = $4;
		}
		elsif (/L (.+),(.+)/)
		{
			print CSFILE "\t\t\t".$LastX."F,".$LastY."F,".$1."F,".$2."F,\n";
			#print "L$LastX,$LastY to $1,$2\n";
			$LastX = $1;
			$LastY = $2;
		}
		$_ = <FILE>;
		$LineCount++;
	}
	$LineCount--;
	push(@CharVector, $LineCount);

}
close(FILE);

print CSFILE "\t};\n\n";

$Count = scalar(@Chars);
print CSFILE "\tpublic static char[] order = {\n";
foreach $c (@Chars)
{
	print CSFILE "\t\t'$c',\n";
}
print CSFILE "\t};\n\n";

$Count = scalar(@Chars);
print CSFILE "\tpublic static int[] vectorCount = {\n";
foreach $count (@CharVector)
{
	print CSFILE "\t\t$count,\n";
}
print CSFILE "\t};\n";

print CSFILE "}\n";

close(CSFILE);