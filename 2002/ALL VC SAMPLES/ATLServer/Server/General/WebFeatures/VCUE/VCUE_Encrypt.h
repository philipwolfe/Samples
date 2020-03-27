// VCUE_Encrypt.h
// (c) 2000 Microsoft Corporation
//
//////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(_VCUE_ENCRYPT_H___56CB3A02_D832_11D3_BADB_00C04F8EC847___INCLUDED_)
#define _VCUE_ENCRYPT_H___56CB3A02_D832_11D3_BADB_00C04F8EC847___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include <atlcrypt.h>
#include "VCUE_Encode.h"

namespace VCUE
{
	template <class T>
	inline const T* cstring_cast(const CStringA& str)
	{
		return reinterpret_cast<const T*>(static_cast<CStringA::PCXSTR>(str));
	}


	inline HRESULT EnsureAcquire(
			CCryptProv& prov,
			LPCTSTR pszContainer = NULL,
			LPCTSTR pszProvider = MS_DEF_PROV,
			DWORD dwProvType = PROV_RSA_FULL,
			DWORD dwFlags = CRYPT_VERIFYCONTEXT | CRYPT_SILENT
			)
	{
		HRESULT hr = prov.Initialize(dwProvType, pszContainer, pszProvider , dwFlags);

		if (hr == NTE_KEYSET_NOT_DEF)
				hr = prov.Initialize(dwProvType, pszContainer, pszProvider,  dwFlags | CRYPT_NEWKEYSET);

		return hr;
	}

	inline HRESULT CreateSaltedHash(
				CCryptProv& Provider,
				const BYTE* Secret, DWORD SecretLength,
				const BYTE* Salt, DWORD SaltLength,
				BYTE* Hash,	DWORD& HashLength
			)
	{
		HRESULT hr = E_FAIL;
		HCRYPTHASH hHash = 0;
		if (CryptCreateHash(Provider.GetHandle(), CALG_MD5, 0, 0, &hHash))
		{
			CCryptHash oHash(hHash, TRUE);
			hr = oHash.AddData(Secret, SecretLength);
			if (SUCCEEDED(hr))
			{
				hr = oHash.AddData(Salt, SaltLength);
				if (SUCCEEDED(hr))
				{
					DWORD Size = 0;
					hr = oHash.GetSize(&Size);
					if (SUCCEEDED(hr))
					{
						if (Size <= HashLength)
							hr = oHash.GetValue(Hash, &HashLength);
						else
							hr = E_OUTOFMEMORY;
					}
				}
			}
		}

		return hr;
	}

	inline HRESULT HashSecret(
				const BYTE* Secret, DWORD SecretLength,
				BYTE* Salt, DWORD& SaltLength,
				BYTE* Hash, DWORD& HashLength
				)
	{
		CCryptProv Provider;
		HRESULT hr = EnsureAcquire(Provider);
		if (SUCCEEDED(hr))
		{
			hr = Provider.GenRandom(SaltLength, Salt);
			if (SUCCEEDED(hr))
			{
				hr = CreateSaltedHash( Provider,
						Secret, SecretLength,
						Salt, SaltLength,
						Hash, HashLength);
			}
		}
		return hr;
	}

	inline HRESULT CompareSecret(
				const BYTE* Secret, DWORD SecretLength,
				const BYTE* Salt, DWORD SaltLength,
				const BYTE* Hash, DWORD HashLength
				)
	{
		DWORD CalculatedHashLength = HashLength;
		BYTE* CalculatedHash = new BYTE[HashLength];
		if (!CalculatedHash)
			return E_OUTOFMEMORY;

		CCryptProv Provider;
		HRESULT hr = EnsureAcquire(Provider);
		if (SUCCEEDED(hr))
		{
			hr = CreateSaltedHash( Provider,
					Secret, SecretLength,
					Salt, SaltLength,
					CalculatedHash, CalculatedHashLength);
			if (SUCCEEDED(hr))
			{
				hr = S_FALSE;
				if (CalculatedHashLength == HashLength)
				{
					if (0 == memcmp(Hash, CalculatedHash, HashLength))
						hr = S_OK;
				}
			}
		}
		delete [] CalculatedHash;
		return hr;
	}


