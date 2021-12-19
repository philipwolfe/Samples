Introduction
------------
This VB.Net demo graphs an equation often used to predict the 
changes in population sizes over time. It is commonly known as 
the "logistic equation" and is discussed further at the end of 
this readme.

From a VB.Net perspective, there are at least four interesting 
things about this demo:

1. UI tools for resizing, docking, and transparency

Docking and anchoring are used to simplify resizing, although 
some resizing is still manually done in the Layout event. The 
form background shows control transparency.

2. Graphing points and lines

The techniques that underpin simple 2D drawing, such as the 
dynamic graphs presented in the PopGrowth demo, are significantly 
different in VB.Net compared to VB 5/6. Points and lines are 
graphed in a variable sized space in this demo.

3. Use of a timer

The timer is used to provide variable speed to the run mode.

4. Demonstration of the new LinkLabel

The new LinkLabel control can be used to access Jonny 
Anderson's site www.joyofvb.com (see below)


The PopGrowth Demo
------------------
To start the demo press the run button and watch the graph 
as it progresses. If you see something interesting press 
the Pause button and use the trackbar to investigate. The 
trackbar controls the value of the Growth Constant ("K" - 
see below) and the value of the Growth Constant is displayed 
at the bottom right. For each value of K a display of a hundred 
generations is shown as a graph of unconnected dots or connected 
lines - try both styles since they look quite different.

At certain values of K very interesting things happen. At low 
values of K, the population increases to a steady state. At 
a point near K=3, the graphed values "bifurcates" or splits 
into two, each fork carries on as if it were the entire graph. 
These bifurcation events are important to chaos theory. At about 
3.45 another bifurcation event occurs resulting in each fork 
splitting to produce four population levels. Chaos rules after 
this point but if you watch very carefully you will see one more 
artifact, islands of stability snap into existence for a few 
values of K before dissolving back into the background chaos 
once more. Keep your eyes open when K varies around 3.7 and 4.

Sit back and watch the demo using the 'Autospeed' feature. 
Without Autospeed, the application will seem to loiter at the 
boring parts before rushing through the interesting parts so 
fast you can hardly catch the important occurrences at higher 
K values. Then play with the slider to see just how much the graph 
changes with very small changes in K. Significantly different 
outcomes with very small changes in input is a key factor in 
chaos.



The Logistic Equation
----------------------
The equation at the heart of this demo is very simple.

	f(x) = K * x(1 - x)

where X = Current Population Size and f(x) is the future 
population size given a population growth constant K. 

Robert May and others have applied this equation to population 
growth patterns. In the real world, the constant K can actually 
vary over time, this may be due to different weather, food 
availability, or other factors that affect how the population 
is growing. We simplify the situation in this mathematical model 
where we calculate the growth curve for a given population for 
various values of K (the graph at any single point on the trackbar). 

By varying the value of the K growth constant the demo explores 
the many different possibilities that exists to produce a sometimes 
beautiful, fundamentally chaotic, bio-feedback system. For more 
information see 'Measuring Chaos' at 
http://hypertextbook.com/chaos/42.shtml
