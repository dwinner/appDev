// CoText.h: interface for the CoText class.
//
//////////////////////////////////////////////////////////////////////

#include "interfaces.h"

#if !defined(AFX_COTEXT_H__466300A3_99B5_11D3_A7DE_0000E885A202__INCLUDED_)
#define AFX_COTEXT_H__466300A3_99B5_11D3_A7DE_0000E885A202__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

extern ULONG g_objCount;

class CoText : public IText		
{
	// Private underlying BSTR.
	BSTR m_bstr;
	ULONG m_refCount;
public:
	CoText() 
	{ 
		m_bstr = SysAllocString(L"The default string");
		m_refCount = 0;
		g_objCount++;
	}

	~CoText()
	{ 
		g_objCount--;
		if (m_bstr) 
			SysFreeString(m_bstr);
	}

	// Assume standard IUnknown implementation
	STDMETHODIMP QueryInterface(REFIID riid, void** ppv);
	STDMETHODIMP_(ULONG) AddRef();
	STDMETHODIMP_(ULONG)Release();

	// IText methods.
	STDMETHODIMP Speak (BSTR bstrMessage);	
	STDMETHODIMP GiveMeABSTR (BSTR* bstr); 
};


#endif // !defined(AFX_COTEXT_H__466300A3_99B5_11D3_A7DE_0000E885A202__INCLUDED_)
