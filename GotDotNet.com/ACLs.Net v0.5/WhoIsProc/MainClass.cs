using System;
using System.Diagnostics;

using Microsoft.Win32.Security;

namespace WhoIsProc
{
	class MainClass
	{
		[STAThread]
		static void Main(string[] args)
		{
#if false
			// Enable DEBUG/SECURITY/TCB privileges on this process
			try
			{
				using(AccessToken tk = new AccessToken(System.Diagnostics.Process.GetCurrentProcess(), TokenAccessType.TOKEN_ADJUST_PRIVILEGES))
				{
					tk.EnablePrivilege(new TokenPrivilege(TokenPrivilege.SE_DEBUG_NAME, true));
					tk.EnablePrivilege(new TokenPrivilege(TokenPrivilege.SE_SECURITY_NAME, true));
					tk.EnablePrivilege(new TokenPrivilege(TokenPrivilege.SE_TCB_NAME, true));
				}
			}
			catch(Exception e)
			{
				Console.WriteLine("Warning: Couldn't enable DEBUG privilege: {0}", e.Message);
			}
#endif
			//
			new MainClass().EntryPoint(args);
		}
		void EntryPoint(string[] args)
		{
			int pid = -1;
			string pname = null;
			try
			{
				if (String.CompareOrdinal(args[0], "-pn") == 0)
				{
					pname = args[1];
				}
				else
				{
					pid = int.Parse(args[0]);
				}
			}
			catch
			{
				Console.WriteLine("Usage:");
				Console.WriteLine("whoisproc <process id> | -pn <process name>");
				Console.WriteLine("  Lists the account under which a process is running.");
				return;
			}

			if (pname != null)
			{
				foreach(Process p in Process.GetProcessesByName(pname))
				{
					DisplayProcessInfo(p.Id);
				}
			}
			else
			{
				DisplayProcessInfo(pid);
			}
		}
		private int _indent = 0;
		/// <summary>
		///  Display security info for given process id
		/// </summary>
		void DisplayProcessInfo(int pid)
		{
			_indent = 0;

			Process p;
			try
			{
				p = Process.GetProcessById(pid);
			}
			catch(ArgumentException)
			{
				WriteLine("Process {0} doesn't seem to exist", pid);
				return;
			}

			try
			{
				WriteLine("Information for process {0} ({1}):", p.Id, p.ProcessName);
				AccessToken at;

				// We first try to open with TOKEN_QUERY_SOURCE access, but this fails for
				// some processes (services). We fall back to TOKEN_QUERY only.
				at = AccessTokenProcess.TryOpenToken(p.Id, 
						TokenAccessType.TOKEN_QUERY | TokenAccessType.TOKEN_QUERY_SOURCE);

				if (at == null)
					at = AccessTokenProcess.TryOpenToken(p.Id, TokenAccessType.TOKEN_QUERY);

				using (at)
				{
					DisplayTokenInfo(at);

					int threadNotImpCount = 0;
					foreach(ProcessThread t in p.Threads)
					{
						try
						{
							AccessToken tat = AccessTokenThread.TryOpenToken(t.Id, TokenAccessType.TOKEN_QUERY);
							if (tat != null)
							{
								using(tat)
								{
									Unindent();
									WriteLine("Thread {0} is impersonating:", t.Id);
									DisplayTokenInfo(tat);
								}
							}
							else
							{
								threadNotImpCount++;
							}
						}
						catch(Exception e)
						{
							WriteLine("Error displaying information for thread {0}: {1}", t.Id, e.Message);
						}
					}
					if (threadNotImpCount == 1)
						WriteLine("{0} thread is not impersonating.", threadNotImpCount);
					else if (threadNotImpCount >= 2)
						WriteLine("{0} threads which are not impersonating.", threadNotImpCount);
				}
			}
			catch(Exception e)
			{
				WriteLine("Error displaying information for process {0}: {1}", pid, e.Message);
				return;
			}

		}
		/// <summary>
		///  Display information about a process or thread token
		/// </summary>
		/// <param name="at">The access token</param>
		void DisplayTokenInfo(AccessToken at)
		{
			Indent();
			WriteLine("User Name........... {0}", at.User.CanonicalName);
			WriteLine("User SID............ {0}", at.User.SidString);
			WriteLine("Session Id.......... {0}", at.TerminalServicesSessionId);
			try
			{
				WriteLine("Loggin Id........... {0}", at.Source.Luid.Value);
			}
			catch(UnauthorizedAccessException e)
			{
				WriteLine("Loggin Id........... <{0}>", e.Message);
			}
			WriteLine("Token Type.......... {0}", at.TokenType);
			if (at.TokenType == TokenType.TokenImpersonation)
			{
				WriteLine("Impersonation Level. {0}", at.ImpersonationLevel);
			}
			WriteLine("Restricted.......... {0}", at.IsRestricted);

			WriteLine("Privileges.......... {...}");
			Indent();
			DisplayPrivileges(at.Privileges);
			Unindent();

			WriteLine("Groups.............. {...}");
			Indent();
			DisplayGroups(at.Groups);
			Unindent();
		}
		void DisplayPrivileges(TokenPrivileges privs)
		{
			foreach(TokenPrivilege priv in privs)
			{
				WriteLine("{0,-40} -> {1}", priv.Name, priv.Attributes);
			}
		}
		void DisplayGroups(TokenGroups grps)
		{
			int i = 1;
			foreach(TokenGroup grp in grps)
			{
				WriteLine("Group #{0,3}...... {{...}}", i);
				Indent();
				WriteLine("Name........ {0}", grp.Sid.CanonicalName);
				WriteLine("SID......... {0}", grp.Sid.SidString);
				WriteLine("Attrib...... {0}", grp.Attributes);
				Unindent();

				i++;
			}
		}
		void DisplayAcl(Acl acl)
		{
			if (acl.IsNull)
			{
				WriteLine("Name........ {0}", "NULL");
				return;
			}

			int i = 1;
			foreach(Ace ace in acl)
			{
				WriteLine("Ace #{0,3}........ {{...}}", i);
				Indent();
				WriteLine("Type........ {0}", ace.Type);
				WriteLine("Size........ {0}", ace.Size);
				WriteLine("Flags....... {0}", ace.Flags);
				WriteLine("Access mask. {0}", ace.AccessType);
				WriteLine("SID name.... {0}", ace.Sid.CanonicalName);
				WriteLine("SID string.. {0}", ace.Sid.SidString);
				Unindent();
				i++;
			}
		}
		void WriteLine(string fmt, params object[] obj)
		{
			string msg = string.Format(fmt, obj);
			WriteLine(msg);
		}
		void WriteLine(string msg)
		{
			WriteIndent();
			Console.WriteLine(msg);
		}
		void Indent()
		{
			_indent++;
		}
		void Unindent()
		{
			_indent--;
		}
		void WriteIndent()
		{
			for (int i = 0; i < _indent; i++)
			{
				Console.Write("    ");
			}
		}
	}
}
