' ============================================================
' Class:    ReadWriteLock.cs
' Copyright (c) Microsoft, 1999-2000
' ===========================================================

imports System
imports System.Threading


public module ReadWriteLock

 
public class ReadWriteLock
'	public OutX As Integer
	public ReadX As Integer
	public WriteX As Integer 
	public  shared rwLock As ReaderWriterLock = new ReaderWriterLock()

	Sub ReaderFunc( )
		Dim ReadL As Integer = Interlocked.Increment(ReadX)
		Dim upgradeCookie As LockCookie


		try
			if (rwLock.IsReaderLockHeld or rwLock.IsWriterLockHeld) then

				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -BAD- No Locks should be held now.",ReadL)
				
				finally 
					Monitor.Exit(Me)
				end try


                        end if

		catch e As Exception
				Monitor.Enter(Me)
				try
				    Console.WriteLine(" {0}, Reader -BAD- (IsReaderLockHeld || IsWriterLockHeld) {1}",ReadL,e.ToString())
				
				finally 
				    Monitor.Exit(Me)
				end try

		end try

		try
				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -fyi- Before AcquireReaderLock.",ReadL)				
				finally 
				    Monitor.Exit(Me)
				end try


				

			rwLock.AcquireReaderLock(1000)

				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -fyi- After  AcquireReaderLock.",ReadL)
				finally 
				    Monitor.Exit(Me)
				end try
		catch e As Exception
				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -BAD- (AcquireReaderLock) {1}",ReadL,e.ToString())
				finally 
				    Monitor.Exit(Me)
				end try
		end try

		Thread.Sleep(10)

		try
			if not rwLock.IsReaderLockHeld then
				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -BAD- ReaderLock  FALSE",ReadL)
				finally 
				    Monitor.Exit(Me)
				end try
                        end if

				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -fyi- Before UpgradeToWriterLock.",ReadL)
				finally 
				    Monitor.Exit(Me)
				end try

			upgradeCookie = rwLock.UpgradeToWriterLock(1000)

				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -fyi- After  UpgradeToWriterLock.",ReadL)
				finally 
				    Monitor.Exit(Me)
				end try
		catch e As Exception
				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -BAD- (UpgradeToWriterLock) {1}",ReadL,e.ToString())
				finally 
				    Monitor.Exit(Me)
				end try
		end try

		try
			if rwLock.IsReaderLockHeld then
				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -BAD- ReaderLock  TRUE",ReadL)
				finally 
				    Monitor.Exit(Me)
				end try
			end if

			if not rwLock.IsWriterLockHeld then
				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -BAD- WriterLock  FALSE",ReadL)
				finally 
				    Monitor.Exit(Me)
				end try
			end if

				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -fyi- Before DowngradeFromWriterLock.",ReadL)
				finally 
				    Monitor.Exit(Me)
				end try

			rwLock.DowngradeFromWriterLock(upgradeCookie)

				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -fyi- After  DowngradeFromWriterLock.",ReadL)
				finally 
				    Monitor.Exit(Me)
				end try
		catch e As Exception
				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -BAD- (DowngradeFromWriterLock) {1}",ReadL,e.ToString())
				finally 
				    Monitor.Exit(Me)
				end try
		end try

		try
			if rwLock.IsWriterLockHeld then
				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -BAD- WriterLock  TRUE",ReadL)
				finally 
				    Monitor.Exit(Me)
				end try
                        end if

			if  not rwLock.IsReaderLockHeld then
				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -BAD- ReaderLock should be held now.",ReadL)
				finally 
				    Monitor.Exit(Me)
				end try
                        end if

				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -fyi- Before ReleaseReaderLock.",ReadL)
				finally 
				    Monitor.Exit(Me)
				end try

			rwLock.ReleaseReaderLock( )

				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -fyi- After  ReleaseReaderLock.",ReadL)
				finally 
				    Monitor.Exit(Me)
				end try
		catch e As Exception
				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -BAD- (ReleaseReaderLock) {1}",ReadL,e.ToString())
				finally 
				    Monitor.Exit(Me)
				end try
		end try

		try
			if (rwLock.IsReaderLockHeld or rwLock.IsWriterLockHeld) then
				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader -BAD- No Locks should be held now.",ReadL)
				finally 
				    Monitor.Exit(Me)
				end try
		        end if

		catch e As Exception
				Monitor.Enter(Me)
				try
					Console.WriteLine(" {0}, Reader - {1}",ReadL,e.ToString())
				finally 
				    Monitor.Exit(Me)
				end try
		end try
	End Sub

	sub WriterFunc( )
		dim WriteL as integer = Interlocked.Increment(WriteX)
		dim releaseCookie As LockCookie
		dim iWriterSeqNum As integer
			
		if rwLock.IsReaderLockHeld or rwLock.IsWriterLockHeld then
				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer -BAD- No Locks should be held now. (I)",WriteL)
				finally 
				    Monitor.Exit(Me)
				end try
                end if

		try
				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer -fyi- Before AcquireWriterLock.",WriteL)
				finally 
				    Monitor.Exit(Me)
				end try

			rwLock.AcquireWriterLock(1000)

				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer -fyi- After  AcquireWriterLock.",WriteL)
				finally 
				    Monitor.Exit(Me)
				end try
		
		catch e As Exception
				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer -BAD- (AcquireWriterLock) {1}",WriteL,e.ToString())
				finally 
				    Monitor.Exit(Me)
				end try
		end try

		Thread.Sleep(10)

		try
			if not rwLock.IsWriterLockHeld then
				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer -BAD- WriterLock should be held now. (I)",WriteL)
				finally 
				    Monitor.Exit(Me)
				end try
                        end if

			iWriterSeqNum = rwLock.WriterSeqNum

				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer -fyi- Before ReleaseLock.",WriteL)
				finally 
				    Monitor.Exit(Me)
				end try

			releaseCookie = rwLock.ReleaseLock( )

				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer -fyi- After  ReleaseLock.",WriteL)
				finally 
				    Monitor.Exit(Me)
				end try

			if rwLock.IsReaderLockHeld or rwLock.IsWriterLockHeld then
				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer -BAD- No Locks should be held now. (II)",WriteL)
				finally 
				    Monitor.Exit(Me)
				end try
                        end if

				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer -fyi- Before RestoreLock.",WriteL)
				finally 
				    Monitor.Exit(Me)
				end try

			rwLock.RestoreLock(releaseCookie)

				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer -fyi- After  RestoreLock.",WriteL)
				finally 
				    Monitor.Exit(Me)
				end try

			if not rwLock.IsWriterLockHeld then
				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer -BAD- WriterLock should be held now. (II)",WriteL)
				finally 
				    Monitor.Exit(Me)
				end try
                        end if

				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer -fyi- Before ReleaseWriterLock.",WriteL)
				finally 
				    Monitor.Exit(Me)
				end try

			rwLock.ReleaseWriterLock( )

				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer -fyi- After  ReleaseWriterLock.",WriteL)
				finally 
				    Monitor.Exit(Me)
				end try

			dim boX as boolean
			boX = rwLock.AnyWritersSince(iWriterSeqNum)
			iWriterSeqNum = rwLock.WriterSeqNum
			boX	= rwLock.AnyWritersSince(iWriterSeqNum)
		catch e As Exception
				Monitor.Enter(Me)
				try
					Console.WriteLine("{0}, Writer - {1}",WriteL,e.ToString())
				finally 
				    Monitor.Exit(Me)
				end try
		end try
	end sub

End Class	' ReadWriteLock


	Sub Main()
		Dim thrd As Thread
		Dim XYZ As ReadWriteLock = new ReadWriteLock( )
                Dim i AS Integer

		' XYZ.OutX = 1
		XYZ.ReadX = 0
		XYZ.WriteX = 10

		dim reader As ThreadStart = new ThreadStart(AddressOf XYZ.ReaderFunc)
		dim writer As ThreadStart = new ThreadStart(AddressOf XYZ.WriterFunc)

		for i = 0 To 3
			thrd = new Thread(reader)
			thrd.Start( )
		next

		for i = 0 To 3
			thrd = new Thread(writer)
			thrd.Start( )
		next

	End Sub

End Module	' ReadWriteLock
