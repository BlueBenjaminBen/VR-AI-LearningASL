# INBRE Summer 2024 Research Project
This project aims to leverage VR and AI to create an immersive environment that fosters natural dialogue and interaction with an AI avatar. The goal is to increase the retention rate of learning the ASL alphabet.
This has project has been built on Andriod and has only been used and tested using the Quest 1. It would most likley work with the Quest 2. 

Special thanks to Gavin Caulfield for providing the room and avatar AI functionality.

# Installation

* Open your system’s terminal and make sure that [git](https://git-scm.com/downloads) is installed
* Navigate to the directory you want the project to be located 
* Copy the project URL: https://github.com/BlueBenjaminBen/VR-AI-LearningASL.git
* In your system’s terminal, type “git clone https://github.com/BlueBenjaminBen/VR-AI-LearningASL.git ”
* In the unity hub application, click the dropdown arrow next to the add button and press, “Add project from disk”. Navigate to where you cloned the project and open it.

# Usage and Controls
When starting the "Main Scene", there will be an input field in front of you and to input text you must sign the word letter by letter. To do this, there is a **recording trigger in the right hand** and to activate it, simply pinch with your
**thumb and index finger**. Letting go will stop the recording of the gestures in the left hand. 

Currently it is only possible to sign with the left hand. If you wanted to change the gesture trigger action from the pinch to a grab that will be outlined in a future video as well as more details on the customization 
of the scene and functionality.


# VR-AI-Learning Scene Demo


# Letter Signing Demo
Some letters of the ASL alphabet are modified and do not follow what the actual gesture sign is for the letters due to the limitations of the Quest hand tracking. For example, the letter R, the quest is unable to detect
the index finger and middle finger being intertwined and thus I had to create a different gesture to represent those letters. 

The letters that have been changed are:
* M
* N
* P
* R

Some letters also to differ slightly in anlge and where your hand is facing to mitigate the detection of a unintended letter and will be acknowledged and shown in the video.

Thank you for checking out my project and I hope you enjoy it!
