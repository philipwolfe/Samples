/* ©2000 Microsoft Corporation
 * REPORT.C:
 * In this program, calls are made to the _CrtSetReportMode,
 * _CrtSetReportFile, and _CrtSetReportHook functions.
 * The _ASSERT macros are called to evaluate their expression.
 * When the condition fails, these macros print a diagnostic message
 * and call _CrtDbgReport to generate a debug report and the
 * client-defined reporting function is called as well.
 * The _RPTn and _RPTFn group of macros are also exercised in
 * this program, as an alternative to the printf function.
 * When these macros are called, the client-defined reporting function
 * takes care of all the reporting - _CrtDbgReport won't be called.
 */

#include <stdio.h>
#include <string.h>
#include <malloc.h>
#include <crtdbg.h>

#ifndef STDOUT
#define STDOUT stdout
#endif

#ifndef FALSE
#define FALSE 0
#endif

#ifndef TRUE
#define TRUE 1
#endif


/* 
 * Define our own reporting function.
 * We'll hook it into the debug reporting
 * process later using _CrtSetReportHook.
 *
 * Define a global int to keep track of
 * how many assertion failures occur.
 */
int gl_num_asserts=0;
int OurReportingFunction( int reportType, char *userMessage, int *retVal )
{
   /*
    * Tell the user our reporting function is being called.
    * In other words - verify that the hook routine worked.
    */
   fprintf(STDOUT,"Inside the client-defined reporting function.\n" );
   fflush(STDOUT);

   /*
    * When the report type is for an ASSERT,
    * we'll report some information, but we also
    * want _CrtDbgReport to get called - 
    * so we'll return TRUE.
    *
    * When the report type is a WARNing or ERROR,
    * we'll take care of all of the reporting. We don't
    * want _CrtDbgReport to get called - 
    * so we'll return FALSE.
    */
   if (reportType == _CRT_ASSERT)
   {
      gl_num_asserts++;
      fprintf(STDOUT ,"This is the number of Assertion failures that have occurred: %d \n", gl_num_asserts);
      fflush(STDOUT);
      fprintf(STDOUT,"Returning TRUE from the client-defined reporting function.\n");
      fflush(STDOUT);
      return(TRUE);
   } else {
      fprintf(STDOUT ,"This is the debug user message: %s \n", userMessage);
      fflush(STDOUT);
      fprintf(STDOUT ,"Returning FALSE from the client-defined reporting function.\n");
      fflush(STDOUT);
      return(FALSE);
   }

   /*
    * By setting retVal to zero, we are instructing _CrtDbgReport
    * to continue with normal execution after generating the report.
    * If we wanted _CrtDbgReport to start the debugger, we would set
    * retVal to one.
    */
   retVal = 0;
}

int main()
{
      char *p1, *p2;

#ifndef _DEBUG
printf("Skipping this for non-debug mode.\n");
return 2;
#endif

   /* 
    * Hook in our client-defined reporting function.
    * Every time a _CrtDbgReport is called to generate
    * a debug report, our function will get called first.
    */
   _CrtSetReportHook( OurReportingFunction );

   /* 
    * Define the report destination(s) for each type of report
    * we are going to generate.  In this case, we are going to
    * generate a report for every report type: _CRT_WARN,
    * _CRT_ERROR, and _CRT_ASSERT.
    * The destination(s) is defined by specifying the report mode(s)
    * and report file for each report type.
    * This program sends all report types to STDOUT.
    */                                             
   _CrtSetReportMode(_CRT_WARN, _CRTDBG_MODE_FILE);
   _CrtSetReportFile(_CRT_WARN, _CRTDBG_FILE_STDOUT);
   _CrtSetReportMode(_CRT_ERROR, _CRTDBG_MODE_FILE);
   _CrtSetReportFile(_CRT_ERROR, _CRTDBG_FILE_STDOUT);
   _CrtSetReportMode(_CRT_ASSERT, _CRTDBG_MODE_FILE);
   _CrtSetReportFile(_CRT_ASSERT, _CRTDBG_FILE_STDOUT);

   /*
    * Allocate and assign the pointer variables
    */
   p1 = malloc(10);
   strcpy(p1, "I am p1");
   p2 = malloc(10);
   strcpy(p2, "I am p2");

   /*
    * Use the report macros as a debugging
    * warning mechanism, similar to printf.
    *
    * Use the assert macros to check if the
    * p1 and p2 variables are equivalent.
    *
    * If the expression fails, _ASSERTE will
    * include a string representation of the
    * failed expression in the report.
    *
    *  _ASSERT does not include the
    * expression in the generated report.
    */
   _RPT0(_CRT_WARN, "\n\n Use the assert macros to evaluate the expression p1 == p2.\n");
   _RPTF2(_CRT_WARN, "\n Will _ASSERT find '%s' == '%s' ?\n", p1, p2);
   _ASSERT(p1 == p2);

   _RPTF2(_CRT_WARN, "\n\n Will _ASSERTE find '%s' == '%s' ?\n", p1, p2);
   _ASSERTE(p1 == p2);

   _RPT2(_CRT_ERROR, "\n \n '%s' != '%s'\n", p1, p2);
   
   free(p2);
   free(p1);

   return 0;
}