#include "StdAfx.h"
#include "frametimer.h"

CFrameTimer::CFrameTimer(double framesPerSecond)
		: m_currentTime(0),
		  m_previousTime(0),
		  m_nextTime(0),
		  m_perfCounterFreq(0),
		  m_timeCount(0),
		  m_usePerfCounter(false),		  
		  m_timeScale(0),
		  m_fps(framesPerSecond)
{
}

CFrameTimer::~CFrameTimer(void)
{
}
	
void CFrameTimer::SetFPS(double value)
{
	m_fps = value;
}

void CFrameTimer::Start()
{
	if (QueryPerformanceFrequency((LARGE_INTEGER*) &m_perfCounterFreq))
	{
		m_usePerfCounter = true;
		m_timeCount		 = (DWORD)m_perfCounterFreq/m_fps;

		QueryPerformanceCounter((LARGE_INTEGER*) &m_nextTime);
		m_timeScale = 1.0/m_perfCounterFreq;
	}
	else
	{
		m_nextTime = timeGetTime();
		m_timeScale = 0.001;
		m_timeCount = (DWORD)m_fps + 3;
	}
	m_previousTime = m_nextTime;				
}

bool CFrameTimer::NextFrame()
{	
	// calculate the current time
	if (m_usePerfCounter)
	{
		QueryPerformanceCounter((LARGE_INTEGER*) &m_currentTime);
	}
	else
	{
		m_currentTime = timeGetTime();
	}

	if (m_currentTime > m_nextTime)
	{
		m_previousTime = m_currentTime;
		m_nextTime = m_currentTime + m_timeCount;

		return true;
	}
	else
	{
		return false;
	}
}

