# INBRE Summer 2024 Research Project
This project aims to leverage VR and AI to create an immersive environment that fosters natural dialogue and interaction with an AI avatar. The goal is to increase the retention rate of learning the ASL alphabet.
This has project has been built on Andriod and has only been used and tested using the Quest 1. It would most likley work with the Quest 2. 

Special thanks to Gavin Caulfield for providing the Conference Room and avatar AI functionality.

# Installation

* Open your system’s terminal and make sure that [git](https://git-scm.com/downloads) is installed
* Navigate to the directory you want the project to be located 
* Copy the project URL: https://github.com/BlueBenjaminBen/VR-AI-LearningASL.git
* In your system’s terminal, type “git clone https://github.com/BlueBenjaminBen/VR-AI-LearningASL.git ”
* In the unity hub application, click the dropdown arrow next to the add button and press, “Add project from disk”. Navigate to where you cloned the project and open it.
* When you first open the project, it will ask you if you want to update a certain file because it is referring to an old API, we won't be using it, so just press "No".
* Download this file and put it in the Assets/StreamingAssets/Samples folder: [ASL Gesture Data](https://drive.google.com/drive/folders/1-TeciPriGTEGPImztHlW43cZbBcWIXWA?usp=sharing)

# Usage and Controls
When starting the "Main Scene", there will be an input field in front of you and to input text you must sign the word letter by letter. To do this, there is a **recording trigger in the right hand** and to activate it, simply **pinch with your thumb and index finger**. Letting go will stop the recording of the gestures in the left hand. 

Currently it is only possible to sign with the left hand. If you wanted to change the gesture trigger action from the pinch to a grab that will be outlined in a future video as well as more details on the customization 
of the scene and functionality.


# Demo Videos
Some letters of the ASL alphabet are modified and do not follow what the actual gesture sign is for the letters due to the limitations of the Quest hand tracking. For example, the letter R, the quest is unable to detect
the index finger and middle finger being intertwined and thus I had to create a different gesture to represent those letters. 

The letters that have been changed are:
* M
* N
* P
* R

[VR/AI ASL Demo Video](https://youtu.be/WMlOBTS5Tw8?si=o35wmjqqKxfG4pmj)

[ASL Alphabet Gesture Guide](https://youtu.be/jr-FCjPemKg?si=QgOVuppyFOupgZEW)

# References

The avatar models used in this project were using the [VALID Validated Avatar Library](https://github.com/google/valid-avatar-library). 

---

If you have any questions, feel free to reach me at benle@udel.edu

Thank you for checking out my project and I hope you enjoy it!