	inline HRESULT AddString(CCryptHash& Hash, const CStringA& Data, DWORD Flags = 0)
	{
		return Hash.AddData(cstring_cast<BYTE>(Data), Data.GetLength() * sizeof(CStringA::XCHAR), Flags);
	}

	template <class T>
	inline HRESULT AddByteArray(CCryptHash& Hash, const T& Data, DWORD Flags = 0)
	{
		static_cast<const BYTE[sizeof(Data)]>(Data);
		return Hash.AddData(Data, sizeof(Data), Flags);
	}

	template <class T>
	inline HRESULT GenerateRandomByteArray(CCryptProv& Provider, T& Data)
	{
		static_cast<BYTE[sizeof(Data)]>(Data);
		return Provider.GenRandom(sizeof(Data), Data);
	}

	inline HRESULT GetHexHashValue(CCryptHash& Hash, CStringA& Encoded)
	{
		DWORD Size = 0;
		HRESULT hr = Hash.GetSize(&Size);
		if (SUCCEEDED(hr))
		{
			BYTE* Value = new BYTE[Size];
			if (Value)
			{			
				hr = Hash.GetValue(Value, &Size);
				if (SUCCEEDED(hr))
				{
					hr = HexEncode(Value, Size, Encoded);
				}

				delete [] Value;
			}
			else
				hr = E_OUTOFMEMORY;
		}
		return hr;
	}


	template <size_t RandomBytes>
	class CTimedSessionCreator
	{
	public :
		HRESULT Create(const CStringA& User, const CStringA& Password, CStringA& Session)
		{
			HRESULT hr = E_UNEXPECTED;

			hr = Initialize();
			if (SUCCEEDED(hr))
			{
				hr = HashData(User, Password);
				if (SUCCEEDED(hr))
				{
					CStringA hexTime;
					hr = HexEncode(reinterpret_cast<BYTE*>(&Created), sizeof(Created), hexTime);
					if (FAILED(hr))
						return hr;

					CStringA hexRandom;
					hr = HexEncodeByteArray(Random, hexRandom);
					if (FAILED(hr))
						return hr;

					CStringA hexHash;
					hr = GetHexHashValue(Hash, hexHash);
					if (FAILED(hr))
						return hr;

					Session = hexRandom;
					Session.Append(":");
					Session.Append(hexTime);
					Session.Append(":");
					Session.Append(hexHash);
				}
			}

			return hr;
		}

	private:
		__time64_t Created;
		CCryptProv Provider;
		CCryptHash Hash;
		BYTE Random[RandomBytes];

		HRESULT Initialize()
		{
			Created = ::_time64(NULL);

			HRESULT hr = EnsureAcquire(Provider);
			if (SUCCEEDED(hr))
			{
				HCRYPTHASH hHash = 0;
				if (CryptCreateHash(Provider.GetHandle(), CALG_MD5, 0, 0, &hHash))
				{
					Hash.Attach(hHash, TRUE);
					hr = GenerateRandomByteArray(Provider, Random);
				}
				else
					hr = E_FAIL;
			}
			return hr;
		}

		HRESULT HashData(const CStringA& User, const CStringA& Password)
		{
			HRESULT hr = AddString(Hash, User);
			if (SUCCEEDED(hr))
			{
				hr = AddString(Hash, Password);
				if (SUCCEEDED(hr))
				{
					hr = AddByteArray(Hash, Random);
					if (SUCCEEDED(hr))
					{
						hr = Hash.AddData(reinterpret_cast<BYTE*>(&Created), sizeof(Created));
					}
				}
			}
			return hr;
		}
	};

} // namespace VCUE

#endif // !defined(_VCUE_ENCRYPT_H___56CB3A02_D832_11D3_BADB_00C04F8EC847___INCLUDED_)
