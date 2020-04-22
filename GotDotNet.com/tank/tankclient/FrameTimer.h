#pragma once

#include <Mmsystem.h>

class CFrameTimer
{
private:	
	LONGLONG m_currentTime;
	LONGLONG m_previousTime;
	LONGLONG m_nextTime;	
	LONGLONG m_perfCounterFreq;
	DWORD	 m_timeCount;
	bool	 m_usePerfCounter;	
	double	 m_timeScale;
	double	 m_fps;

public:

	CFrameTimer(double framesPerSecond = 30);
	virtual ~CFrameTimer(void);
	
	void SetFPS(double value);	
	void Start();	
	bool NextFrame();	
};
