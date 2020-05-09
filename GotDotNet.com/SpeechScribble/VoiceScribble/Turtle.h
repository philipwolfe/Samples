#ifndef _TURTLE_H_INCLUDED
#define _TURTLE_H_INCLUDED

#pragma once

#define _USE_MATH_DEFINES
#include <math.h>
#ifndef M_PI
	#define M_PI       3.14159265358979323846
#endif
#include "TurtleGraphicsDefs.h"


struct stTurtleDraw
{
	POINT	pt1;
	POINT	pt2;
	POINT	pt3;
	POINT	pt4;
};

class CTurtle : public CObject
{
protected:
	
public:
	// screen coordinates
	double				m_dX;
	double				m_dY;
	int					m_i360Angle;
	// orientation (trigo)
	double				m_dAngle;

	int					m_nLeftBoundary;
	int					m_nTopBoundary;
	int					m_nRightBoundary;
	int					m_nBottomBoundary;
public:
	stTurtleDraw		m_turtleDraw;

	unsigned int		m_i360Delta;

	// pen status -- up, down
	bool				m_bPenDown;
	
	
	// pen width -- default 1
	unsigned int		m_nPenWidth;

	// color
	unsigned int		m_nColor;

public:
	CTurtle()
	{
		memset(&m_turtleDraw, 0, sizeof(stTurtleDraw));
		
		m_dX		=	TURTLE_START_X;
		m_dY		=	TURTLE_START_Y;
		m_i360Angle	=	0;
		m_dAngle	=	0;

		m_bPenDown = true;
		m_nPenWidth	= 1;
		m_nColor = 0;

		m_nLeftBoundary = 
		m_nTopBoundary =
		m_nRightBoundary =
		m_nBottomBoundary = 0;
		CalculateTurtleDraw();
	}

	int X()
	{
		return (int)m_dX;
	}
	
	int Y()
	{
		return (int)m_dY;
	}

	int	Angle()
	{
		return m_i360Angle;
	}

	void	SetStartPoint( int x, int y)
	{
		m_dX = x;
		m_dY = y;
		m_dAngle = 0;
		m_i360Angle = 0;
		CalculateTurtleDraw();
	}

	
	void	Forward(int iStep)
	{
		double	dRadius	=	iStep;
		
		m_dX	=	m_dX + dRadius*cos( m_dAngle);
		m_dY	=	m_dY + dRadius*sin( m_dAngle);

		if( m_dX < m_nLeftBoundary )
			m_nLeftBoundary = (int)m_dX;
		if( m_dX > m_nRightBoundary )
			m_nRightBoundary = (int)m_dX;
		if( m_dY < m_nTopBoundary)
			m_nTopBoundary = (int)m_dY;
		if( m_dY > m_nBottomBoundary )
			m_nBottomBoundary = (int)m_dY;
		CalculateTurtleDraw();

	}


	void	OffsetAngle(int i360Angle)
	{
		const double degree	=	2*M_PI / 360.0;
	
		m_i360Angle	=	(m_i360Angle + i360Angle) % 360;
		m_dAngle	=	degree * m_i360Angle;
		CalculateTurtleDraw();
	}


public:
protected:
	void CalculateTurtleDraw()
	{
		double	dSmallRadius = 5.0, dRadius = 20.0;
		double	dAngle;

		dAngle = m_dAngle;
		m_turtleDraw.pt1.x = (LONG)(m_dX + dRadius*cos( dAngle ));
		m_turtleDraw.pt1.y = (LONG)(m_dY + dRadius*sin( dAngle ));

		dAngle = 2*M_PI/3 + m_dAngle;
		m_turtleDraw.pt2.x = (LONG)(m_dX + dRadius*cos( dAngle ));
		m_turtleDraw.pt2.y = (LONG)(m_dY + dRadius*sin( dAngle ));

		dAngle = m_dAngle;
		m_turtleDraw.pt3.x = (LONG)(m_dX - dSmallRadius*cos( dAngle ));
		m_turtleDraw.pt3.y = (LONG)(m_dY - dSmallRadius*sin( dAngle ));

		dAngle = 4*M_PI/3 + m_dAngle;
		m_turtleDraw.pt4.x = (LONG)(m_dX + dRadius*cos( dAngle ));
		m_turtleDraw.pt4.y = (LONG)(m_dY + dRadius*sin( dAngle ));
	}
};// end CTurtle


#endif _TURTLE_H_INCLUDED