# Spacewatch
Spacewatch is a software for controlling a specific, DIY motor-controlled telescope, and taking and stacking images. 
The telescope is controlled by an arduino, which communicates via USB serial with Spacewatch.
A live video feed, which is captured by a camera mounted to the telescope, is transmitted separately.
It can be displayed with an overlay of a virtual map of the night sky.

![alt text](https://github.com/julfarn/spacewatch/blob/main/Spacewatch_screen1.PNG?raw=true)

Users can create their own databases of celestial objects. The current coordinates of the planets are pulled from a website.

![alt text](https://github.com/julfarn/spacewatch/blob/main/Spacewatch_screen2.PNG?raw=true)

Precisely calibrating the telescope's alignment is a difficult task by hand. Spacewatch supports calibration by identifying celestial objects seen in the camera feed with database entries.

![alt text](https://github.com/julfarn/spacewatch/blob/main/Spacewatch_screen3.PNG?raw=true)

In astrophotography, very long exposure times are needed. This is achieved by "stacking" several photographs with shorter exposure times together. Spacewatch has basic stacking and image editing capabilities, and uses its own raw file format.

![alt text](https://github.com/julfarn/spacewatch/blob/main/Spacewatch_screen4.PNG?raw=true)
