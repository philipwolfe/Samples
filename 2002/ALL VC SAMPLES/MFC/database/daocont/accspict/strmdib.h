// StreamDib.h : header file
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.


/////////////////////////////////////////////////////////////////////////////
// Definitions

#define MAKEDWORD(x) (*((DWORD*)(&(x))))
#define MAKERGBQUAD(x) (*((RGBQUAD*)(&(x))))
#define WIDTHBYTES(bits) ((((bits) + 31) / 32) * 4)


/////////////////////////////////////////////////////////////////////////////
// Globals

static RGBQUAD rgbStd256[] =
{
	{   0,  0,  0, 0 }, {   0,  0,128, 0 }, {   0,128,  0, 0 }, {   0,128,128, 0 },
	{ 128,  0,  0, 0 }, { 128,  0,128, 0 }, { 128,128,  0, 0 }, { 192,192,192, 0 },
	{ 192,220,192, 0 }, { 240,202,166, 0 }, { 238,238,238, 0 }, { 221,221,221, 0 },
	{ 204,204,204, 0 }, { 187,187,187, 0 }, { 170,170,170, 0 }, { 153,153,153, 0 },
	{ 136,136,136, 0 }, { 119,119,119, 0 }, { 102,102,102, 0 }, {  85, 85, 85, 0 },
	{  68, 68, 68, 0 }, {  51, 51, 51, 0 }, {  34, 34, 34, 0 }, {  17, 17, 17, 0 },
	{ 204,255,255, 0 }, { 153,255,255, 0 }, { 102,255,255, 0 }, {  51,255,255, 0 },
	{ 255,204,255, 0 }, { 204,204,255, 0 }, { 153,204,255, 0 }, { 102,204,255, 0 },
	{  51,204,255, 0 }, {   0,204,255, 0 }, { 255,153,255, 0 }, { 204,153,255, 0 },
	{ 153,153,255, 0 }, { 102,153,255, 0 }, {  51,153,255, 0 }, {   0,153,255, 0 },
	{ 255,102,255, 0 }, { 204,102,255, 0 }, { 153,102,255, 0 }, { 102,102,255, 0 },
	{  51,102,255, 0 }, {   0,102,255, 0 }, { 255, 51,255, 0 }, { 204, 51,255, 0 },
	{ 153, 51,255, 0 }, { 102, 51,255, 0 }, {  51, 51,255, 0 }, {   0, 51,255, 0 },
	{ 204,  0,255, 0 }, { 153,  0,255, 0 }, { 102,  0,255, 0 }, {  51,  0,255, 0 },
	{ 255,255,204, 0 }, { 204,255,204, 0 }, { 153,255,204, 0 }, { 102,255,204, 0 },
	{  51,255,204, 0 }, {   0,255,204, 0 }, { 255,204,204, 0 }, { 153,204,204, 0 },
	{ 102,204,204, 0 }, {  51,204,204, 0 }, {   0,204,204, 0 }, { 255,153,204, 0 },
	{ 204,153,204, 0 }, { 153,153,204, 0 }, { 102,153,204, 0 }, {  51,153,204, 0 },
	{   0,153,204, 0 }, { 255,102,204, 0 }, { 204,102,204, 0 }, { 153,102,204, 0 },
	{ 102,102,204, 0 }, {  51,102,204, 0 }, {   0,102,204, 0 }, { 255, 51,204, 0 },
	{ 204, 51,204, 0 }, { 153, 51,204, 0 }, { 102, 51,204, 0 }, {  51, 51,204, 0 },
	{   0, 51,204, 0 }, { 255,  0,204, 0 }, { 204,  0,204, 0 }, { 153,  0,204, 0 },
	{ 102,  0,204, 0 }, {  51,  0,204, 0 }, { 255,255,153, 0 }, { 204,255,153, 0 },
	{ 153,255,153, 0 }, { 102,255,153, 0 }, {  51,255,153, 0 }, {   0,255,153, 0 },
	{ 255,204,153, 0 }, { 204,204,153, 0 }, { 153,204,153, 0 }, { 102,204,153, 0 },
	{  51,204,153, 0 }, {   0,204,153, 0 }, { 255,153,153, 0 }, { 204,153,153, 0 },
	{ 102,153,153, 0 }, {  51,153,153, 0 }, {   0,153,153, 0 }, { 255,102,153, 0 },
	{ 204,102,153, 0 }, { 153,102,153, 0 }, { 102,102,153, 0 }, {  51,102,153, 0 },
	{   0,102,153, 0 }, { 255, 51,153, 0 }, { 204, 51,153, 0 }, { 153, 51,153, 0 },
	{ 102, 51,153, 0 }, {  51, 51,153, 0 }, {   0, 51,153, 0 }, { 255,  0,153, 0 },
	{ 204,  0,153, 0 }, { 153,  0,153, 0 }, { 102,  0,153, 0 }, {  51,  0,153, 0 },
	{ 255,255,102, 0 }, { 204,255,102, 0 }, { 153,255,102, 0 }, { 102,255,102, 0 },
	{  51,255,102, 0 }, {   0,255,102, 0 }, { 255,204,102, 0 }, { 204,204,102, 0 },
	{ 153,204,102, 0 }, { 102,204,102, 0 }, {  51,204,102, 0 }, {   0,204,102, 0 },
	{ 255,153,102, 0 }, { 204,153,102, 0 }, { 153,153,102, 0 }, { 102,153,102, 0 },
	{  51,153,102, 0 }, {   0,153,102, 0 }, { 255,102,102, 0 }, { 204,102,102, 0 },
	{ 153,102,102, 0 }, {  51,102,102, 0 }, {   0,102,102, 0 }, { 255, 51,102, 0 },
	{ 204, 51,102, 0 }, { 153, 51,102, 0 }, { 102, 51,102, 0 }, {  51, 51,102, 0 },
	{   0, 51,102, 0 }, { 255,  0,102, 0 }, { 204,  0,102, 0 }, { 153,  0,102, 0 },
	{ 102,  0,102, 0 }, {  51,  0,102, 0 }, { 255,255, 51, 0 }, { 204,255, 51, 0 },
	{ 153,255, 51, 0 }, { 102,255, 51, 0 }, {  51,255, 51, 0 }, {   0,255, 51, 0 },
	{ 255,204, 51, 0 }, { 204,204, 51, 0 }, { 153,204, 51, 0 }, { 102,204, 51, 0 },
	{  51,204, 51, 0 }, {   0,204, 51, 0 }, { 255,153, 51, 0 }, { 204,153, 51, 0 },
	{ 153,153, 51, 0 }, { 102,153, 51, 0 }, {  51,153, 51, 0 }, {   0,153, 51, 0 },
	{ 255,102, 51, 0 }, { 204,102, 51, 0 }, { 153,102, 51, 0 }, { 102,102, 51, 0 },
	{  51,102, 51, 0 }, {   0,102, 51, 0 }, { 255, 51, 51, 0 }, { 204, 51, 51, 0 },
	{ 153, 51, 51, 0 }, { 102, 51, 51, 0 }, {   0, 51, 51, 0 }, { 255,  0, 51, 0 },
	{ 204,  0, 51, 0 }, { 153,  0, 51, 0 }, { 102,  0, 51, 0 }, {  51,  0, 51, 0 },
	{ 204,255,  0, 0 }, { 153,255,  0, 0 }, { 102,255,  0, 0 }, {  51,255,  0, 0 },
	{ 255,204,  0, 0 }, { 204,204,  0, 0 }, { 153,204,  0, 0 }, { 102,204,  0, 0 },
	{  51,204,  0, 0 }, { 255,153,  0, 0 }, { 204,153,  0, 0 }, { 153,153,  0, 0 },
	{ 102,153,  0, 0 }, {   0,  0,238, 0 }, {   0,  0,221, 0 }, {   0,  0,204, 0 },
	{   0,  0,187, 0 }, {   0,  0,170, 0 }, {   0,  0,153, 0 }, {   0,  0,136, 0 },
	{   0,  0,119, 0 }, {   0,  0,102, 0 }, {   0,  0, 85, 0 }, {   0,  0, 68, 0 },
	{   0,  0, 51, 0 }, {   0,  0, 34, 0 }, {   0,  0, 17, 0 }, {   0,238,  0, 0 },
	{   0,221,  0, 0 }, {   0,204,  0, 0 }, {   0,187,  0, 0 }, {   0,170,  0, 0 },
	{   0,153,  0, 0 }, {   0,136,  0, 0 }, {   0,119,  0, 0 }, {   0,102,  0, 0 },
	{   0, 85,  0, 0 }, {   0, 68,  0, 0 }, {   0, 51,  0, 0 }, {   0, 34,  0, 0 },
	{   0, 17,  0, 0 }, { 238,  0,  0, 0 }, { 221,  0,  0, 0 }, { 204,  0,  0, 0 },
	{ 187,  0,  0, 0 }, { 170,  0,  0, 0 }, { 153,  0,  0, 0 }, { 136,  0,  0, 0 },
	{ 119,  0,  0, 0 }, { 102,  0,  0, 0 }, {  85,  0,  0, 0 }, {  68,  0,  0, 0 },
	{  51,  0,  0, 0 }, {  34,  0,  0, 0 }, { 240,251,255, 0 }, { 164,160,160, 0 },
	{ 128,128,128, 0 }, {   0,  0,255, 0 }, {   0,255,  0, 0 }, {   0,255,255, 0 },
	{ 255,  0,  0, 0 }, { 255,  0,255, 0 }, { 255,255,  0, 0 }, { 255,255,255, 0 }
};


/////////////////////////////////////////////////////////////////////////////
// Class CStreamDib

class CStreamDib : public CObject
{
	DECLARE_DYNAMIC(CStreamDib)

// Construction
public:
	CStreamDib();
	virtual ~CStreamDib();

// Attributes
public:
	// Bitmap accessor functions
	CPalette*   GetPalette();
	CBitmap*    GetBitmap();
	CSize       GetSize();

protected:
	// Bitmap handling attributes
	CBitmap         m_Bitmap;
	CPalette        m_Palette;
	RGBQUAD         m_rgbPalette[256];
	LPBITMAPINFO    m_lpbi;
	CSize           m_size;

// Operations
public:
	// DIB Reading Functions
	BOOL LoadBitmap(LPSTREAM lpStream);

// Implementation
protected:
	void CreateBitmap(CSize& size);
	void MergePalette(RGBQUAD* pColors, int nColors);
};

/////////////////////////////////////////////////////////////////////////////
