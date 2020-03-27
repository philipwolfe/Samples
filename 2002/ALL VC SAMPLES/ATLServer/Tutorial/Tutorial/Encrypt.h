// Encrypt.h
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

#if !defined(_ENCRYPT_H___56CB3A02_D832_11D3_BADB_00C04F8EC847___INCLUDED_)
#define _ENCRYPT_H___56CB3A02_D832_11D3_BADB_00C04F8EC847___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include <atlcrypt.h>

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
	

} // namespace VCUE

#endif // !defined(_ENCRYPT_H___56CB3A02_D832_11D3_BADB_00C04F8EC847___INCLUDED_)
