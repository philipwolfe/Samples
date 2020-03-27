
use Cwd;
$curwd=getcwd();
$startDir=$curwd;
$mydir=$curwd;
$type="GENRUN_TYPE";
$config="GENRUN_CONFIG";
$projname="AutoThread";
$msg;

#get a meaningful and unique log file name and open it for write.
$username=$ENV{USERNAME};
$time=time;
$ver=`ver`;
$ver=~/(Windows)\s+(\w+)\s+/i;
$filename="$2\_$projname\_$config$time.txt";
if ($username){
	$filename ="$username\_$filename";
}
if(-e "\\\\qingboz4\\public"){
	if(! open(RESULT, ">\\\\qingboz4\\public\\$filename")){
		open(RESULT, ">$filename");
	}
}
else {
	open(RESULT, ">$filename");
}


#LOG all evrionment vars.
foreach (keys %ENV)
{
	print RESULT "$_\t$ENV{$_}\n";
}

#figure out the dir this file is located.
if($0 =~ /^(\\\\|\w{1}:\\)(.*)\\run\.pl$/i)
{
	$mydir=$1 . $2;
}
else {
	unless($0 =~ /^run\.pl\s*$/i)
	{
		if($curwd =~ /\\$/){
			chop $curwd;
		}
		$0 =~ /^(.*)\\run\.pl$/i;
		$mydir = $curwd . "\\" . $1;
	}
}

chdir $mydir;
$msg = `del /s *.obj *.dep *.dll *.exe`;
print RESULT "$msg\n";

$type=exe;
$config=Debug;
chdir "$mydir\\AutoServer";

$msg = `nmake /f AutoServer.mak cfg="Win32 $config"`;
print RESULT "$msg\n";
if ($? != 0) {
	print RESULT "$projname failed at making $projname.mak\n";
	goto atexit;
}
chdir "$config";
if($type =~ /dll/i){
	$command = "regsvr32 /c /s AutoServer.dll";
}
elsif ($type =~ /exe/i){
	$command = "AutoServer.exe /regserver";
}
else {
	$command = "AutoServer.exe";
}
$msg = `$command`;
print RESULT "$msg\n";
if ($? != 0) {
	print RESULT "$projname failed at running \"$command\"\n";
	goto atexit;
}


$type=dll;
$config=Release;
chdir "$mydir\\AutoClient";

$msg = `nmake /f AutoClient.mak cfg="Win32 $config"`;
print RESULT "$msg\n";
if ($? != 0) {
	print RESULT "$projname failed at making $projname.mak\n";
	goto atexit;
}
chdir "$config";
if($type =~ /dll/i){
	$command = "regsvr32 /c /s AutoClient.dll";
}
elsif ($type =~ /exe/i){
	$command = "AutoClient.exe /regserver";
}
else {
	$command = "AutoClient.exe";
}
$msg = `$command`;
print RESULT "$msg\n";
if ($? != 0) {
	print RESULT "$projname failed at running \"$command\"\n";
	goto atexit;
}




atexit:
 	close RESULT;
	chdir $startDir;
	if($? == 0){
		exit(0);
	}
	exit(1);
